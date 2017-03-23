<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="WebSystem.Systestcomjun.ChannelCnvestment.Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />

    <!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->
</head>
<body  style="padding-top: 15px;">
    <form id="form1" runat="server">
    <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        渠道招商详情
                    </div>
                    <div class="panel-body">
                        <table class="table table-bordered table-hover definewidth m10">
                            <tr>
                                <td class="tableleft" width="20%">公司全称：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlCompany" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司地址：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlAddress" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">联系人：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlLinkMan" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">联系电话：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlPhone" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">邮箱：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">主营业务：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlMainBusiness" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">意向代理城市：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlCity" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">团队规模：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlTeamSize" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">主要优势：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlMainAdvantage" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            
                        </table>
                    </div>
                    <!-- /.col-->
                </div>
                <!-- /.row -->
            </div>
        </div>
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <script src="/Systestcomjun/js/pubfunction.js"></script>
    </form>
</body>
</html>
