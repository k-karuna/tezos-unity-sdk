const path = require("path");
const NodePolyfillPlugin = require("node-polyfill-webpack-plugin");

module.exports = {
  entry: "./src/index.ts",
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: "ts-loader",
        exclude: /node_modules/,
      },
    ],
  },
  resolve: {
    extensions: [".ts", ".js"],
    fallback: {
      fs: false,
    },
  },
  output: {
    filename: "StreamingAssets/webgl-frontend.js",
    path: path.resolve(__dirname, "output"),
  },
  plugins: [new NodePolyfillPlugin()],
};