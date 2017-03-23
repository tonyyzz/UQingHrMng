<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebSystem.Systestcomjun.Role.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-6">

                            <div class="form-group">
                                <label>角色名称</label>
                                <asp:TextBox ID="txtRoleName" runat="server" class="form-control" t="txt" n="1" MaxLength="10" placeholder="输入角色名称，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>权限</label>
                                <asp:CheckBoxList ID="chklist" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="60%">
                                    <asp:ListItem Value="1">系统设置</asp:ListItem>
                                    <asp:ListItem Value="2">用户管理</asp:ListItem>
                                    <asp:ListItem Value="3">角色管理</asp:ListItem>
                                    <asp:ListItem Value="4">求职者管理</asp:ListItem>
                                    <asp:ListItem Value="5">人才经济人管理</asp:ListItem>
                                    <asp:ListItem Value="6">职场攻略</asp:ListItem>
                                    <asp:ListItem Value="7">职位信息</asp:ListItem>
                                    <%--<asp:ListItem Value="8">申述管理</asp:ListItem>--%>
                                    <asp:ListItem Value="9">热点推荐</asp:ListItem>
                                    <asp:ListItem Value="10">订单管理</asp:ListItem>
                                    <asp:ListItem Value="11">提现申请</asp:ListItem>
                                    <asp:ListItem Value="12">提现支付</asp:ListItem>
                                    <asp:ListItem Value="13">日志管理</asp:ListItem>
                                    <asp:ListItem Value="14">合作伙伴</asp:ListItem>
                                    <asp:ListItem Value="15">首页管理</asp:ListItem>
                                    <asp:ListItem Value="16">统计页面</asp:ListItem>
                                    <asp:ListItem Value="17">职位类型</asp:ListItem>
                                    <asp:ListItem Value="18">渠道招商</asp:ListItem>
                                    <asp:ListItem Value="19">用户反馈</asp:ListItem>
                                </asp:CheckBoxList>
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
