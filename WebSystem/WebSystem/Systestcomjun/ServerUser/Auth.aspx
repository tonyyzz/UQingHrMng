﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auth.aspx.cs" Inherits="WebSystem.Systestcomjun.ServerUser.Auth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
    <script src="../js/My97DatePicker/WdatePicker.js"></script>
    <!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->
</head>
<body style="padding-top: 15px;">
    <form id="form1" runat="server">
     <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        职业介绍人身份认证
                    </div>
                    <div class="panel-body">
                        <div class="col-md-3">
                             <div class="form-group">
                                 <label>营业执照</label>
                                <asp:Image ID="img_Idcard" runat="server" Width ="423px" />
                             </div>
                        </div>
                        <div class="col-md-3">
                             <%--<div class="form-group">
                                  <label>职业身份认证</label>
                                <asp:Image ID="img_SerImg" runat="server" Width ="423px"/>
                             </div>--%>
                            <%--<div class="col-md-12" style="text-align: center;">--%>
                            <asp:Button ID="btnSerImg" runat="server" Text="通过认证" CssClass="btn btn-primary btn_Save" OnClientClick="return confirm('确定要通过认证吗？')"  Width="100px" OnClick="btnSerImg_Click" />
                            <asp:Button ID="btnSerbh" runat="server" Text="不通过" CssClass="btn btn-warning btn_Save" OnClientClick="return confirm('确定要驳回认证吗？')"  Width="100px" OnClick="btnSerbh_Click" />
                            <%--</div>--%>
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
            
        </script>
    </form>
</body>
</html>
