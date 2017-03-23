<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebSystem.index" %>

<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>优青网</title>
		<link rel="stylesheet" type="text/css" href="css/index.css"/>
		<script src="js/jquery-2.1.4.min.js" type="text/javascript" charset="utf-8"></script>
        <!--[if IE]> 
        <style>
            .hide{
                display:block;
            }
        </style>
        <![endif]--> 
	</head>
	<body ondragstart="return false;">
		<!--header start-->
		<div class="header">
			<div class="fix-top">
				<div class="header-content">
					<a href="#"><img style="width:214px;height:29px;" src="<%=log %>"/></a>
					<ul>
                        <li><a href="ChannelInvestment.aspx" style="color: #01A340;">渠道招商</a></li>
						<li><i class="icon-400"></i><%=phone %></li>
						<li><i class="icon-email"></i><%=mail %></li>
					</ul>
				</div>
			</div>
		</div>
		<!--header end-->
		<div class="banner" style="background:url(<%=bjtu %>) center top no-repeat;width:100%;height:630px;"></div>
			<!--login end-->
		<div class="clearfix">
            <div class="w960">
                <img style="width:100%;" src="<%=QRCode %>"/>
            </div>
		</div>
        <div class="clearfix bgF7F7F7" id="picInfo1">
            <div class="w960">
                <div class="fl">
                    <img class="hide" src="/images/pic1.png" />
                </div>
                <div class="fr">
                    <img src="/images/info1.png" />
                </div>
            </div>
        </div>
        <div class="clearfix" id="picInfo2">
            <div class="w960">
                <div class="fl">
                    <img src="/images/info2.png" />
                </div>
                <div class="fr">
                    <img class="hide" src="/images/pic2.png" />
                </div>
            </div>
        </div>
        <div class="clearfix bgF7F7F7" id="picInfo3">
            <div class="w960">
                <div class="fl">
                    <img class="hide" src="/images/pic3.png" />
                </div>
                <div class="fr">
                    <img src="/images/info3.png" />
                </div>
            </div>
        </div>
        <div class="clearfix" id="picInfo4">
            <div class="w960">
                <div class="fl">
                    <img src="/images/info4.png" />
                </div>
                <div class="fr">
                    <img class="hide" src="/images/pic4.png" />
                </div>
            </div>
        </div>
		<!--main end-->
		<div id="footer">
            <div class="content">
                <div class="position">
                    <h3>与优青网同行</h3>
                    <ul>
                        <asp:Repeater runat="server" ID="dujia">
                            <ItemTemplate>
                                <li>
                                    <div class="infoBox" onclick="showApp();">
                                        <img src="<%#Eval("ComImg") %>" >
                                        <div class="info">
                                            <p class="post"><%#Eval("PostName") %><span><i>￥</i><%#Eval("Salary") %></span></p>
                                            <p class="company"><%#Eval("Company") %><span><%#Eval("SeeCount") %><i>人查看</i></span></p> 
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="withMe">
                    <ul>
                        <asp:Repeater runat="server" ID="hezuo">
                        <ItemTemplate>
                            <li><img src="<%#Eval("Logo") %>" ><span><%#Eval("Name") %></span></li>
                            </ItemTemplate>
                        </asp:Repeater>
		            </ul>
                </div>
            </div>
		</div>
        <div class="footer">
            <%--<span>本站内容来自互联网，如果侵犯了你的权益，请与我们联系！欢迎咨询优青网站：//www.uqinger.com/</span>
            <span>专业的职业网站，快快咨询吧</span>
            <span>本站友情链接交换联系QQ：11669937</span>--%>
            <p>©2016 优青网 | 鄂ICP备16016911号</p>
        </div>
    <div class="mask"></div>
    <div class="dailog">
        <img src="/images/position.png" />
    </div>
	<script type="text/javascript">
	    var scollRecord = 0;
	    var obj = new Object;
	    var isFirst = true;

	    window.onscroll = function () {
	        var h = $("body").scrollTop();
	        if (isFirst) {
	            for (var i = 1; i < 5; i++) {
	                var key = 'picInfo' + i;
	                var val = $('#' + key).offset().top - 300;
	                obj[key] = val;
	            }
	            isFirst = false;
	            console.log(obj);
	        }
	        while (h > scollRecord) {
	            scollRecord = h;
	            
	            if (scollRecord > obj["picInfo1"] && $(".animation1").length == 0) {
	                $("#picInfo1 .fl").addClass("animation1");
	            }
	            if (scollRecord > obj["picInfo2"] && $(".animation2").length == 0) {
	                $("#picInfo2 .fr").addClass("animation2");
	            }
	            if (scollRecord > obj["picInfo3"] && $(".animation3").length == 0) {
	                $("#picInfo3 .fl").addClass("animation3");
	            }
	            if (scollRecord > obj["picInfo4"] && $(".animation4").length == 0) {
	                $("#picInfo4 .fr").addClass("animation4");
	            }
	        }
	    }

	    function showApp() {
	        $(".mask,.dailog").addClass("mask-in");
	        if (document.addEventListener) {
	            document.addEventListener('DOMMouseScroll',function(){return false}, false);
	        }//W3C
	        window.onmousewheel = document.onmousewheel = function () { return false };//IE/Opera/Chrom

	        $(".mask,.dailog").click(function () {
	            $(".mask,.dailog").removeClass("mask-in");

	            if (document.addEventListener) {
	                document.addEventListener('DOMMouseScroll', function () { return true }, false);
	            }//W3C
	            window.onmousewheel = document.onmousewheel = function () { return true };//IE/Opera/Chrom
	        })
	    }
	</script>
	</body>
</html>
