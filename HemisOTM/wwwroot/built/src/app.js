import PulseLoader from './PulseLoader.vue';
import GridLoader from './GridLoader.vue';
import ClipLoader from './ClipLoader.vue';
import RiseLoader from './RiseLoader.vue';
import BeatLoader from './BeatLoader.vue';
import SyncLoader from './SyncLoader.vue';
import RotateLoader from './RotateLoader.vue';
import FadeLoader from './FadeLoader.vue';
import PacmanLoader from './PacmanLoader.vue';
import SquareLoader from './SquareLoader.vue';
import ScaleLoader from './ScaleLoader.vue';
import SkewLoader from './SkewLoader.vue';
import MoonLoader from './MoonLoader.vue';
import RingLoader from './RingLoader.vue';
import BounceLoader from './BounceLoader.vue';
import DotLoader from './DotLoader.vue';
import Vue from "vue";
//Vue.config.debug = true
new Vue({
    el: '#app',
    components: {
        PulseLoader: PulseLoader,
        GridLoader: GridLoader,
        ClipLoader: ClipLoader,
        RiseLoader: RiseLoader,
        BeatLoader: BeatLoader,
        SyncLoader: SyncLoader,
        RotateLoader: RotateLoader,
        FadeLoader: FadeLoader,
        PacmanLoader: PacmanLoader,
        SquareLoader: SquareLoader,
        ScaleLoader: ScaleLoader,
        SkewLoader: SkewLoader,
        MoonLoader: MoonLoader,
        RingLoader: RingLoader,
        BounceLoader: BounceLoader,
        DotLoader: DotLoader
    },
    data: function () {
        return {
            color: '#5dc596',
            size: '15px',
            margin: '2px',
            radius: '100%'
        };
    }
});
//# sourceMappingURL=app.js.map