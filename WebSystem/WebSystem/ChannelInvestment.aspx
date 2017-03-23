<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelInvestment.aspx.cs" Inherits="WebSystem.ChannelInvestment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>优青网渠道招商</title>
    <link rel="stylesheet" type="text/css" href="css/index.css"/>
    <script src="js/jquery-2.1.4.min.js"></script>
    <style type="text/css">
        table{
           border: 1px solid #62BBA0;
        }
        td {
            position:relative;
            font-size:14px;
            padding:10px 0 25px;
            color:#555;
        }
        input[type='text']{
            width:60%;
            line-height:30px;
        }
        .tips{
            position:absolute;
            bottom:0;
            color:#f00;
        }
        input[type='submit']{
            border:none;
            background:#62BBA0;
            color:#fff;
            width:30%;
            font-size:16px;
            padding:15px 0;
        }
    </style>
</head>
<body>
    <div class="header">
		<div class="fix-top">
			<div class="header-content">
				<a href="index.aspx"><img style="width:214px;height:29px;" src="<%=log %>"/></a>
				<ul>
                    <li><a href="#" style="color: #01A340;">渠道招商</a></li>
					<li><i class="icon-400"></i><%=phone %></li>
					<li><i class="icon-email"></i><%=mail %></li>
				</ul>
			</div>
		</div>
	</div>
    <form id="form1" runat="server">
        <div class style="width:640px;margin:20px auto 50px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" style="padding-top:0">
                        <img src="/images/daili.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding:0 0 10px;font-size:13px;color:888;">
                        请填写真实有效的信息,提交后将有专人与您联系！
                    </td>
                </tr>
                <tr>
                    <td align="right">*公司全称：</td>
                    <td>
                        <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">*公司地址：</td>
                    <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">*联系人：</td>
                    <td><asp:TextBox ID="txtLinkMan" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">*联系电话：</td>
                    <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">*邮箱地址：</td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">*主营业务：</td>
                    <td><asp:TextBox ID="txtMainBusiness" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">*意向代理城市：</td>
                    <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">团队规模：</td>
                    <td><asp:TextBox ID="txtTeamSize" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">主要优势：</td>
                    <td><asp:TextBox ID="txtMainAdvantage" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSave" runat="server" Text="提交申请" OnClick="btnSave_Click" OnClientClick="return check()" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <div class="footer">
        <%--<span>本站内容来自互联网，如果侵犯了你的权益，请与我们联系！欢迎咨询优青网站：//www.uqinger.com/</span>
        <span>专业的职业网站，快快咨询吧</span>
        <span>本站友情链接交换联系QQ：11669937</span>--%>
        <p>©2016 优青网 | 鄂ICP备16016911号</p>
    </div>
    <script type="text/javascript">
        $(function () {
            $("input[type=text]").focus(function () {
                $(this).next("p").remove();
            });
        });
        function check() {
            var flag = true;
            if ($("#txtCompany").val().trim() == "") {
                tips($("#txtCompany"), "请填写公司全称");
                flag = false;
            }
            if ($("#txtAddress").val().trim() == "") {
                tips($("#txtAddress"), "请填写公司地址");
                flag = false;
            }
            if ($("#txtLinkMan").val().trim() == "") {
                tips($("#txtLinkMan"), "请填写联系人");
                flag = false;
            }
            if ($("#txtPhone").val().trim() == "") {
                tips($("#txtPhone"), "请填写联系电话");
                flag = false;
            }
            if ($("#txtEmail").val().trim() == "") {
                tips($("#txtEmail"), "请填写邮件地址");
                flag = false;
            }
            if ($("#txtMainBusiness").val().trim() == "") {
                tips($("#txtMainBusiness"), "请填写主营业务");
                flag = false;
            }
            if ($("#txtCity").val().trim() == "") {
                tips($("#txtCity"), "请填写意向代理城市");
                flag = false;
            }
            return flag;
        }
        function tips(e, txt) {
            var html = "<p class='tips'>" + txt + "</p>"
            $(e).after(html);
        }

        
        </script>
</body>
</html>
