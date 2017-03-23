<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexconfigure.aspx.cs" Inherits="WebSystem.Systestcomjun.homepage.indexconfigure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet">
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet">
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet">
    <style>

    </style>
    <!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#"><span class="glyphicon glyphicon-home"></span></a></li>
                <li class="active">首页管理</li>
            </ol>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">首页设置</div>
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="form-group">
                            <label>Logo(214x29)</label>
                                <asp:Image ID="logimg" ImageUrl="" Width="214px" Height="29px" runat="server" />
                                <asp:FileUpload ID="lgofill" runat="server" onchange="onFileChangelog(this)" />
                            </div>
                            <div class="form-group">

                                <label>首页广告图(1920x630)</label>
                                <asp:Image ID="img_Photo" ImageUrl="" Width="350px" Height="200px" runat="server" />
                                <asp:FileUpload ID="fileLogo" runat="server" onchange="onFileChange(this)" />
                            </div>
                            <div class="form-group" >
                                <label>广告图(宽960x高自定义)</label>
                                <asp:Image ID="ggimg" ImageUrl="" Width="350px" Height="200px" runat="server" />
                                <asp:FileUpload ID="ggfill" runat="server" onchange="onFileChangegg(this)" />
                            </div>
                            <div class="form-group">
                                <label>联系电话</label>
                                <asp:TextBox ID="phone" runat="server" class="form-control"  placeholder="请输入联系电话如400-1232-7878"></asp:TextBox>
                            </div>
                            <div class="form-group">
                            <label>电子邮箱</label>
                            <asp:TextBox ID="mail" runat="server" class="form-control"  placeholder="请输入电子邮箱"></asp:TextBox>
                            </div>
                        </div>
                       <div class="col-md-12" style="text-align: center;"><asp:Button ID="btnsave" runat="server" Text="保存" class="btn btn-primary" OnClick="btnsave_Click" width="100px" /></div>
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <!-- /.row -->
        </div>
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <script type="text/javascript">
            $(function () {
                $(".fuxuan").find("input[type=checkbox]").click(function () {
                    if ($(".fuxuan").find("input[type=checkbox]:checked").length < 1) {
                        $(this).prop("checked", true);
                        showmsg('文件格式', '至少选中一种图片格式', '', 2);
                    }
                });
            })
            var img = '<%=imgformat%>';
            function onFileChange(sender) {
                var filename = sender.value;
                if (filename == "") {
                    return "";
                }
                var ExName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();

                var imgs = img.split(',');
                if ($.inArray(ExName.toLowerCase(), imgs) >= 0) {
                    document.getElementById("img_Photo").src = window.URL.createObjectURL(sender.files[0]);
                }
                else {
                    layer.open({
                        content: "不能上传这种格式的图片！",
                        icon: 2
                    });
                    sender.value = null;
                    return false;
                }

            }

            function onFileChangegg(sender) {
                var filename = sender.value;
                if (filename == "") {
                    return "";
                }
                var ExName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();

                var imgs = img.split(',');
                if ($.inArray(ExName.toLowerCase(), imgs) >= 0) {
                    document.getElementById("ggimg").src = window.URL.createObjectURL(sender.files[0]);
                }
                else {
                    layer.open({
                        content: "不能上传这种格式的图片！",
                        icon: 2
                    });
                    sender.value = null;
                    return false;
                }

            }

            function onFileChangelog(sender) {
                var filename = sender.value;
                if (filename == "") {
                    return "";
                }
                var ExName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();

                var imgs = img.split(',');
                if ($.inArray(ExName.toLowerCase(), imgs) >= 0) {
                    document.getElementById("logimg").src = window.URL.createObjectURL(sender.files[0]);
                }
                else {
                    layer.open({
                        content: "不能上传这种格式的图片！",
                        icon: 2
                    });
                    sender.value = null;
                    return false;
                }

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
                                parent.location = parent.location;
                            }
                            var frm = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                            parent.layer.close(frm); //再执行关闭   
                        } else {
                            window.location = url;
                        }
                    }
                });
            }
        </script>
    </form>
</body>
</html>
