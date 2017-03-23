<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebSystem.Systestcomjun.UserManagers.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
        <%--<div class="row">
            <ol class="breadcrumb">
                <li><a href="#"><span class="glyphicon glyphicon-home"></span></a></li>
                <li class="active">系统管理</li>
            </ol>
        </div>--%>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-6">

                            <div class="form-group">
                                <label>用户名</label>
                                <asp:TextBox ID="txtUserName" runat="server" class="form-control" t="user" n="1" m="6" MaxLength="16" placeholder="用户登录账号,输入6-16位字母和数字"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>真实姓名</label>
                                <asp:TextBox ID="txtRealName" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="用户的真实姓名"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>邮箱</label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" t="Email" MaxLength="50" placeholder="输入真实邮箱"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>角色</label>
                                <asp:DropDownList ID="ddlRole" runat="server" class="form-control x"></asp:DropDownList>
                            </div>
                        </div>
                        <%--<div class="col-md-12" style="text-align: center;">--%>
                        <asp:Button ID="btnsave" runat="server" Text="保存" class="btn btn-primary  btn_Save" OnClick="btnsave_Click" Width="100px" />
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
            
        </script>
    </form>
</body>
</html>
