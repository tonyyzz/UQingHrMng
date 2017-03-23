<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebSystem.Systestcomjun.ChannelCnvestment.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                <li class="active">渠道招商</li>
            </ol>
        </div>
        <!--/.row-->

        <%--<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Tables</h1>
			</div>
		</div><!--/.row-->--%>


        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">渠道招商</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClick="btndel_Click" />
                           
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtCPTitle" class="searchtxt" runat="server" placeholder="输入标题"></asp:TextBox>
                        </div>

                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>公司全称</th>
                                        <th>公司地址</th>
                                        <th>联系人</th>
                                        <th>联系电话</th>
                                        <th>邮箱</th>
                                        <th>主营业务</th>
                                        <th>意向代理城市</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("ID") %>' />
                                            </td>
                                            <td><%#Eval("Company") %></td>
                                            <td><%#Eval("Address") %></td>
                                            <td><%#Eval("LinkMan") %></td>
                                            <td><%#Eval("Phone") %></td>
                                            <td><%#Eval("Email") %></td>
                                            <td><%#Eval("MainBusiness") %></td>
                                            <td><%#Eval("City") %></td>
                                            <td>
                                                 <a href="javascript:;" name="detail">详情</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <div class="panel-body " style="">
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="False" CssClass="pagination" LayoutType="div" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="10" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True">
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

            $("#btnadd").click(function () {
                layer.open({
                    title: "新增",
                    type: 2,
                    area: ['1000px', '730px'],
                    fix: false, //不固定
                    content: 'Add.aspx'
                });
            });
            $("a[name=detail]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "详情",
                    type: 2,
                    area: ['1000px', '730px'],
                    fix: false, //不固定
                    content: 'Detail.aspx?ID=' + id
                });
            });

        </script>
    </form>
</body>
</html>
