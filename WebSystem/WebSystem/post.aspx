<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="WebSystem.post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=title %></title>
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="css/aui.2.css" rel="stylesheet" />
    <link href="css/iconfont/iconfont.css" rel="stylesheet" />
    <style>
        * {
            -webkit-sizing: border-box;
            box-sizing: border-box;
            -webkit-user-select: text;
            -moz-user-select: text;
            -o-user-select: text;
            user-select: text;
            -webkit-tap-highlight-color: transparent;
            outline: none;
        }
        .jobBasic {
            background-color: #fff;
            padding: 1rem;
        }

            .jobBasic div {
                line-height: 2rem;
            }

        .jobDes {
            margin-top: 1rem;
            background-color: #fff;
            padding: 0.5rem;
        }

        .jobAddress {
            margin-top: 1rem;
            background-color: #fff;
            padding: 0.5rem;
            margin-bottom: 3rem;
        }

        .aui-bar-nav {
            background-color: #00b38a;
            position: fixed;
            top: 0;
        }

        .jobAddress_Title {
            font-size: 1rem;
            margin-bottom: 0.3rem;
            width: 100%;
            border-bottom: 1px solid #ede6e6;
            padding-bottom: 0.5rem;
        }

        .aui-list-view li {
            position: relative;
            padding: 11px 15px;
            overflow: hidden;
        }

            .aui-list-view li:before {
                content: '';
                width: 0.4rem;
                height: 0.4rem;
                position: absolute;
                top: 50%;
                right: 0.75rem;
                margin-top: -0.2rem;
                background: transparent;
                border: 1px solid #dddddd;
                border-top: none;
                border-right: none;
                z-index: 2;
                -webkit-border-radius: 0;
                border-radius: 0;
                -webkit-transform: rotate(-135deg);
                transform: rotate(-135deg);
            }

            .aui-list-view li img {
                margin-right: 0.75rem;
                max-width: 2.6rem !important;
                height: 2.6rem;
                line-height: 48px !important;
                border-radius: 50%;
                float: left;
                position: relative;
                overflow: hidden;
            }

        .aui-img-body {
            position:relative;
            overflow: hidden;
            font-size: 0.7rem;
            line-height: 1.2rem;
        }

            .aui-img-body > em {
                font-weight: 400;
                font-size: 0.7rem;
                color: #8f8f94;
                float: right;
                display: block;
            }

        .content-box {
            margin-top: 0.5rem;
            padding: 0 0.5rem;
        }

            .content-box > div {
                background-color: #fff;
                padding: 0.5rem;
                border-radius: 8px;
                margin-bottom: 0.5rem;
            }

                .content-box > div p {
                }

                .content-box > div span {
                    display: inline-block;
                    margin-right: 0.8rem;
                    position: relative;
                    padding: 2px 0 2px 20px;
                }

                    .content-box > div span i {
                        position: absolute;
                        width: 16px;
                        height: 24px;
                        top: 0px;
                        left: 0px;
                        display: inline-block;
                        margin-right: 3px;
                        color: #53cac3;
                    }

                .content-box > div pre {
                    width: 100%;
                    color: #757575;
                    font-size: 0.7rem;
                    margin: 0;
                    white-space: pre-wrap; /* css-3 */
                    white-space: -moz-pre-wrap; /* Mozilla, since 1999 */
                    white-space: -pre-wrap; /* Opera 4-6 */
                    white-space: -o-pre-wrap; /* Opera 7 */
                    word-wrap: break-word; /* Internet Explorer 5.5+ */
                }

        .title {
            font-size: 0.9rem;
            color: #53cac3;
            padding-left: 0 !important;
        }

            .title span {
                padding-left: 0 !important;
            }

        .Salary, .Salary i {
            color: #FB4A06 !important;
            float: right;
            font-size: 16px;
            font-family: "Microsoft YaHei";
        }

        .jobBasic div {
            line-height: 1.4rem;
        }

        .jobDes {
            margin-top: 1rem;
            background-color: #fff;
            padding: 0.5rem 1rem;
        }

        .jobAddress {
            margin-top: 1rem;
            background-color: #fff;
            padding: 0.5rem 1rem;
            margin-bottom: 3rem;
        }

        .aui-bar-nav {
            background-color: #00b38a;
            position: fixed;
            top: 0;
        }

        .jobAddress_Title {
            margin-bottom: 0.5rem;
            width: 100%;
            border-bottom: 1px solid #ede6e6;
            padding-bottom: 0.5rem;
        }

        .reward {
            width: 100%;
            background-color: #00b38a;
            line-height: 1.5rem;
            color: #fff;
            text-align: center;
            position: fixed;
            bottom: 0;
        }

        .wenben .edit {
            position: absolute;
            right: 0.5rem;
            top: 0;
            z-index: 999;
        }

        .operation {
            overflow: hidden;
        }

            .operation li {
                float: left;
                width: 50%;
            }

        #goReward {
            position: fixed;
            bottom: 0;
            z-index: 999;
            line-height: 2rem;
            height: 2rem;
            text-align: center;
            width: 100%;
            background: #00b38a;
            color: #fff;
        }

        #OtherPoint {
            color: #A5A5A5;
        }
        .donwload{
            position:fixed;
            bottom:0;
            left:0;
            width:100%;
            padding:0.5rem 0;
            background-color:#242424;
        }
        .donwload img{
            width:100%;
            vertical-align:middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="content-box">
                <div class="position-info">
                    <p><span id="PostName" class="title">
                        岗位名称 <asp:Literal ID="ltlPostName" runat="server"></asp:Literal></span>
                        <span class="Salary"><!--<i class="icon iconfont icon-yang" style="top:-2px;"></i>--><em id="Salary">面议<asp:Literal ID="ltlSalary" runat="server"></asp:Literal></em></span></p>
                    <p>
                        <span class="WorkAdress"><i class="icon iconfont icon-chengshiicon" style="top: -2px;"></i><em id="WorkAdress">工作城市<asp:Literal ID="ltlWorkAddress" runat="server"></asp:Literal></em></span>
                        <span class="Trade"><i class="icon iconfont icon-job" style="top: -1px;"></i><em id="Trade">所属行业<asp:Literal ID="ltlTrade" runat="server"></asp:Literal></em></span>
                    </p>
                    <p>
                        <em id="OtherPoint"><asp:Literal ID="ltlOtherPoint" runat="server"></asp:Literal></em>
                    </p>
                </div>
                <%--<div class="SerInfo" onclick="managerDetail(id)">
                    <ul class="aui-list-view">
                        <li class="aui-user-view-cell aui-img">
                            <div class="aui-swipe-handle">
                                <img class="fl" id="PhotoImg">
                                <div class="aui-img-body">
                                    <span id="RealName"></span>
                                    <p id="SerCompany" class="aui-ellipsis-1"></p>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>--%>
                <div class="position-description">
                    <p class="title"><span id="Span1">岗位职责</span></p>
                    <pre id="PostDuty"><asp:Literal ID="ltlPostDuty" runat="server"></asp:Literal></pre>
                </div>
                <div class="company-info">
                    <p class="title"><span id="Span2">公司信息</span></p>
                    <p><span><i class="icon iconfont icon-renzheng1" style="top: -2px;"></i><em id="Company"><asp:Literal ID="ltlCompany" runat="server"></asp:Literal></em></span></p>
                    <p>
                        <span><i class="icon iconfont" style="font-size: 15px; top: 1px;">&#xe685;</i><em id="Nature"><asp:Literal ID="ltlNature" runat="server"></asp:Literal></em></span>
                        <span><i class="icon iconfont icon-haoyou1" style="font-size: 18px;"></i><em id="Scale"><asp:Literal ID="ltlScale" runat="server"></asp:Literal></em></span>
                    </p>
                    <p><span><i class="icon iconfont icon-loudong01" style="font-size: 18px; top: -1px;"></i><em id="Address"><asp:Literal ID="ltlAddress" runat="server"></asp:Literal></em></span></p>
                    <div><span><i class="icon iconfont icon-yishengjianjiejianjie" style="font-size: 18px; top: -1px;"></i>
                        <pre id="DevelopProspect"><asp:Literal ID="ltlDevelopProspect" runat="server"></asp:Literal></pre>
                    </span></div>
                </div>
                <div class="conpany-boon">
                    <p class="title"><span>福利待遇</span></p>
                    <!--<p><span><i class="icon iconfont icon-fuli" style="top:-2px;"></i><em id="WelfareTag">待完善公司福利</em></span></p>-->
                    <p><span><i class="icon iconfont icon-7taocanpeifang" style="top: -2px;"></i><em id="CompanyMatching"><asp:Literal ID="ltlCompanyMatching" runat="server"></asp:Literal></em></span></p>
                    <!--<p><span><i class="icon iconfont icon-youshiqingqiao" style="top:-1px;"></i></span></p>-->
                </div>
                <div class="conpanyImg" >
                    <p class="title"><span>办公环境</span></p>
                    <asp:Image ID="ComImg" runat="server" style="width: 100%;" />
                    <%--<img class="ComImg" style="width: 100%;" />--%>
                </div>
            </div>
        </div>
        <div class="donwload" onclick="downApp()">
            <img src="/images/logo.gif" />
        </div>
        <div style="margin-bottom:4.25rem"></div>
    </form>
    <script>
        function downApp() {
            alert(navigator.userAgent);
            if (/(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent)) {
                window.open("https://itunes.apple.com/us/app/storybear/id1166468091");
            } else if (/(Android)/i.test(navigator.userAgent)) {
                window.open("http://a.app.qq.com/o/simple.jsp?pkgname=com.x461441451.own");
            }
        }
    </script>
</body>
</html>
