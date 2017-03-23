<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="WebSystem.Systestcomjun.FeedBack.Detail" %>

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
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
     <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        反馈详情
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div style="width:100%;">
                                    <asp:Literal ID="ltlCon" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                        <%--<div class="col-md-12" style="text-align: center;">--%>
                        <asp:Button ID="btnsave" runat="server" Text="未阅" class="btn btn-primary btn_Save" OnClick="btnsave_Click" Width="100px" />
                        <%--</div>--%>
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
    </form>
</body>
</html>
