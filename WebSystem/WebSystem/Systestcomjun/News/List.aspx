<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebSystem.Systestcomjun.News.List" %>

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
                <li class="active">热点推荐</li>
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
                    <div class="panel-heading">热点推荐</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <input type="button" class="btn btn-primary" id="btnadd" value="新增" />
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClick="btndel_Click" />
                            <input type="button" class="btn btn-warning" id="btnNewsType" value="热点推荐类型管理" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtTitle" class="searchtxt" runat="server" placeholder="输入热点推荐标题"></asp:TextBox>
                        </div>

                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th><input type="checkbox" id="chkall"  /></th>
                                        <th>图片</th>
                                        <th>标题</th>
                                        <th>类型</th>
                                        <th>是否热门</th>
                                        <th>添加时间</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server" >
                                    <ItemTemplate>
                                        <tr>
                                            <td><asp:CheckBox ID="chkid" runat="server" name="subBox"  />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("NewsID") %>' />
                                            </td>
                                            <td><img src='<%#Eval("ImgUrl").ToString()==""?"/images/admin/noimg.jpg":Eval("ImgUrl") %>' width="60"/></td>
                                            <td><%#Eval("Title") %></td>
                                            <td><%#Eval("Name") %></td>
                                            <td><%#Eval("Hot").ToString()=="True"?"是":"否" %></td>
                                            <td><%#Eval("CreateTime") %></td>
                                            <td>
                                               <a href="javascript:;" name="edit">编辑</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <div class="panel-body " style="">
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="false" CssClass="pagination" LayoutType="div" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True">
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
            $("a[name=edit]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "修改",
                    type: 2,
                    area: ['1000px', '730px'],
                    fix: false, //不固定
                    content: 'Add.aspx?NewsID=' + id
                });
            });
            $("#btnNewsType").click(function () {
                layer.open({
                    title: "热点推荐类型",
                    type: 2,
                    area: ['700px', '530px'],
                    fix: false, //不固定
                    content: 'NewsType.aspx'
                });
            });
        </script>
    </form>
</body>
</html>
