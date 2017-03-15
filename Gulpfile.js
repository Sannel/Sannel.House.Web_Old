/// <binding AfterBuild='default' />
var gulp = require("gulp");
var plumber = require("gulp-plumber");
var ts = require("gulp-typescript");
var sourcemaps = require("gulp-sourcemaps");
var runSequence = require("run-sequence");
var sass = require("gulp-sass");
var debug = require("gulp-debug");

gulp.task("default", function (callback) {
	return runSequence(
		"Compile-Typescript",
		"Compile-SCSS",
		callback);
});

gulp.task("Compile-Typescript", function (callback) {
	var source = ["src/**/ts/**/*.ts","!**/*.d.ts", "!src/**/bin/**/*", "!src/**/obj/**/*"];
	return gulp.src(source)
		.pipe(plumber())
		.pipe(sourcemaps.init())
		.pipe(ts({
			out: 'site.js'
		}
		))
		.pipe(sourcemaps.write())
		.pipe(gulp.dest("src/Sannel.House.Web/wwwroot/js"));
});

gulp.task("Compile-SCSS", function (callback) {
	var source = "./src/Sannel.House.Web/wwwroot/scss/Site.scss";
	gulp.src(source)
		.pipe(plumber())
		.pipe(sourcemaps.init())
		.pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
		.pipe(sourcemaps.write())
		.pipe(debug({ title: "Compiling "}))
		.pipe(gulp.dest("src/Sannel.House.Web/wwwroot/css"));
});
