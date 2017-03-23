<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebSystem.Systestcomjun.JobTraining.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
        <script language="javascript" charset="utf-8" src="/keditor/kindeditor.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/lang/zh_CN.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/plugins/code/prettify.js"></script>
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
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>类型</label>
                                <asp:RadioButtonList ID="rbtType" runat="server" Width="100px" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="企业" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="个人"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="form-group">
                                <label>标题</label>
                                <asp:TextBox ID="txtJobTraTitle" runat="server" class="form-control" t="txt" n="1" MaxLength="30" placeholder="输入标题，必填"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                <label>图片</label>
                                 <br /><asp:Image ID="img_Photo" ImageUrl="/images/admin/noimg.jpg" Width="80px" Height="80px" runat="server" />
                                <asp:FileUpload ID="fileImg" runat="server" onchange="onFileChange(this)" />
                                <%-- <span class="Validform_checktip">*请上传正方形的图片，尽量上传比较小的图片，以便保证手机端的加载速度</span>--%>
                            </div>
                            <div class="form-group">
                                <label>作者</label>
                                <asp:TextBox ID="txtJobTraName" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="输入作者，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>联系方式</label>
                                <asp:TextBox ID="txtPhone" runat="server" class="form-control" t="txt" n="1" MaxLength="12" placeholder="输入联系方式，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>排序</label>
                                <asp:TextBox ID="txtSort" runat="server" class="form-control" t="int" n="1" MaxLength="4" placeholder="输入排序号，只能输入数字，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>简略描述</label>
                                <asp:TextBox ID="txtAbsDes" runat="server" class="form-control" t="txt" n="1" MaxLength="200"   placeholder="输入简略描述信息，必填" TextMode="MultiLine" Height="80px"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>描述</label>
                                <asp:TextBox ID="txtJobTraDes" runat="server" class="form-control" t="txt" n="1" style="width:100%;height:500px;" placeholder="输入描述信息，必填" TextMode="MultiLine" Height="100px"></asp:TextBox>
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
            KindEditor.ready(function (K) {
                var editor1 = K.create('#txtJobTraDes', {
                    cssPath: '/keditor/plugins/code/prettify.css',
                    uploadJson: '/keditor/net/upload.ashx',
                    fileManagerJson: '/keditor/net/file.ashx',
                    allowFileManager: true,
                    urlType: 'domain',
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
