
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

//从api中提交书POST,url里面可以带/1
function apiPOST(url, data, keys, form, fnSuccess) {
    var realUrl = '/api/' + url
    //var openId = $.fn.getUrlParam('openId');
    var dataTemp = {}
    var dataKeys=Object.keys(data)

    for (var i = 0; i < dataKeys.length; i++) {
        var key = dataKeys[i];
        var v = data[key]
        dataTemp[key] = v
    }

    for (var i = 0; i < keys.length; i++) {
        key = keys[i]
        value = $.fn.getUrlParam(key)
        dataTemp[key] = value
    }

    console.log(dataTemp)


    var type = "POST";
    $.ajax({
        //几个参数需要注意一下
        type: type,//方法类型
        caches: false,//不要读取缓存
        dataType: "json",//预期服务器返回的数据类型
        url: realUrl,//url
        data: dataTemp,
        success: function (result) {
            console.log(result);
            var a = JSON.parse(result)
            var fenxiangMa = a.Table1[0].fenxiangMa
            debugger
            fnSuccess(fenxiangMa)
            //debugger
        },
        error: function (ex) {
            console.log(ex)
            debugger
        }
    })
   // apiPut(url = 'fenxiangg', keys = ['ShuqianID','UserID'])

}


function replaceQueryString(url, nameValue) {
    [name, value] = nameValue.split("=")
    const re = new RegExp(name + '=[^&]*', 'gi')
    //var nameValue = name + '=' + value
    
    if (url.search(re) > 0)
        return url.replace(re, nameValue)

    var joinchar = "&"
    if (url.search("/\?/") ==-1)
        joinchar="?"
    

    if (url.search("#") > -1) {
        url.replace("#", joinchar + nameValue + "#")

    }

    return url + joinchar + nameValue 
}
//————————————————
//版权声明：本文为CSDN博主「_我爱鱼香肉丝」的原创文章，遵循CC 4.0 BY - SA版权协议，转载请附上原文出处链接及本声明。
//原文链接：https://blog.csdn.net/jsjcmq/article/details/107227763