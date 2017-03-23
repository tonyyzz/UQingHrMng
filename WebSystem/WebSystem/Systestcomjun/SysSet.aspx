<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysSet.aspx.cs" Inherits="WebSystem.Systestcomjun.SysSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <li class="active">系统管理</li>
            </ol>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">系统设置</div>
                    <div class="panel-body">
                        <div class="col-md-6">

                            <div class="form-group">
                                <label>上传文件大小</label>
                                <asp:TextBox ID="txtFileSize" runat="server" class="form-control" t="int" n="1" MaxLength="3" placeholder="比如用户上传头像大小，只能输入数字（kb）"></asp:TextBox>
                            </div>
                            <div class="form-group" >
                                <label>订单到期时间（天）</label>
                                <asp:TextBox ID="txtOrderTime" runat="server" class="form-control" t="int" MaxLength="3" n="1" placeholder="只能输入数字（天）" Text="5"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>悬赏提成</label>
                                <asp:TextBox ID="txtCommission" runat="server" class="form-control" t="int" MaxLength="2" n="1" placeholder="输入提成百分比,只能输入数字"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                             <div class="form-group">
                                <label>上传文件格式</label>
                                <asp:CheckBoxList ID="chkImgFormat" runat="server" RepeatDirection="Horizontal" CssClass="fuxuan">
                                    <asp:ListItem Text="png" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="jpg" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="gif"></asp:ListItem>
                                    <asp:ListItem Text="bmp"></asp:ListItem>
                                    <asp:ListItem Text="tiff"></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                             <div class="form-group" >
                                <label>订单每次延期时间（天）</label>
                                <asp:TextBox ID="txtSetOrderTime" runat="server" class="form-control" t="int" MaxLength="3" n="1" placeholder="只能输入数字（天）" Text="0"></asp:TextBox>
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
        <script src="/Systestcomjun/js/pubfunction.js"></script>
        <script type="text/javascript">
            $(function () {
                $(".fuxuan").find("input[type=checkbox]").click(function () {
                    if ($(".fuxuan").find("input[type=checkbox]:checked").length < 1) {
                        $(this).prop("checked",true);
                        showmsg('文件格式', '至少选中一种图片格式', '', 2);
                    } 
                });
            })
        </script>
    </form>
</body>
</html>
