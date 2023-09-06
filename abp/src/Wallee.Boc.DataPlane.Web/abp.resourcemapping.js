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
	}
};