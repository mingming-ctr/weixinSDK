
; (function ($) {
    $.extend($.fn, {
        getUrlParam: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
    })
})(Zepto)

function tiJiaoFangwenShuqian(ID) {
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

            console.log(result);//打印服务端返回的数据(调试用)
            
            //if ("验证通过" == result) {

            //    weui.alert("保存成功")
            //}
            //else
            //    weui.alert(result)
        },
        error: function (ex) {
            console.log(ex)
            debugger
        }
    });


}


