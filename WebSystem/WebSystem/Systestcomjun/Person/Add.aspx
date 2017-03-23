<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebSystem.Systestcomjun.Person.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
    <script src="../js/My97DatePicker/WdatePicker.js"></script>
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
                                <label>姓名</label>
                                <asp:TextBox ID="txtRealName" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="输入角色名称，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>手机号码</label>
                                <asp:TextBox ID="txtPhne" runat="server" class="form-control" t="phone" n="1" MaxLength="10" placeholder="输入手机号码，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>性别</label>
                                <asp:RadioButtonList ID="rbtSex" runat="server" RepeatDirection="Horizontal" Width="100px">
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="2">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="form-group">
                                <label>学历</label>
                                <asp:DropDownList ID="ddlEducation" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="大专">大专</asp:ListItem>
                                    <asp:ListItem Value="本科">本科</asp:ListItem>
                                    <asp:ListItem Value="硕士">硕士</asp:ListItem>
                                    <asp:ListItem Value="博士">博士</asp:ListItem>
                                    <asp:ListItem Value="其他">其他</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>工作年限</label>
                                <asp:DropDownList ID="ddlWorkLife" runat="server" class="form-control ">
                                    <asp:ListItem Value="应届毕业生">应届毕业生</asp:ListItem>
                                    <asp:ListItem Value="1年">1年</asp:ListItem>
                                    <asp:ListItem Value="2年">2年</asp:ListItem>
                                    <asp:ListItem Value="3年">3年</asp:ListItem>
                                    <asp:ListItem Value="4年">4年</asp:ListItem>
                                     <asp:ListItem Value="5年">6年</asp:ListItem>
                                    <asp:ListItem Value="1年">7年</asp:ListItem>
                                    <asp:ListItem Value="1年">8年</asp:ListItem>
                                    <asp:ListItem Value="1年">9年</asp:ListItem>
                                     <asp:ListItem Value="1年">10年</asp:ListItem>
                                    <asp:ListItem Value="1年">10年以上</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>出生年月</label>
                                <asp:TextBox ID="txtBirth" runat="server" class="form-control " t="txt" n="1" onclick="WdatePicker({dateFmt:'yyyy.MM'})" MaxLength="10" placeholder="点击选择时间"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>邮箱</label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" t="Email" n="1" MaxLength="20" placeholder="输入邮箱，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>城市</label>
                                <asp:TextBox ID="txtCity" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="选择城市"></asp:TextBox>
                            </div>
                            <%--<div class="form-group">
                                <label>状态</label>
                                <asp:Literal ID="ltlFlag" runat="server"></asp:Literal>
                            </div>
                            <div class="form-group">
                                <label>认证图片</label>
                                <asp:Image ID="imgAuthImg" runat="server" />
                            </div>--%>
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
