﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayList.aspx.cs" Inherits="WebSystem.Systestcomjun.PresentApplication.PayList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet"/>
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet"/>
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
                <li class="active">提现申请</li>
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
                    <div class="panel-heading">提现申请</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <asp:Button ID="btnPay" runat="server" Text="批量支付" CssClass="btn btn-primary" OnClick="btnPay_Click" />
                            <a href="Batch.aspx" class="btn btn-primary">查看批次</a>
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClick="btndel_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtkey" class="searchtxt" runat="server" placeholder="提现申请人姓名"></asp:TextBox>
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:DropDownList ID="ddl_PreType" runat="server" CssClass="form-control">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="支付宝" Value="0"></asp:ListItem>
                                <%--<asp:ListItem Text="微信" Value="1"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:DropDownList ID="ddl_PayState" runat="server" CssClass="form-control">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="未支付" Value="1"></asp:ListItem>
                                <%--<asp:ListItem Text="已支付" Value="2"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>申请人姓名</th>
                                        <th>金额</th>
                                        <th>申请时间</th>
                                        <th>审核时间</th>
                                        <th>审核人</th>
                                        <th>支付状态</th>
                                        <th>提现类型</th>
                                        <%--<th>支付人</th>
                                        <th>支付时间</th>--%>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("ID") %>' />
                                                <asp:HiddenField ID="txtPreType" runat="server" Value='<%#Eval("PreType") %>' />
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltlrealname" runat="server" Text='<%#Eval("RealName") %>'></asp:Literal>
                                            </td>
                                            <td><%#Eval("Money") %></td>
                                            <td><%#Eval("CreateTime") %></td>
                                            <td><%#Eval("PassTime") %></td>
                                            <td><%#Eval("AdminName") %></td>
                                             <td><%#Eval("State").ToString()=="1"?"未支付":Eval("State").ToString()=="2"?"已支付":"支付失败" %></td>
                                            <td><%#Eval("PreType").ToString()=="0"?"支付宝":"微信" %></td>
                                            <%--<td><%#Eval("PayAdminName") %></td>
                                            <td><%#Eval("PayTime") %></td>--%>
                                            <td>
                                                <asp:LinkButton ID="btnPayFail" CommandName="payFail" CommandArgument='<%#Eval("ID") %>' Visible='false' runat="server">支付失败</asp:LinkButton>
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