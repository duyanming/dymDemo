var yyWeb = {
    //input: {
    //    channel: "Anno.Plugs.Trace",
    //    router: "Trace",
    //    method: "GetServerStatus",
    //    profile: localStorage.token,
    //    uname: localStorage.account
    //},
    ajaxpara: {
        async: true,
        dataType: "json",
        type: 'post',
        src: window.location.origin === undefined
            ? window.location.protocol + "//" + window.location.host + "/api/Values"
            : window.location.origin + "/api/Values" //兼容老版本IE origin
    },
    process: function (input, callback, errorCallBack) {
        window.$.ajax({
            url: yyWeb.ajaxpara.src + "?t=" + new Date().getMilliseconds(),
            type: yyWeb.ajaxpara.type,
            async: yyWeb.ajaxpara.async,
            dataType: yyWeb.ajaxpara.dataType,
            data: input,
            success: function (data, status) {
                if (status === "success" && data.status && (data.msg === null || data.msg === "")) {
                    callback(data, status);
                } else if (errorCallBack !== null && errorCallBack !== undefined) {
                    errorCallBack(data, status);
                } else {
                    callback(data, status);
                }
            }
        }
        );
    }
};
