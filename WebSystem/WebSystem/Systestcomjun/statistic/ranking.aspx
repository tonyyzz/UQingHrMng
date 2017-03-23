<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ranking.aspx.cs" Inherits="WebSystem.Systestcomjun.statistic.ranking" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet">
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet">
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet">
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
                <li class="active">统计页面</li>
            </ol>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                                        <div class="panel-heading"><a href="jobseeker.aspx">求职者统计</a>&nbsp;&nbsp;&nbsp;<a href="Completiondegree.aspx">完成度统计</a>&nbsp;&nbsp;&nbsp;<a href="broker.aspx">经纪人统计</a>&nbsp;&nbsp;&nbsp;<a href="turnover.aspx">成交量统计</a>&nbsp;&nbsp;&nbsp;<a href="ranking.aspx">经纪人排行统计</a></div>
                    <div class="panel-body">
                        <div class="col-md-6">
                            <table>
                          
                                <asp:Repeater ID="binding" runat="server" >
                                    <ItemTemplate>
                                        <tr style="line-height:50px;"><td >用户名：</td><td><%#Eval("RealName") %></td><td>&nbsp;&nbsp;&nbsp;&nbsp;联系电话：</td><td><%#Eval("Phone") %></td><td>&nbsp;&nbsp;&nbsp;&nbsp;成交数量</td><td><%#Eval("counts") %></td></tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                     
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <!-- /.row -->
        </div>
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <script src="/Systestcomjun/js/pubfunction.js"></script>
        <script type="text/javascript">
            $(function () {
                $(".fuxuan").find("input[type=checkbox]").click(function () {
                    if ($(".fuxuan").find("input[type=checkbox]:checked").length < 1) {
                        $(this).prop("checked", true);
                        showmsg('文件格式', '至少选中一种图片格式', '', 2);
                    }
                });
            })
        </script>
    </form>
</body>
</html>

