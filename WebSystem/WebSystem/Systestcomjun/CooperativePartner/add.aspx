<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="WebSystem.Systestcomjun.CooperativePartner.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link rel="stylesheet" type="text/css" href="/keditor/themes/default/default.css" />
	<link rel="stylesheet" type="text/css" href="/keditor/plugins/code/prettify.css" />
	<script language="javascript" charset="utf-8" src="/keditor/kindeditor.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/lang/zh_CN.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/plugins/code/prettify.js"></script>
        <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet"/>
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet"/>

    <!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->
</head>
<body style="padding-top: 15px;">
    <form id="form1" runat="server">
    <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>合作伙伴名称</label>
                               <asp:TextBox ID="txtName" runat="server" class="form-control" t="txt" n="1" MaxLength="20" placeholder="输入名称，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>链接地址</label>
                               <asp:TextBox ID="LinkUrl" runat="server" class="form-control" t="txt" n="1" MaxLength="20"   placeholder="链接地址，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Logo(99x40)</label>
                                 <br /><asp:Image ID="img_Photo" ImageUrl="/images/admin/noimg.jpg" Width="80px" Height="80px" runat="server" />
                                <asp:FileUpload ID="fileLogo" runat="server" onchange="onFileChange(this)" />
                            </div>
                            <div class="form-group">
                                <label>排序</label>
                                 <asp:TextBox ID="Sort" runat="server" class="form-control" t="txt" n="1" MaxLength="20"   placeholder="排序，必填"></asp:TextBox>
                            </div>
                        </div>
                        <%--<div class="col-md-12" style="text-align: center;">--%>
                        <asp:Button ID="btnsave" runat="server" Text="保存" class="btn btn-primary btn_Save" OnClick="btnsave_Click" Width="100px" />
                        <%--</div>--%>
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <!-- /.row -->
        </div>
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <script src="/Systestcomjun/js/pubfunction.js"></script>
        <script type="text/javascript">
            var img = '<%=imgformat%>';
            function onFileChange(sender) {
                var filename = sender.value;
                if (filename == "") {
                    return "";
                }
                var ExName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();

                var imgs = img.split(',');
                alert(ExName);
                if ($.inArray(ExName.toLowerCase(), imgs) > 0) {
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
            KindEditor.ready(function (K) {
                var editor1 = K.create('#txtNewsCon', {
                    cssPath: '/keditor/plugins/code/prettify.css',
                    uploadJson: '/keditor/net/upload.ashx',
                    fileManagerJson: '/keditor/net/file.ashx',
                    allowFileManager: true,
                    afterCreate: function () {
                        var self = this;
                        K.ctrl(document, 13, function () {
                            self.sync();
                            K('form[name=example]')[0].submit();
                        });
                        K.ctrl(self.edit.doc, 13, function () {
                            self.sync();
                            K('form[name=example]')[0].submit();
                        });
                    }
                });
            });
        </script>
    </form>
</body>
</html>
