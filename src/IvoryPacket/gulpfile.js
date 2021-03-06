/// <binding ProjectOpened='watch' />
/// <vs SolutionOpened='watch, default' />
var gulp = require("gulp");
var project = require("./project.json");
var rimraf = require("rimraf");
var rename = require("gulp-rename");
var minifycss = require("gulp-minify-css");
var sass = require("gulp-sass");
var ts = require('gulp-typescript');
var tslint = require("gulp-tslint");
var sourcemaps = require("gulp-sourcemaps");
var fs = require("fs");
var wiredep = require("wiredep");
var inject = require("gulp-inject");
var flatten = require("gulp-flatten");
var series = require("stream-series");
var plumber = require("gulp-plumber");
var angularFileSort = require("gulp-angular-filesort");

var paths = {
    webroot: project.webroot + "/"
};
paths.distVendorDir = paths.webroot + "lib/";
paths.distCSSDir = paths.webroot + "css/";
paths.distCSSFiles = paths.webroot + "css/**/*.css";
paths.distJSDir = paths.webroot + "js/";
paths.distHTMLDir = paths.webroot + "html";
paths.distJSFiles = paths.webroot + "js/**/*.js";
paths.distFontDir = paths.webroot + "fonts/";
paths.distIndexFile = paths.webroot + "index.html";
paths.distImageDir = paths.webroot + "images/";
paths.srcSCSSFiles = "app/styles/**/*.{scss, css}";
paths.srcTSFiles = "app/**/*.ts";
paths.srcIndexFile = "app/index.html";
paths.srcHTMLFiles = "app/**/*.html";
paths.srcImageFiles = "app/images/**/*";
paths.typings = "./typings/**/*.d.ts";
paths.bower = "bower_components/";

gulp.task("clean", ["clean:app-js", "clean:vendor-js", "clean:css", "clean:html", "clean:index", "clean:vendor-fonts", "clean:images"]);

gulp.task("clean:css", function (cb) {
    rimraf(paths.distCSSDir, cb);
});

gulp.task("clean:app-js", function (cb) {
    rimraf(paths.distJSDir, cb);
});

gulp.task("clean:vendor-js", function (cb) {
    rimraf(paths.distVendorDir, cb);
})

gulp.task("clean:vendor-fonts", function (cb) {
    rimraf(paths.distFontDir, cb);
})

gulp.task("clean:html", function (cb) {
    rimraf(paths.distHTMLDir, cb);
});

gulp.task("clean:index", function (cb) {
    rimraf(paths.distIndexFile, cb);
});

gulp.task("clean:images", function (cb) {
    rimraf(paths.distImageDir, cb);
});

gulp.task("copy-images", function () {
    var images = gulp.src(paths.srcImageFiles).pipe(gulp.dest(paths.distImageDir));
});

//Transpiles app SCSS files into minifed CSS and writes them to webroot.
gulp.task("transpile-scss", function () {
    return gulp.src(paths.srcSCSSFiles)
        .pipe(plumber())
        .pipe(sass({ style: "expanded" }))
        .pipe(gulp.dest(paths.distCSSDir));
});

//Transpiles app TS files to JS and writes them to webroot.
gulp.task('transpile-ts', function () {
    var clientResult = gulp.src([paths.srcTSFiles, "!app/**/*Spec.ts"])
        .pipe(plumber())
        .pipe(flatten())
        .pipe(ts({
            target: 'ES5'
        }));
    return clientResult.js.pipe(gulp.dest(paths.distJSDir));
});

//Copies HTML partials to webroot.
gulp.task("copy-html", function () {
    return gulp.src([paths.srcHTMLFiles, '!app/index.html']).pipe(flatten()).pipe(gulp.dest(paths.distHTMLDir));
});

//Copies vendor JS files to webroot.
gulp.task('copy-vendor-js', function () {
    return gulp.src(wiredep().js)
         .pipe(plumber({
             errorHandler: function (err) {
                 console.log(err);
                 this.emit('end');
             }
         }))
     .pipe(gulp.dest(paths.distVendorDir));
});

//Copies vendor CSS files to webroot.
gulp.task('copy-vendor-css', function () {
    return gulp.src(wiredep().css)
         .pipe(plumber({
             errorHandler: function (err) {
                 console.log(err);
                 this.emit('end');
             }
         }))
     .pipe(gulp.dest(paths.distCSSDir));
});

//Copies vendor font files to webroot.
gulp.task('copy-vendor-fonts', function () {
    return gulp.src("bower_components/font-awesome/fonts/*.woff").pipe(gulp.dest(paths.distFontDir));
});

//Injects JS and CSS reference tags in index.html from Bower and app src files.
gulp.task('wiredep', ["copy-vendor-css", "copy-vendor-js", "transpile-ts", "transpile-scss"], function () {
    gulp.src(paths.srcIndexFile)
        .pipe(inject(gulp.src([paths.distJSFiles]).pipe(angularFileSort()), {
            addRootSlash: false,
            transform: function (filePath, file, i, length) {
                return '<script src="' + filePath.replace(paths.webroot, '') + '"></script>';
            }
        }))
        .pipe(inject(gulp.src(paths.distCSSFiles, { read: false }), {
            addRootSlash: false,
            transform: function (filePath, file, i, length) {
                return '<link rel="stylesheet" href="' + filePath.replace(paths.webroot, '') + '"/>';
            }
        })).pipe(wiredep.stream({
            fileTypes: {
                html: {
                    replace: {
                        js: function (filePath) {
                            return '<script src="' + paths.distVendorDir.replace(paths.webroot, "") + filePath.split('/').pop() + '"></script>';
                        },
                        css: function (filePath) {
                            return '<link rel="stylesheet" href="' + paths.distCSSDir.replace(paths.webroot, "") + filePath.split('/').pop() + '"/>';
                        }
                    }
                }
            }
        }))
        .pipe(gulp.dest(paths.webroot));
});

//Watches src SCSS, TS and Index files.
gulp.task("watch", function () {
    gulp.watch(paths.srcSCSSFiles, ["default"]);
    gulp.watch(paths.srcTSFiles, ["default"]);
    gulp.watch(paths.srcIndexFile, ["default"]);
    gulp.watch(paths.srcHTMLFiles, ["default"]);
    gulp.watch(paths.srcImageFiles, ["default"]);
});

gulp.task("default", ["copy-html","copy-vendor-fonts", "copy-images", "wiredep"], function () { });