<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsType.aspx.cs" Inherits="WebSystem.Systestcomjun.News.NewsType" %>

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
<body style="padding-top: 15px;">
    <form id="form1" runat="server">
    <%--<div class="row">
            <ol class="breadcrumb">
                <li><a href="#"><span class="glyphicon glyphicon-home"></span></a></li>
                <li class="active">用户管理</li>
            </ol>
        </div>--%>
        <!--/.row-->

        <%--<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Tables</h1>
			</div>
		</div><!--/.row-->--%>


        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">热门推荐类型管理</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <%--<input type="button" class="btn btn-primary" id="btnadd" value="新增内容" />--%>
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClick="btndel_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="新增" CssClass="btn btn-primary" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtTitle" class="searchtxt" runat="server" placeholder="输入类型名称"></asp:TextBox>
                        </div>

                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th><input type="checkbox" id="chkall"  /></th>
                                        <th>类型名称</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                                    <ItemTemplate>
                                        <tr>
                                            <td><asp:CheckBox ID="chkid" runat="server" name="subBox"  />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("NewsTypeID") %>' />
                                            </td>
                                            <td><span><%#Eval("Name") %></span>
                                                <asp:TextBox ID="txtName" runat="server" style="display:none;" CssClass="searchtxt"></asp:TextBox>
                                            </td>
                                            <td>
                                               <a href="javascript:;" name="edit">编辑</a>
                                                <asp:LinkButton ID="btnsa" CommandArgument='<%#Eval("NewsTypeID") %>' CommandName="save" runat="server" style="display:none;">保存</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <div class="panel-body " style="">
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="false" CssClass="pagination" LayoutType="div" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True" NumericButtonCount="3">
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
                $("a[name=edit]").click(function(){
                    var td= $(this).parent().prev();
                    $(td).find("span").hide();
                    $(td).find("input").val($(td).find("span").html());
                    $(td).find("input").show();
                    $(this).hide();
                    $(this).next().show();
                });
            });

            
        </script>
    </form>
</body>
</html>
