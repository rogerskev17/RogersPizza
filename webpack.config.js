 const path = require('path');
  module.exports = {
    mode: 'production',
    entry: './wwwroot/jsx/paymentOptions.js',
    output: {
      path: path.resolve(__dirname, './wwwroot/js'),
      filename: 'paymentOptionsBundled.js'
    },
    module: {
      rules: [
        {
          test: /\.(js|jsx)$/,
          exclude: /node_modules/,
          use: {
            loader: 'babel-loader'
          },
        },
        {
          test: /\.css$/,
          use: ['style-loader', 'css-loader']
        },
      ],
    },
    resolve: {
      extensions: ['.js', '.jsx']
    },
  };