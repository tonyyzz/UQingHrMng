<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostEdit.aspx.cs" Inherits="WebSystem.Systestcomjun.ServerUser.PostEdit" %>

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
    <style>
        .mat span {
            height: 20px;
            background: #a79f9f;
            margin: 10px 5px 10px 5px;
            padding: 5px 9px 5px 9px;
            cursor: pointer;
            color: white;
            -moz-user-select: none; /*火狐*/
            -webkit-user-select: none; /*webkit浏览器*/
            -ms-user-select: none; /*IE10*/
            -khtml-user-select: none; /*早期浏览器*/
            user-select: none;

        }
        .mat span.search {
            background:#2fa4fe;
        }
    </style>
</head>
<body  style="padding-top: 15px;">
    <form id="form1" runat="server">
     <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        职位信息
                    </div>
                    <div class="panel-body">
                        <table class="table table-bordered table-hover definewidth m10">
                            <tr>
                                <td class="tableleft" width="20%">人才经纪人ID：
                                </td>
                                <td>
                                   <asp:TextBox ID="txtSerUserID" runat="server" class="form-control" t="int" n="1" MaxLength="10" placeholder="人才经纪人ID，必填"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompany" runat="server"  class="form-control" t="txt" n="1" MaxLength="20" placeholder="公司名称，必填"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">所属行业：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTrade" runat="server" class="form-control">
                                        <asp:ListItem Value="计算机硬件">计算机硬件</asp:ListItem>
                                        <asp:ListItem Value="计算机软件">计算机软件</asp:ListItem>
                                        <asp:ListItem Value="互联网/电子商务">互联网/电子商务</asp:ListItem>
                                        <asp:ListItem Value="IT服务/系统集成">IT服务/系统集成</asp:ListItem>
                                        <asp:ListItem Value="通信/电信">通信/电信</asp:ListItem>
                                        <asp:ListItem Value="电子技术/半导体/集成电路">电子技术/半导体/集成电路</asp:ListItem>
                                        <asp:ListItem Value="保险/金融">保险/金融</asp:ListItem>
                                        <asp:ListItem Value="贸易/进出口">贸易/进出口</asp:ListItem>
                                        <asp:ListItem Value="快速消费品">快速消费品</asp:ListItem>
                                        <asp:ListItem Value="生物/制药/医疗器械">生物/制药/医疗器械</asp:ListItem>
                                        <asp:ListItem Value="钢铁/机械">钢铁/机械</asp:ListItem>
                                        <asp:ListItem Value="广告/媒体">广告/媒体</asp:ListItem>
                                        <asp:ListItem Value="医疗·化工">医疗·化工</asp:ListItem>
                                        <asp:ListItem Value="教育/培训">教育/培训</asp:ListItem>
                                        <asp:ListItem Value="交通/运输/物流">交通/运输/物流</asp:ListItem>
                                        <asp:ListItem Value="餐饮/酒店/娱乐">餐饮/酒店/娱乐</asp:ListItem>
                                        <asp:ListItem Value="政府/非盈利机构">政府/非盈利机构</asp:ListItem>
                                        <asp:ListItem Value="中介/专业服务">中介/专业服务</asp:ListItem>
                                        <asp:ListItem Value="不限行业">不限行业</asp:ListItem>
                                        <asp:ListItem Value="其他行业">其他行业</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">岗位名称：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPostName" runat="server" class="form-control" t="txt" n="1" MaxLength="20" placeholder="岗位名称，必填"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">薪资范围：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSalary" runat="server" class="form-control">
                                        <asp:ListItem Value="3k以下">3k以下</asp:ListItem>
                                        <asp:ListItem Value="3k-5k">3k-5k</asp:ListItem>
                                        <asp:ListItem Value="5k-10k">5k-10k</asp:ListItem>
                                        <asp:ListItem Value="10k以上">10k以上</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">工作城市：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtWorkAdress" runat="server" class="form-control" t="txt" n="1" MaxLength="20" placeholder="工作城市，必填"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司环境：
                                </td>
                                <td>
                                    <asp:Image ID="imgcom" runat="server" width="300px"/>
                                    <asp:FileUpload ID="upImgCom" runat="server" onchange="onFileChange(this)"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司规模：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlScale" runat="server" class="form-control">
                                        <asp:ListItem Value="少于50人">少于50人</asp:ListItem>
                                        <asp:ListItem Value="50-150人">50-150人</asp:ListItem>
                                        <asp:ListItem Value="150-500人">150-500人</asp:ListItem>
                                        <asp:ListItem Value="500-1000人">500-1000人</asp:ListItem>
                                        <asp:ListItem Value="1000-5000人">1000-5000人</asp:ListItem>
                                        <asp:ListItem Value="5000人以上">5000人以上</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">公司性质：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlNature" runat="server"  class="form-control">
                                         <asp:ListItem Value="民营公司">民营公司</asp:ListItem>
                                        <asp:ListItem Value="国企">国企</asp:ListItem>
                                        <asp:ListItem Value="合资">合资</asp:ListItem>
                                        <asp:ListItem Value="外资">外资</asp:ListItem>
                                        <asp:ListItem Value="政府机关">政府机关</asp:ListItem>
                                        <asp:ListItem Value="事业单位">事业单位</asp:ListItem>
                                        <asp:ListItem Value="上市公司">上市公司</asp:ListItem>
                                        <asp:ListItem Value="创业公司">创业公司</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">直接领导：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtDirectLeader" runat="server" t="txt" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">岗位职责：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPostDuty" runat="server"  TextMode="MultiLine" t="txt" class="form-control" Height="100px"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="tableleft" width="20%" >公司简介：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtDevelopProspect" runat="server" TextMode="MultiLine" t="txt" class="form-control" Height="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">发布时间：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtCreateTime" runat="server"  class="form-control " n="1" t="txt"  onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">点击量：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtSeeCount" runat="server" class="form-control" t="int" n="1" MaxLength="20" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">办公地址：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtAdress" runat="server" class="form-control" t="txt"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="tableleft" width="20%">公司福利：
                                </td>
                                <td>
                                    <asp:HiddenField ID="txtCompanyMatching" runat="server" />
                                    <asp:Literal ID="ltlCompanyMatching" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="tableleft" width="20%">其他优势：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtOtherPoint" runat="server" TextMode="MultiLine"  class="form-control" t="txt"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Button ID="btnsave" runat="server" Text="保存" class="btn btn-primary btn_Save" OnClick="btnsave_Click" Width="100px" />
                    <!-- /.col-->
                </div>
                <!-- /.row -->
            </div>
        </div>
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <script src="/Systestcomjun/js/pubfunction.js"></script>
        <script type="text/javascript">
            function search(e) {
                if ($(e).attr("s") == "1") {
                    $(e).attr("s","0")
                    $(e).removeClass("search");
                } else {
                    $(e).attr("s", "1")
                    $(e).addClass("search");
                }
                mat();
            }
            function mat() {
                var strMat = "";
                $(".mat .search").each(function () {
                    strMat += $(this).html() + ",";
                });
                if (strMat != "") {
                    strMat = strMat.substr(0,strMat.length-1);
                }
                $("#txtCompanyMatching").val(strMat);
            }

            function onFileChange(sender) {
                var filename = sender.value;
                if (filename == "") {
                    return "";
                }
                var ExName = filename.substr(filename.lastIndexOf(".") + 1).toUpperCase();

                var imgs = ["png","jpg","jpeg","bmp","gif"];
                if ($.inArray(ExName.toLowerCase(), imgs) >= 0) {
                    document.getElementById("imgcom").src = window.URL.createObjectURL(sender.files[0]);
                }
                else {
                    layer.open({
                        content: "不能上传这种格式的图片！",
                        icon: 2
                    });
                    sender.value = null;
                    return false;
                }

            }
        </script>
    </form>
</body>
</html>
