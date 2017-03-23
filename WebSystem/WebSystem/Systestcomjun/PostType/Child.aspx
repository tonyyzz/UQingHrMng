<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Child.aspx.cs" Inherits="WebSystem.Systestcomjun.PostType.Child" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
    <script language="javascript" charset="utf-8" src="/keditor/kindeditor.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/lang/zh_CN.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/plugins/code/prettify.js"></script>
</head>
<body style="padding-top: 15px;">
    <form id="form1" runat="server">
    <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">职位类型子类</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <input type="button" class="btn btn-primary" id="btnadd" value="新增" />
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClick="btndel_Click" />
                            <asp:Button ID="btnSaveSort" runat="server" Text="保存排序" CssClass="btn btn-warning" OnClick="btnSaveSort_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtkey" class="searchtxt" runat="server" placeholder="输入标题"></asp:TextBox>
                        </div>

                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>类型名称</th>
                                        <th>排序</th>
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
                                            <td><%#Eval("PostTypeName") %></td>
                                            <td>
                                                <asp:TextBox ID="txtSort" runat="server" class="form-control" t="int" n="1" MaxLength="5" Text='<%#Eval("Sort") %>' Width="50px"></asp:TextBox></td>
                                            <td>
                                                <a href="javascript:;" name="edit">编辑</a>
                                                 <a href="javascript:;" name="post">职位</a>
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
            var PID = '<%=PID%>';
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
                    content: 'Add.aspx?PID='+PID
                });
            });
            $("a[name=edit]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "修改",
                    type: 2,
                    area: ['1000px', '730px'],
                    fix: false, //不固定
                    content: 'Add.aspx?ID=' + id
                });
            });
            $("a[name=post]").click(function () {
                var id = $(this).parent().parent().find("input[type=hidden]").val();
                layer.open({
                    title: "修改",
                    type: 2,
                    area: ['900px', '630px'],
                    fix: false, //不固定
                    content: '../PostInfo/List.aspx?TID=' + id
                });
            });
        </script>
    </form>
</body>
</html>
