
; (function ($) {
    $.extend($.fn, {
        getUrlParam: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
    })
})(Zepto)



//从书签里面提交
function tiJiaoFangwenShuqian_shuqian() {
    var ID = $.fn.getUrlParam('ID');
    tiJiaoFangwenShuqian(ID);
}

//从历史里面提交
function tiJiaoFangwenShuqian(ID) {

    //debugger
    var openId = $.fn.getUrlParam('openId');

    var url = "/api/fangwenshuqian";
    var type = "POST";
    
    $.ajax({
        //几个参数需要注意一下
        type: type,//方法类型
        caches: false,//不要读取缓存
        dataType: "json",//预期服务器返回的数据类型
        url: url,//url
        data: { shuqianID: ID, openId: openId },
        success: function (result) {

            console.log(result);
        },
        error: function (ex) {
            console.log(ex)
            debugger
        }
    });
}

//从api中提交书put,url里面可以带/1
function apiPut(url,data,keys,form) {
    var realUrl = 'api/' + url
    debugger
    var openId = $.fn.getUrlParam('openId');
    var dataTemp = {}
    for (var i = 0; i < data.length; i++) {
        var key = data; 
    }

    for (var i = 0; i < keys.length; i++) {
        key = keys[i]
        value = $.fn.getUrlParam(key)
        data[key] = value
    }

    var url = "/api/fangwenshuqian";
    var type = "PUT";
    $.ajax({
        //几个参数需要注意一下
        type: type,//方法类型
        caches: false,//不要读取缓存
        dataType: "json",//预期服务器返回的数据类型
        url: url,//url
        data: data,
        success: function (result) {
            console.log(result);
            debugger
        },
        error: function (ex) {
            console.log(ex)
            debugger
        }
    })
   // apiPut(url = 'fengxiang', keys = ['ShuqianID','UserID'])

}
