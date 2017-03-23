<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auth.aspx.cs" Inherits="WebSystem.Systestcomjun.Order.Auth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
        <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
</head>
<body style="padding-top: 15px;">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        入职协议审核
                    </div>
                    <div class="panel-body">
                        <div class="col-md-6">
                            <table class="table table-bordered table-hover definewidth m10">
                                <tr>
                                    <td class="tableleft" width="30%">求职者：
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">悬赏金额：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlRewardMoney" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">悬赏时间：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlRewardTime" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">从事行业：
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">公司规模：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlCompanySize" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">公司性质：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlCompanyNature" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">从事岗位：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlEngagePost" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">薪资要求：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlDemandPay" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">期望工作地点：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlJobCity" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">其他福利要求：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlOtherDemand" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">公司配套环境：
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">其他要求描述：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlOtherDemandDes" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                            <div class="form-group">
                                <asp:Image ID="img_PerImg" runat="server" Width="323px" />
                            </div>
                            <%--<div class="col-md-12" style="text-align: center;">--%>

                            <%--</div>--%>
                        </div>
                        <div class="col-md-6">
                            <table class="table table-bordered table-hover definewidth m10">
                                <tr>
                                    <td class="tableleft" width="30%">职业介绍人：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlRealName" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">推荐公司：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlCompany" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">所属行业：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlTrade" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">公司规模：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlScale" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">公司类型：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlNature" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">岗位名称：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlPostName" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">岗位职责：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlPostDuty" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">提供待遇：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlSalary" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">发展前景描述：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlDevelopProspect" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">直接领导：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlDirectLeader" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">工作地点：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlWorkAdress" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">办公地址：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlAdress" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">提供福利：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlWelfareTag" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">公司配套环境：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlCompanyMatching" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tableleft" width="30%">其他卖点：
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlOtherPoint" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                            <div class="form-group">
                                <asp:Image ID="ing_SerUserImg" runat="server" Width="323px" />
                            </div>
                            <%--<div class="col-md-12" style="text-align: center;">--%>

                            <%--</div>--%>
                        </div>
                        <asp:Button ID="btnAuth" runat="server" Text="审核通过" CssClass="btn btn-primary btn_Save" OnClientClick="return confirm('确定要通过审核吗？')" OnClick="btnsave_Click" />
                        <asp:Button ID="btnNoAuth" runat="server" Text="不通过" CssClass="btn btn-warning btn_Save" OnClientClick="return confirm('确定要不通过审核吗？')" Width="100px" OnClick="btnPerbh_Click" />
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
