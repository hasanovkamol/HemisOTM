"use strict";
var gulp = require('gulp');
var plugins = require('gulp-load-plugins')();
/********************************************
*			Configs And Paths
*********************************************/
var config = require('../config/');
var paths = config.paths;
/********************************************
*   		Load Build Tasks
*********************************************/
// Dynamic Tasks with Gulp 4
// https://cobwwweb.com/dynamic-tasks-gulp-4
// With Gulp 4, it's not so simple.
//var buildTasks = utils.loadTasks(gulp, plugins, paths);
//gulp.task('build', buildTasks);
var app_assets = require('./tasks/app-assets').task(gulp, plugins, paths);
var app_pages = require('./tasks/app-pages').task(gulp, plugins, paths);
var app_scripts = require('./tasks/app-scripts').task(gulp, plugins, paths);
var app_styles = require('./tasks/app-styles').task(gulp, plugins, paths);
var app_themes = require('./tasks/app-themes').task(gulp, plugins, paths);
var vendor_assets = require('./tasks/vendor-assets').task(gulp, plugins, paths);
var vendor_scripts = require('./tasks/vendor-scripts').task(gulp, plugins, paths);
var vendor_styles = require('./tasks/vendor-styles').task(gulp, plugins, paths);
var clean = function (done) {
    // Error: Cannot delete files/directories outside the current
    // working directory. Can be overridden with the `force` option.
    return require('del')([config.destDir], { force: true });
};
var build = gulp.parallel(gulp.parallel(app_assets, app_scripts, app_pages, gulp.series(app_styles, app_themes)), gulp.parallel(vendor_assets, vendor_scripts, vendor_styles));
/*********************************************
*				 Other Tasks
**********************************************/
// Local server pointing on build folder
var connect = function () {
    return plugins.connect.server({
        root: config.destDir,
        port: config.port || 3333,
        livereload: true
    });
};
var watch = function (done) {
    // When template changes recompile .html pages
    gulp.watch(paths.app.templates, app_pages);
    // When context file changes recompile .html pages
    gulp.watch(config.srcDir + "/**/.context.js", app_pages);
    // When script changes recompile scripts
    gulp.watch(paths.app.scripts, app_scripts);
    // When style changes recompile styles
    gulp.watch(paths.app.styles, app_styles);
    // When theme changes recompile themes
    gulp.watch(paths.app.themes, app_themes);
    done();
};
// Builds and deploys to github pages
var deploy = function () { return gulp.series(build, function () {
    return gulp.src('../dist/**/*')
        .pipe(plugins.ghPages({
        cacheDir: '../.deploy'
    }));
}); };
module.exports.deploy = deploy;
/********************************************
*				Main Tasks
*********************************************/
// Run this task for development
module.exports.build = build;
module.exports.default = gulp.series(clean, build, gulp.parallel(watch, connect));
//# sourceMappingURL=gulpfile.js.map