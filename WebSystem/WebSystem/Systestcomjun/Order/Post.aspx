<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="WebSystem.Systestcomjun.Order.Post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />

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
                        匹配职位
                    </div>
                    <div class="panel-body">
                        <table class="table table-bordered table-hover definewidth m10">
                            <tr>
                                <td class="tableleft" width="20%">职业介绍人：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlRealName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">推荐公司：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlCompany" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">所属行业：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlTrade" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司规模：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlScale" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司类型：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlNature" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">岗位名称：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlPostName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">岗位职责：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlPostDuty" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">提供待遇：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlSalary" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">发展前景描述：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlDevelopProspect" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">直接领导：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlDirectLeader" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">工作地点：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlWorkAdress" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">办公地址：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlAdress" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">提供福利：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlWelfareTag" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司配套环境：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlCompanyMatching" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">其他卖点：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlOtherPoint" runat="server"></asp:Literal>
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
