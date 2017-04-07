<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebSystem.Systestcomjun.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>优青网后台管理系统</title>
	<link href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/datepicker3.css" rel="stylesheet">
	<link href="css/styles.css" rel="stylesheet">

	<!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->
</head>
<body>
	<form id="form1" runat="server">
		<nav class="navbar navbar-inverse navbar-fixed-top" role="navigation" style="position: absolute; top: 0; right: 0; left: 0;">
			<div class="container-fluid">
				<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					<a class="navbar-brand" href="#"><span>优青网</span>后台管理</a>
					<ul class="user-menu">
						<li class="dropdown pull-right">
							<a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-user"></span>
								<asp:Literal ID="ltlUserName" runat="server"></asp:Literal><span class="caret"></span></a>
							<ul class="dropdown-menu" role="menu">
								<%--<li><a href="#"><span class="glyphicon glyphicon-user"></span> 个人资料</a></li>--%>
								<li><a href="#"><span class="glyphicon glyphicon-cog"></span>修改密码</a></li>
								<li>
									<asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click"><span class="glyphicon glyphicon-log-out"></span> 安全退出</asp:LinkButton></li>
							</ul>
						</li>
					</ul>
				</div>
			</div>
			<!-- /.container-fluid -->
		</nav>

		<div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar" style="position: absolute; bottom: 0; left: 0;">


			<ul class="nav menu">
				<li r="1" style="display: none;">
					<a href="SysSet.aspx" target="frm">
						<span class="glyphicon glyphicon-cog"></span>
						系统管理
					</a>
				</li>
				<li r="2" style="display: none;"><a href="UserManagers/List.aspx" target="frm"><span class="glyphicon glyphicon-th"></span>用户管理</a></li>
				<li r="3" style="display: none;"><a href="Role/List.aspx" target="frm"><span class="glyphicon glyphicon-eye-open"></span>角色管理</a></li>
				<li r="4" style="display: none;"><a href="Person/List.aspx" target="frm"><span class="glyphicon glyphicon-tower"></span>人才管理</a></li>
				<li r="5" style="display: none;"><a href="ServerUser/List.aspx" target="frm"><span class="glyphicon glyphicon-user"></span>人才经纪人管理</a></li>
				<%--<li r="6" style="display:none;"><a href="JobTraining/List.aspx"  target="frm"><span class="glyphicon glyphicon-briefcase"></span>职位信息</a></li>--%>
				<%--<li r="7" style="display:none;"><a href="CareerPlanning/List.aspx" target="frm"><span class="glyphicon glyphicon-edit"></span>职场攻略</a></li>--%>
				<%--<li r="8" style="display:none;"><a href="Person/Representations.aspx" target="frm"><span class="glyphicon glyphicon-bullhorn"></span>申述管理</a></li>--%>
				<li r="9" style="display: none;"><a href="News/List.aspx" target="frm"><span class="glyphicon glyphicon-fire"></span>热点推荐</a></li>
				<li r="10" style="display: none;"><a href="Order/OrderList.aspx" target="frm"><span class="glyphicon glyphicon-list-alt"></span>订单管理</a></li>
				<li r="11" style="display: none;"><a href="PresentApplication/AuthList.aspx" target="frm"><span class="glyphicon glyphicon-floppy-remove"></span>提现审核</a></li>
				<li r="12" style="display: none;"><a href="PresentApplication/PayList.aspx" target="frm"><span class="glyphicon glyphicon-floppy-saved"></span>提现支付</a></li>
				<li r="13" style="display: none;"><a href="SysLog/List.aspx" target="frm"><span class="glyphicon glyphicon-folder-open"></span>日志管理</a></li>
				<li r="14" style="display: none;"><a href="CooperativePartner/List.aspx" target="frm"><span class="glyphicon glyphicon-globe"></span>合作伙伴</a></li>
				<li r="15" style="display: none;"><a href="homepage/indexconfigure.aspx" target="frm"><span class="glyphicon glyphicon-home"></span>首页管理</a></li>
				<li r="16" style="display: none;"><a href="statistic/jobseeker.aspx" target="frm"><span class="glyphicon glyphicon-signal"></span>统计页面</a></li>
				<li r="17" style="display: none;"><a href="PostType/List.aspx" target="frm"><span class="glyphicon glyphicon-th-list"></span>职位类型</a></li>
				<li r="18" style="display: none;"><a href="ChannelCnvestment/List.aspx" target="frm"><span class="glyphicon glyphicon-send"></span>渠道招商</a></li>
				<li r="19" style="display: none;"><a href="FeedBack/List.aspx" target="frm"><span class="glyphicon glyphicon-send"></span>用户反馈</a></li>
				<%--<li class="parent ">
				<a href="#">
					<span class="glyphicon glyphicon-list"></span> Dropdown <span data-toggle="collapse" href="#sub-item-1" class="icon pull-right"><em class="glyphicon glyphicon-s glyphicon-plus"></em></span> 
				</a>
				<ul class="children collapse" id="sub-item-1">
					<li>
						<a class="" href="#">
							<span class="glyphicon glyphicon-share-alt"></span> Sub Item 1
						</a>
					</li>
					<li>
						<a class="" href="#">
							<span class="glyphicon glyphicon-share-alt"></span> Sub Item 2
						</a>
					</li>
					<li>
						<a class="" href="#">
							<span class="glyphicon glyphicon-share-alt"></span> Sub Item 3
						</a>
					</li>
				</ul>
			</li>
			<li role="presentation" class="divider"></li>
			<li><a href="login.html"><span class="glyphicon glyphicon-user"></span> Login Page</a></li>--%>
			</ul>
			<div class="attribution"></div>
		</div>
		<!--/.sidebar-->

		<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main" style="position: absolute; right: 0; bottom: 0; top: 0; overflow: hidden;">
			<iframe id="frm" name="frm" style="position: absolute; top: 0; right: 0; bottom: 0; left: 0; width: 100%; height: 100%; border: 0;" src="welcome.aspx"></iframe>
		</div>
		<!--/.main-->

		<script src="js/jquery-1.11.1.min.js"></script>
		<script src="js/bootstrap.min.js"></script>
		<script src="js/chart.min.js"></script>
		<%--<script src="js/chart-data.js"></script>--%>
		<script src="js/bootstrap-datepicker.js"></script>
		<script src="js/easypiechart.js"></script>
		<script src="js/easypiechart-data.js"></script>
		<script src="/assets/plugin/yHelper.js"></script>
		<script>
			var url = new Array("", "");
			$('#calendar').datepicker({
			});
			//$("#frm").height($(window).height() - $(".navbar").height());
			!function ($) {
				$(document).on("click", "ul.nav li.parent > a > span.icon", function () {
					$(this).find('em:first').toggleClass("glyphicon-minus");
				});
				$(".sidebar span.icon").find('em:first').addClass("glyphicon-plus");
			}(window.jQuery);

			$(window).on('resize', function () {
				if ($(window).width() > 768) $('#sidebar-collapse').collapse('show')
			})
			$(window).on('resize', function () {
				if ($(window).width() <= 767) $('#sidebar-collapse').collapse('hide')
			})
			$(".nav li").click(function () {
				$(".nav li").removeClass("active");
				$(this).addClass("active");
				//$(".main").load(url[parseInt($(this).attr("tabindex"))]);
			});
			var role = '<%=role%>';
			if (role != null) {
				var r = role.split(',');
				$(".nav li").each(function () {
					var num = $(this).attr("r");
					if ($.inArray(num, r) >= 0) {
						$(this).show();
					} else {
						$(this).remove();
					}
				});
			}
			$(".nav li[r=8]").hide();
	</script>
	</form>
	<script>
		$(function () {
			(function (window) {
				init();
				function init() {
					var request = yHelper.request.getParams();
					var r = request['r'];
					console.log(r);
					if (!r) {
						return;
					}
					var rLi = $(".nav li[r=" + parseInt(r) + "]");
					if (!rLi || rLi.length <= 0) {
						return;
					}
					var href = rLi.children("a").attr("href");
					if (!href) {
						return;
					}
					$(".nav li").removeClass("active");
					rLi.addClass("active");
					$("#frm").attr("src", href);
				}
				eventBind();
				function eventBind() {
					var rLis = $(".nav li");
					rLis.unbind("click");
					rLis.bind("click", function () {
						var $that = $(this);
						var r = $that.attr("r");
						yHelper.response.redirect(location.pathname + "?r=" + r);
						return false;
					});
				}
			})(window)
		})
	</script>
</body>
</html>
