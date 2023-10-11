module.exports = {
    aliases: {
        "@node_modules": "./node_modules",
        "@libs": "./wwwroot/libs"
    },
    clean: [
        "@libs"
    ],
    mappings: {
        "@node_modules/@viz-js/viz/lib/viz-standalone.js": "@libs/viz-js",
        "@node_modules/datatables.net-buttons-bs/js/buttons.bootstrap.min.js": "@libs/datatables.net-buttons/js/",
        "@node_modules/datatables.net-buttons/js/dataTables.buttons.min.js": "@libs/datatables.net-buttons/js/",
        "@node_modules/datatables.net-buttons-bs/css/buttons.bootstrap.min.css": "@libs/datatables.net-buttons/css/",
        "@node_modules/echarts/dist/echarts.min.js": "@libs/echarts/js/",
        "@node_modules/jstree/dist/**/*.*": "@libs/jstree/"
    }
};