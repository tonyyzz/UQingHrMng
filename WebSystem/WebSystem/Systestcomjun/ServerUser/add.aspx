<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="WebSystem.Systestcomjun.ServerUser.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
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
                        添加人才经纪人
                    </div>
                    <div class="panel-body">
                        <div class="col-md-6">

                            <div class="form-group">
                                <label>姓名</label>
                                <asp:TextBox ID="txtRealName" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="输入角色名称，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>手机号码</label>
                                <asp:TextBox ID="txtPhne" runat="server" class="form-control" t="phone" n="1" MaxLength="11" placeholder="输入手机号码，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>密码</label>
                                <asp:TextBox ID="txtPwd" runat="server" class="form-control" t="txt" n="1" MaxLength="16" placeholder="请输入密码，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>性别</label>
                                <asp:RadioButtonList ID="rbtSex" runat="server" RepeatDirection="Horizontal" Width="100px">
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="2">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="form-group">
                                <label>行业</label>
                                <asp:TextBox ID="txtTrade" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="输入行业，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>公司</label>
                                <asp:TextBox ID="txtCompany" runat="server" class="form-control" t="txt" n="1" MaxLength="20" placeholder="输入公司，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>职位</label>
                                <asp:TextBox ID="txtPosition" runat="server" class="form-control Wdate" t="txt" n="1" MaxLength="10" placeholder="输入职位，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>工作地区</label>
                                <asp:TextBox ID="txtWorkCity" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="选择城市"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>邮箱</label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" t="Email" n="1" MaxLength="25" placeholder="输入邮箱，必填"></asp:TextBox>
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
