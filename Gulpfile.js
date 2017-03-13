/// <binding AfterBuild='default' />
var gulp = require("gulp");
var plumber = require("gulp-plumber");
var ts = require("gulp-typescript");
var sourcemaps = require("gulp-sourcemaps");

gulp.task("default", function (callback) {
	var source = ["src/**/ts/**/*.ts","!**/*.d.ts", "!src/**/bin/**/*", "!src/**/obj/**/*"];
	return gulp.src(source)
		.pipe(plumber())
		.pipe(sourcemaps.init())
		.pipe(ts({
			out: 'site.js'
		}
		))
		.pipe(sourcemaps.write())
		.pipe(gulp.dest("src\\Sannel.House.Web\\wwwroot\\js"));
});

gulp.task("extra", function (callback) {

});