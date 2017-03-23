<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="WebSystem.Systestcomjun.Order.OrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
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
                <li class="active">订单管理</li>
            </ol>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">订单管理</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClientClick="return comfirm('确定要删除吗？删除后数据不可恢复！')" OnClick="btndel_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtkey" class="searchtxt" runat="server" placeholder="订单编号/求职者/职业介绍人" Width="210px"></asp:TextBox>
                        </div>

                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>订单编号</th>
                                        <th>悬赏人</th>
                                        <th>悬赏职位</th>
                                        <th>悬赏金额</th>
                                        <th>人才经纪人</th>
                                        <th>匹配职位</th>
                                        <th>订单时间</th>
                                        <th>订单状态</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("OrderID") %>' />
                                            </td>
                                            <td><%#Eval("OrderNum") %></td>
                                            <td><%#Eval("RealName") %></td>
                                            <td><%#Eval("EngagePost") %></td>
                                            <td><%#Eval("RewardMoney") %></td>
                                            <td><%#Eval("SerRealName") %></td>
                                            <td><%#Eval("PostName") %></td>
                                             <td><%#Eval("CreateTime") %></td>
                                             <td><%#GetOrderState(Eval("OrderState").ToString()) %></td>
                                            <td>
                                                <a href="javascript:;" name="reward" num="<%#Eval("OrderID") %>">悬赏详情</a>
                                                <a href="javascript:;" name="post" num="<%#Eval("OrderID") %>">职位详情</a>
                                                <a href="javascript:;" name="auth" num="<%#Eval("OrderID") %>" s="<%#Eval("OrderState") %>">审核</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <div class="panel-body " style="">
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="false" CssClass="pagination" LayoutType="div" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="10" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <script src="/Systestcomjun/js/pubfunction.js"></script>
        <script type="text/javascript">

            $(function () {
                $("#chkall").click(function () {
                    $("span[name='subBox'] input[type=checkbox]").prop("checked", this.checked);
                });
                var $subBox = $("span[name='subBox'] input[type=checkbox]");
                $subBox.click(function () {
                    $("#chkall").prop("checked", $subBox.length == $("span[name='subBox'] input[type=checkbox]:checked").length ? true : false);
                });
            });
            $("a[name=reward]").click(function () {
                var id = $(this).attr("num");
                layer.open({
                    title: "悬赏详情",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'Reward.aspx?OrderID=' + id
                });
            });
            $("a[name=post]").click(function () {
                var id = $(this).attr("num");
                layer.open({
                    title: "匹配职位",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'Post.aspx?OrderID=' + id
                });
            });
            //$("a[name=auth][s!=2]").remove();
            $("a[name=auth]").click(function () {
                var id = $(this).attr("num");
                layer.open({
                    title: "入职协议审核",
                    type: 2,
                    area: ['1000px', '530px'],
                    fix: false, //不固定
                    content: 'Auth.aspx?OrderID=' + id
                });
            });
        </script>
    </form>
</body>
</html>
