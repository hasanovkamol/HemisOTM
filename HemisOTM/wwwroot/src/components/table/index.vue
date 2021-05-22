<template>
    <div class="card card-block sameheight-item">

        <div class="card-header list-container" id="app">
            
            <notifications group="notify" position="top right" width="300" />

            <div class="header-block pull-left" style="width: 60%;">
                <h3 class="title" id="link-to-details">
                    <a :href="linkToDetails" class="nounderline" target="_blank">
                        <i class="fa fa-th-large"></i> {{ title }}
                    </a>
                </h3>
            </div>
            <div class="header-block pull-right">
                <label class="search">
                    <input v-model="search" class="search-input" placeholder=" Qidiruv..." @change="searching();">
                    <i class="fa fa-search search-icon"></i>
                </label>
                <a href="/Documents/Index" class="btn btn-secondary">
                    <i class="fa fa-arrow-circle-left"></i>
                    Ortga
                </a>
                <button :disabled="disabled" class="btn btn-primary" @click="postAll()">
                    <i class="fa fa-align-left fa-save"></i>
                    Saqlash
                </button>
            </div>
        </div>

        <div class="center" v-if="isTableOn">
            <loader></loader>
        </div>
        <div v-else>
            <table id="main-table" class="table table-hover table-bordered">
                <tbody>
                    <tr v-for="word in wordList">
                        <td style="width: 120px; text-align:center" class="text-center">
                            <input class="btn btn-secondary same-size" style="font-size: 16px;" v-model="word.Lemmas[0].Name" @change="word.UpdateRequired = true;" />
                        </td>
                        <td style="width: 150px;">
                            <label>{{ word.Word.Name }}</label>
                        </td>
                        <td v-for="(sup, index) in word.Supplementaries">
                            <select class="btn btn-secondary same-size" v-model="sup.TagId" @change="onTagSelectedIndexChange(word, $event, index)">
                                <option v-bind:value="0"></option>
                                <option v-for="tag in tags" v-bind:value="tag.Id" v-bind:title="tag.Name">{{ tag.AcronymUZ }}</option>
                            </select>
                        </td>
                        <td id="delete-icon" @click="onRemoveSupplementary(word.Supplementaries)">
                            <a class="same-size">
                                <i class="fa fa-2x color-green fa-trash-o"></i>
                            </a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import ApiRequests from '../../ApiRequests';
    import Loader from '../../src/GridLoader.vue';
    
    export default Vue.extend({
        props: ['docid', 'doctitle'],
        data() {
            return {
                disabled: false,
                wordList: {},
                realWordList: {},
                tags: {},
                isTableOn: true,
                search: '',
                title: this.doctitle,
                linkToDetails: "/document/details/" + this.docid
            }
        },
        components: {
            Loader
        },
        methods: {
            searching(): void {
               let searchingText = this.search;
               let realWords: any = this.realWordList;
               this.wordList = realWords
                                .filter(function (word: any) {
                    return word.Word.Name.indexOf(searchingText) >= 0;
                })
            },
            postAll(): void {
                //var table: HTMLElement = document.getElementById('main-table') as HTMLElement;
                //table.setAttribute("style", "display:none;");
                let words: any = this.cleanUpWords();
                let res = { "Words": words };
                this.isTableOn = true;
                let target: any = this;
                ApiRequests.post('/document/wp', res)
                    .then(function (response) {
                        if (response.StatusCode === 200) {
                            window.location.reload();
                            target.showNotify("Muvaffaqiyatli Saqlandi", 'success');
                        }
                    })
                    .catch(function (error) {
                        // handle error
                    })
                    .then(function () {
                        // always executed
                    });

                this.disabled = true;
            },
            load(target: any): void {
                this.isTableOn = true;
                ApiRequests.get('/document/wp/' + target.docid)
                    .then(function (response) {
                        if (response.StatusCode === 200) {
                            target.wordList = response.Data.Words;
                            target.setDefaultValues(target.wordList);
                            target.tags = response.Data.Tags;
                            target.isTableOn = false;
                        }
                    });
            },
            setDefaultValues(wordList: any): void {
                for (const word of wordList) {
                    if (word.Lemmas === undefined || word.Lemmas === null) word.Lemmas = [];
                    if (word.Supplementaries === undefined || word.Supplementaries === null) word.Supplementaries = [];

                    if (word.Lemmas.length === 0) word.Lemmas.push({ Name: "", Id: 0 }); 
                    if (word.Supplementaries.length === 0) word.Supplementaries.push({ TagId: 0, Id: 0 }); 
                }
                this.realWordList = this.wordList;
            },
            cleanUpWords(): object {
                let words: any = this.realWordList;
                for (const word of words) {
                    for (let i = word.Supplementaries.length - 1; i > -1; i--) {
                        if (word.Supplementaries[i].TagId === 0) {
                            word.Supplementaries.splice(i, 1);
                        } else break;
                    }

                }
                return words;
            },
            onTagSelectedIndexChange(word: any, event: any, index: number): void {
                if (event.target.selectedIndex === 0)
                    return;
                word.UpdateRequired = true;
                if (index === word.Supplementaries.length - 1) word.Supplementaries.push({ TagId: 0, Id: 0 })
            },
            onRemoveSupplementary(currentWordSup: any): void {
                let len: number = currentWordSup.length;
                let target: any = this;
                if (len > 1) {
                    let singleDeletedSup: any = currentWordSup[len - 1];
                    if (singleDeletedSup.Id === 0)
                        currentWordSup.splice(-1, 1);
                    else
                        ApiRequests.post('/document/wp/del', singleDeletedSup)
                            .then(function (response) {
                                if (response.StatusCode === 200) {
                                    currentWordSup.splice(-1, 1);
                                    target.showNotify("Muvaffaqiyatli O'chirildi", 'warning', 'Oldindan saqlangan edi');
                                } else {
                                    target.showNotify('Server bilan aloqa mavjud emas!', 'error');
                                }
                            });
                }
            },
            showNotify(title: string, type: string = 'success', text: string = ''): void {
                this.$notify({
                    group: 'notify',
                    title: "<h4>" + title + "</h4>",
                    text: text,
                    type: type
                });
            }
        },
        mounted() {
            this.load(this);
        }
    });
</script>
<style src="./style.css"></style>
