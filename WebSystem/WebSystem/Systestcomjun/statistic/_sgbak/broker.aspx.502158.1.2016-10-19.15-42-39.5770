<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="broker.aspx.cs" Inherits="WebSystem.Systestcomjun.statistic.broker" %>
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
                                <tr style="line-height:50px;"><td style="width:300px; ">游客级：</td><td><%=youke %>人</td></tr>
                                <tr style="line-height:50px;"><td style="width:300px;">信息完整的：</td><td><%=wanzheng %>人</td></tr>
                                <tr style="line-height:50px;"><td style="width:300px;">接单量：</td><td><%=chengjiao %>次</td></tr>
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
