<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebSystem.Systestcomjun.Person.List" %>

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
                <li class="active">求职者管理</li>
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
                    <div class="panel-heading">求职者管理</div>
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
                                        <th>头像</th>
                                        <th>姓名</th>
                                        <th>手机号码</th>
                                        <th>性别</th>
                                        <th>学历</th>
                                        <th>工作年限</th>
                                        <th>出生年月</th>
                                        <th>邮箱</th>
                                        <th>城市</th>
                                        <%--<th>状态</th>--%>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("PerID") %>' />
                                            </td>
                                            <td><img src="<%#Eval("Photo").ToString()==""?"/images/admin/zw.png":Eval("Photo") %>" width="40" /></td>
                                            <td><%#Eval("RealName") %></td>
                                            <td><%#Eval("Phne") %></td>
                                            <td><%#Eval("Sex").ToString()=="True"?"男":"女" %></td>
                                            <td><%#Eval("Education") %></td>
                                            <td><%#Eval("WorkLife") %></td>
                                            <td><%#Eval("Birth") %></td>
                                            <td><%#Eval("Email") %></td>
                                            <td><%#Eval("City") %></td>
                                            <%--<td><%#strFlag(Eval("Flag").ToString())%></td>--%>
                                            <td>
                                                <a href="javascript:;" name="edit">编辑</a>
                                                <a href="javascript:;" name="resume">简历</a>
                                                <%--<a href="javascript:;" name="auth">认证</a>--%>
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

           
       
            $("a[name=edit]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "修改求职者信息",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'Add.aspx?PerID=' + id
                });
            });

            $("a[name=resume]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "求职者简历",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'Resume.aspx?PerID=' + id
                });
            });

            $("a[name=auth]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "求职者认证",
                    type: 2,
                    area: ['500px', '530px'],
                    fix: false, //不固定
                    content: 'Auth.aspx?PerID=' + id
                });
            });
            
        </script>
    </form>
</body>
</html>
