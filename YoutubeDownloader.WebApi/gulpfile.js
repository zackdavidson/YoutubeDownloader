const gulp = require('gulp');
const concat = require('gulp-concat');
const cleanCSS = require('gulp-clean-css');
const sass = require('gulp-sass')(require('sass'));
const terser = require('gulp-terser');
var strip = require('gulp-strip-comments');

// TODO: implement typescript

// Packs the javascript files to a standard 
gulp.task('js:pack', () => {
    return gulp.src([
        `node_modules/jquery/dist/jquery.min.js`,
        `node_modules/toastr/toastr.js`,
        `Views/**/*.js`])
        .pipe(concat('scripts.js'))
        .pipe(gulp.dest(`StaticFiles/`));
})

gulp.task('fonts', () => {
    return gulp.src('node_modules/font-awesome/fonts/**')
        .pipe(gulp.dest(`StaticFiles/fonts`))
});

gulp.task('js:minify', () => {
    return gulp.src([
        `node_modules/jquery/dist/jquery.min.js`,
        `node_modules/toastr/toastr.js`,
        `Views/**/*.js`,
        `Views/Shared/**/*.js`])
        .pipe(strip())
        .pipe(concat('scripts.min.js'))
        .pipe(terser())
        .pipe(gulp.dest(`StaticFiles/`));
})

gulp.task('scss:pack', () => {
    return gulp.src([`Views/Shared/**/*.scss`, `Views/**/*.scss`])
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('styles.css'))
        .pipe(gulp.dest(`StaticFiles/`));
})

gulp.task('css:minify', () => {
    return gulp.src([`Views/Shared/**/*.scss`, `Views/**/*.scss`])
        .pipe(sass().on('error', sass.logError))
        .pipe(cleanCSS({ compatibility: 'ie9' }))
        .pipe(concat('styles.min.css'))
        .pipe(gulp.dest(`StaticFiles/`));
});

//Builds for the local environment, builds all the javascrpt and scss 
gulp.task('build:local', gulp.series('js:pack', 'scss:pack', 'fonts'));

// Builds for production environemnt, builds and minifys / uglifies everything
gulp.task('build:prod', gulp.series('js:minify', 'css:minify', 'fonts'));

gulp.task('build:all', gulp.series('build:local', 'build:prod'));

// Watches for local changes and builds scss to css and javascript to js
gulp.task('watch:local', () => {
    gulp.watch([
        `Views/**/*.scss`,
        `Views/Shared/**/*.scss`], gulp.series('scss:pack'));

    gulp.watch([
        `Views/**/*.js`,
        `Views/Shared/**/*.js`], gulp.series('js:pack'));
});





