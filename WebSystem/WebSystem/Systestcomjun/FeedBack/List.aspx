<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebSystem.Systestcomjun.FeedBack.List" %>

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
                <li class="active">职场攻略</li>
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
                    <div class="panel-heading">职场攻略</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClick="btndel_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="已读" CssClass="btn btn-success" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" Text="未读" CssClass="btn btn-warning" OnClick="Button2_Click" />
                            <asp:Button ID="Button3" runat="server" Text="全部" CssClass="btn btn-primary" OnClick="Button3_Click" />
                            <asp:HiddenField ID="txtIsRead" runat="server" />
                        </div>
                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>反馈内容</th>
                                        <th>反馈时间</th>
                                        <th>反馈人</th>
                                        <th>用户类型</th>
                                        <th>是否已阅</th>
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
                                             <td><%#Eval("Con") %></td>
                                            <td><%#Eval("CreateTime") %></td>
                                            <td><%#Eval("UserName") %></td>
                                            <td><%#Eval("UserType").ToString()=="0"?"求职者":"经纪人" %></td>
                                            <td><%#Eval("State").ToString()=="0"?"<span style='color:red;'>未阅</span>":"<span style='color:green;'>已阅</span>" %></td>
                                            <td>
                                                <a href="javascript:;" name="edit">详情</a>
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
                    title: "修改",
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
