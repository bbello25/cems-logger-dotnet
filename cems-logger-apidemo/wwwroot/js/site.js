// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
const CemsLogger = lib.default;

// Write your JavaScript code.
const logger = CemsLogger.initLogger({
    endPointUrl: 'http://localhost:5000/',
    apiKey: '1ab056db7ee8493494fbd08e803f60a8',
    appName: 'javascsrip_demo_app',
    appVersion: "1.0.2",
    email: 'b.bellovic@gmail.com'
});

window.onerror = function (msg, url, line, col, error) {
    logger.sendLog(error).then(() => {
        console.error(error)
    })
};

function throwError() {
    secondLevelfError()
}

function secondLevelfError() {
    thirdLevelError();
}

function thirdLevelError() {
    throw Error("Example error")
}