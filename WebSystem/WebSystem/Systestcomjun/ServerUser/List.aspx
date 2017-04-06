<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebSystem.Systestcomjun.ServerUser.List" %>

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
                <li class="active">人才经纪人管理</li>
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
                    <div class="panel-heading">人才经纪人管理</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <a href="SerUserPost.aspx" class="btn btn-primary">人才经纪人职位</a>
                            <a href="javascript:;" class="btn btn-primary" name="add" >添加</a>
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClientClick="return comfirm('确定要删除吗？')" OnClick="btndel_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtkey" class="searchtxt" runat="server" placeholder="手机或姓名"></asp:TextBox>
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:DropDownList ID="ddlauth" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">认证状态</asp:ListItem>
                                <asp:ListItem Value="0">未认证</asp:ListItem>
                                <asp:ListItem Value="1">待审核</asp:ListItem>
                                <asp:ListItem Value="2">已认证</asp:ListItem>
                                <asp:ListItem Value="3">已驳回</asp:ListItem>
                            </asp:DropDownList>
                        </div>
						<div class="pull-right search" style="padding-right: 10px;">
                            <asp:DropDownList ID="ddTimeOrder" runat="server" CssClass="form-control">
                                
                                <asp:ListItem Value="1">注册时间_倒序</asp:ListItem>
								<asp:ListItem Value="2">注册时间_正序</asp:ListItem>
                                <asp:ListItem Value="3">职位发布时间_倒序</asp:ListItem>
                                <asp:ListItem Value="4">职位发布时间_正序</asp:ListItem>
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
                                        <th>头像</th>
                                        <th>姓名</th>
                                        <th>手机号码</th>
                                        <th>性别</th>
                                        <th>行业</th>
                                        <th>公司</th>
                                        <th>职位</th>
                                        <th>工作地区</th>
                                        <th>邮箱</th>
                                        <th>身份认证</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("SerUserID") %>' />
                                            </td>
                                            <td><img src="<%#Eval("PhotoImg").ToString()==""?"/images/admin/zw.png":Eval("PhotoImg") %>" width="40"  /></td>
                                            <td>ID:<%#Eval("SerUserID") %>.<%#Eval("RealName") %></td>
                                            <td><%#Eval("Phone") %></td>
                                            <td><%#Eval("Sex").ToString()=="True"?"男":"女" %></td>
                                            <td><%#Eval("Trade") %></td>
                                            <td><%#Eval("Company") %></td>
                                            <td><%#Eval("Position") %></td>
                                            <td><%#Eval("WorkCity") %></td>
                                            <td><%#Eval("Email") %></td>
                                            <td><%#authstate(Eval("Flag").ToString())%></td>
                                            <td>
                                                <a href="javascript:;" name="edit">编辑</a>
                                                <a href="javascript:;" name="resume">更多信息</a>
                                                <a href="javascript:;" name="auth">认证</a>
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
        <%--<script src="/Systestcomjun/js/pubfunction.js"></script>--%>
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


            $("a[name=add]").click(function () {
                layer.open({
                    title: "添加职业介绍人信息",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'add.aspx?'
                });
            });

            $("a[name=edit]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "修改职业介绍人信息",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'Edit.aspx?SerUserID=' + id
                });
            });

            $("a[name=resume]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "职业介绍人更多信息",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'More.aspx?SerUserID=' + id
                });
            });

            $("a[name=auth]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "职业介绍人认证",
                    type: 2,
                    area: ['500px', '730px'],
                    fix: false, //不固定
                    content: 'Auth.aspx?SerUserID=' + id
                });
            });

        </script>
    </form>
</body>
</html>
