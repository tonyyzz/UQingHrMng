<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Batch.aspx.cs" Inherits="WebSystem.Systestcomjun.PresentApplication.Batch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
            <ol class="breadcrumb">
                <li><a href="#"><span class="glyphicon glyphicon-home"></span></a></li>
                <li class="active">提现批次</li>
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
                    <div class="panel-heading">提现批次</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtkey" class="searchtxt" runat="server" placeholder="批次号"></asp:TextBox>
                        </div>

                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>批次号</th>
                                        <th>支付日期</th>
                                        <th>总金额</th>
                                        <th>总笔数</th>
                                        <th>支付状态</th>
                                        <th>支付人</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("BatchID") %>' />
                                            </td>
                                            <td>
                                               <%#Eval("Batch_No") %>
                                            </td>
                                            <td><%#Eval("Pay_Date") %></td>
                                            <td><%#Eval("Batch_Fee") %></td>
                                            <td><%#Eval("Batch_Num") %></td>
                                            <td><%#Eval("BatchState").ToString()=="0"?"未支付":Eval("BatchState").ToString()=="1"?"已支付":"支付失败" %></td>
                                            <td><%#Eval("PayAdminName") %></td>
                                            <td>
                                                <%--<asp:LinkButton ID="btnPay" CommandName="auth" CommandArgument='<%#Eval("BatchID") %>' Visible='<%#Eval("BatchState").ToString()=="0"?true:false %>' runat="server">支付</asp:LinkButton>--%>
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
            $.post("/App/PostAjax.ashx", { action: "ddd" }, function (data) {
                alert(data);
            });
            $.get("/App/PostAjax.ashx", { action: "ccc" }, function (data) {
                alert(data);
            });

        </script>
    </form>
</body>
</html>
