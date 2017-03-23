<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Representations.aspx.cs" Inherits="WebSystem.Systestcomjun.Person.Representations" %>

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
                <li class="active">申述管理</li>
            </ol>
        </div>
        <!--/.row-->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">申述管理</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <%--<input type="button" class="btn btn-primary" id="btnadd" value="新增职业培训单位" />--%>
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClientClick="return comfirm('确定要删除吗？')" OnClick="btndel_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtkey" class="searchtxt" runat="server" placeholder="手机或姓名"></asp:TextBox>
                        </div>

                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>申诉人</th>
                                        <th>手机号码</th>
                                        <th>性别</th>
                                        <th>申述订单</th>
                                        <th>金额</th>
                                        <th>申述理由</th>
                                        <th>申述时间</th>
                                        <th>申述状态</th>
                                        <th>状态</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("ID") %>' />
                                            </td>
                                            <td><%#Eval("RealName") %></td>
                                            <td><%#Eval("Phne") %></td>
                                            <td><%#Eval("Sex").ToString()=="True"?"男":"女" %></td>
                                            <td><%#Eval("OrderNum") %></td>
                                            <td>
                                                <span style="color:blue;"><asp:Literal ID="ltlmoney" runat="server" Text='<%#Eval("RewardMoney") %>'></asp:Literal></span>
                                            </td>
                                            <td><%#Eval("Reason") %></td>
                                            <td><%#Eval("CreateTime") %></td>
                                            <td><%#Eval("State") %></td>
                                            <td><%#Eval("City") %></td>
                                            <td>
                                                <asp:LinkButton ID="btnsh" Visible='<%#Eval("State").ToString()=="1"?true:false %>' CommandArgument='<%#Eval("ID") %>' CommandName="auth" runat="server">通过</asp:LinkButton>
                                                <asp:LinkButton ID="btnbh" Visible='<%#Eval("State").ToString()=="1"?true:false %>' CommandArgument='<%#Eval("ID") %>' CommandName="bohui" runat="server">驳回</asp:LinkButton>
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
        </script>
    </form>
</body>
</html>
