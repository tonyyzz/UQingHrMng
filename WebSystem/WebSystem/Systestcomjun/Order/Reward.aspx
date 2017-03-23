<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reward.aspx.cs" Inherits="WebSystem.Systestcomjun.Order.Reward" %>

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
<body  style="padding-top: 15px;">
    <form id="form1" runat="server">
         <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        人才悬赏
                    </div>
                    <div class="panel-body">
                        <table class="table table-bordered table-hover definewidth m10">
                            <tr>
                                <td class="tableleft" width="20%">求职者：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlRealName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">悬赏金额：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlRewardMoney" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">悬赏时间：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlRewardTime" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">从事行业：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlTrade" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司规模：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlCompanySize" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司性质：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlCompanyNature" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">从事岗位：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlEngagePost" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">薪资要求：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlDemandPay" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">学历：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlEducation" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">工作年限：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlWorkLife" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">期望工作地点：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlJobCity" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">其他福利要求：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlOtherDemand" runat="server"></asp:Literal>
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
                                <td class="tableleft" width="20%">其他要求描述：
                                </td>
                                <td>
                                    <asp:Literal ID="ltlOtherDemandDes" runat="server"></asp:Literal>
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
