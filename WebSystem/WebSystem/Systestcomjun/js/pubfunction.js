$(function () {
    $("input.form-control").on("input", function () {
        var o = $(this);//当前标签
        var n = o.attr("n");//非空判断  等1 就是不能为空
        var v = o.val().trim();//值
        var t = o.attr("t");//类型 int 大于0的数字
        var m = o.attr("m");//最小长度
        //alert(n);

        if (n == "1") {//判断非空
            if (v == "") {
                o.parent().addClass("has-error");
                layer.tips('不能为空', this, { tips: [1, '#30a5ff'] });
                return;
            }
            if (v.length < m) {
                o.parent().addClass("has-error");
                layer.tips('最小程度为'+m, this, { tips: [1, '#30a5ff'] });
                return;
            }
            if (!inputvli(t, v)) {
                o.parent().addClass("has-error");
                layer.tips('请输入正确内容', this, { tips: [1, '#30a5ff'] });
                return;
            }
            o.parent().removeClass("has-error");
        } else {
            if (v != "" && !inputvli(t, v)) {
                o.parent().removeClass("has-success").addClass("has-error");
                layer.tips('请输入正确内容', this, { tips: [1, '#30a5ff'] });
                return;
            }
            o.parent().removeClass("has-error");
        }


    });
    $("#btnsave").click(function () {
        $("input.form-control").each(function () {
            var o = $(this);
            var n = o.attr("n");
            var v = o.val().trim();
            var t = o.attr("t");
            var m = o.attr("m");
            //alert(n);

            if (n == "1") {
                if (v == "") {
                    o.parent().addClass("has-error");
                    return;
                }
                if (v.length < m) {
                    o.parent().addClass("has-error");
                    return;
                }
                if (!inputvli(t, v)) {
                    o.parent().addClass("has-error");
                    return;
                }
                if (t == "user") {
                    $.post("ajax.ashx", { action: "chkuser", User:v}, function (data) {
                        if (data == "false") {
                            o.parent().addClass("has-error");
                        } else if (data == "cookieNull") {
                            window.top.location = "/Systestcomjun/login.aspx";
                        }
                    });
                }
                o.parent().removeClass("has-error");
            } else {
                if (v != "" && !inputvli(t, v)) {
                    o.parent().removeClass("has-success").addClass("has-error");
                    return;
                }
                o.parent().removeClass("has-error");
            }
        });
        if ($(".has-error").length > 0) {
            return false;
        }
        return true;
    });
});


function inputvli(t, v) {
    switch (t) {
        case "int"://数字类型
            var z = new RegExp(/^[1-9]*[1-9][0-9]*$/);
            return z.test(v);
            break;
        case "txt"://文本类型
            return true;
            break;
        case "Email"://邮箱
            var z = new RegExp(/^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]+$/);
            return z.test(v);
            break;
        case "phone"://手机
            var z = new RegExp(/^1[3|4|5|7|8]\d{9}$/);
            //alert(z.test(v));
            return z.test(v);
            break;
        case "user"://用户名  只能为数字和字母
            var z = new RegExp(/^[a-zA-Z0-9]+$/g);
            return z.test(v);
            break;
    }
}


//
function showmsg1(title,msg, url) {
    var html = "<div class=\"mask\"><div class=\"refdiv\" style=\"display:none;\">";
    html += "<p class=\"title\">" + title + "</p>";
    html += "<p class=\"con\">" + msg + "</p>";
    html += "<input type=\"button\" value=\"确定\" onclick=\"closeref('" + url + "')\" />";
    html += "</div></div>";
    $("body").append(html);
    $(".refdiv").show();
}
function closeref(url) {
    $(".refdiv").hide();
    window.location = url;
}
//信息框 title标题  msg内容 url 跳转的地址 icon  图标 （0 1 2 3）
function showmsg(title, msg, url,icon) {
    layer.open({
        title: title,
        icon: icon,
        content: msg,
        yes: function (index) {
            if (url == "") {
                layer.close(index);
            } else {
                window.location = url;
            }
        }
    });
}
//弹出信息并关闭IFRAME
function showmsgclose(title, msg, url, icon) {
    layer.open({
        title: title,
        icon: icon,
        content: msg,
        yes: function (index) {
            if (url == "") {
                layer.close(index);
                if (top != self) {
                    //parent.location = parent.location;
                }
                var frm = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                parent.layer.close(frm); //再执行关闭   
            } else {
                window.location = url;
            }
        }
    });
}