module.exports = env => {
    // Use the default cluu webpack config.
    let buildConfig = require(env.cluuWebPackConfig)(env, module, __dirname);

    if (buildConfig.webPackConfig.context == null) {
        buildConfig.webPackConfig.context = __dirname + "/dist";
    }

    return buildConfig.webPackConfig;
};
