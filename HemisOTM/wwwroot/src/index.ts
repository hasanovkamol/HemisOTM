import Vue from "vue";
import Notifications from 'vue-notification';
import TableComponent from "./components/table/index.vue";

Vue.use(Notifications);

//Vue.config.productionTip = true;

new Vue({
    el: "#app-table",
    components: {
        TableComponent
    }
});

