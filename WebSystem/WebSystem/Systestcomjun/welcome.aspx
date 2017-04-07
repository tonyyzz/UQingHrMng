<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="WebSystem.Systestcomjun.welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
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
		<div class="row">
			<ol class="breadcrumb">
				<li><a href="#"><span class="glyphicon glyphicon-home"></span></a></li>
				<li class="active">首页</li>
			</ol>
		</div>
		<!--/.row-->

		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Welcome</h1>
			</div>
		</div>
		<!--/.row-->

		<div class="row">

			<%-- 待审核订单 --%>
			<div id="checkPendingOrder" class="col-xs-12 col-md-6 col-lg-3" style="cursor: pointer;">
				<div class="panel panel-blue panel-widget ">
					<div class="row no-padding">
						<div class="col-sm-3 col-lg-5 widget-left">
							<em class="glyphicon glyphicon-shopping-cart glyphicon-l"></em>
						</div>
						<div class="col-sm-9 col-lg-7 widget-right">
							<div class="large">
								<asp:Literal ID="ltlorder" runat="server"></asp:Literal></div>
							<div class="text-muted">待审核订单</div>
						</div>
					</div>
				</div>
			</div>

			<%-- 待认证人才 --%>
			<div class="col-xs-12 col-md-6 col-lg-3" style="cursor: pointer; display: none;">
				<div class="panel panel-orange panel-widget">
					<div class="row no-padding">
						<div class="col-sm-3 col-lg-5 widget-left">
							<em class="glyphicon glyphicon-comment glyphicon-l"></em>
						</div>
						<div class="col-sm-9 col-lg-7 widget-right">
							<div class="large">
								<asp:Literal ID="ltlperson" runat="server"></asp:Literal></div>
							<div class="text-muted">待认证人才</div>
						</div>
					</div>
				</div>
			</div>

			<%-- 待认证人才经纪人 --%>
			<div id="checkAuthSerUser" class="col-xs-12 col-md-6 col-lg-3" style="cursor: pointer;">
				<div class="panel panel-teal panel-widget">
					<div class="row no-padding">
						<div class="col-sm-3 col-lg-5 widget-left">
							<em class="glyphicon glyphicon-user glyphicon-l"></em>
						</div>
						<div class="col-sm-9 col-lg-7 widget-right">
							<div class="large">
								<asp:Literal ID="ltlseruser" runat="server"></asp:Literal></div>
							<div class="text-muted">待认证人才经纪人</div>
						</div>
					</div>
				</div>
			</div>

			<%-- 待处理提现申请 --%>
			<div id="checkWithdrawal" class="col-xs-12 col-md-6 col-lg-3" style="cursor: pointer;">
				<div class="panel panel-red panel-widget">
					<div class="row no-padding">
						<div class="col-sm-3 col-lg-5 widget-left">
							<em class="glyphicon glyphicon-stats glyphicon-l"></em>
						</div>
						<div class="col-sm-9 col-lg-7 widget-right">
							<div class="large">
								<asp:Literal ID="ltltixian" runat="server"></asp:Literal></div>
							<div class="text-muted">待处理提现申请</div>
						</div>
					</div>
				</div>
			</div>

		</div>
		<!--/.row-->
	</form>
	<script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
	<script>
		$(function () {
			(function (window) {
				eventBind();
				function eventBind() {
					//待审核订单
					$("#checkPendingOrder").unbind("click");
					$("#checkPendingOrder").bind("click", function () {
						gotoPage({ r: 10, state: 2 });
					});
					//待认证人才经纪人
					$("#checkAuthSerUser").unbind("click");
					$("#checkAuthSerUser").bind("click", function () {
						gotoPage({ r: 5, state: 1 });
					});
					//待处理提现申请
					$("#checkWithdrawal").unbind("click");
					$("#checkWithdrawal").bind("click", function () {
						gotoPage({ r: 11, state: "0_1" });
					});
				}
				function gotoPage(obj) {
					if (!obj || obj.length <= 0) {
						window.parent.location.href = "/Systestcomjun/index.aspx";
						return;
					}
					var search = '?';
					var searchParamArr = [];
					for (var key in obj) {
						searchParamArr.push(key + "=" + obj[key]);
					}
					search += searchParamArr.join("&");
					window.parent.location.href = "/Systestcomjun/index.aspx" + search;
				}

			})(window)
		})
	</script>
</body>
</html>
