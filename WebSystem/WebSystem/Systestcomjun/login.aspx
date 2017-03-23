<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebSystem.Systestcomjun.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>优青网平台后台管理系统</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/datepicker3.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">
    <style>
        body {background:url(./image/login_bg.jpg) no-repeat;background-size:cover;padding-top:16%;}
    </style>
    <!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading" style="font-weight:normal;color:#30a5ff">优青UQinger.com</div>
                    <div class="panel-body">
                        <form role="form">
                            <fieldset>
                                <div class="form-group">
                                    <input class="form-control" placeholder="User" id="user" autofocus="">
                                </div>
                                <div class="form-group">
                                    <input class="form-control" placeholder="PassWord" id="password" type="password" value="">
                                </div>
                                <%--	<div class="checkbox">
								<label>
									<input name="remember" type="checkbox" value="Remember Me">Remember Me
								</label>
							</div>--%>
                                <a href="javascript:;" class="btn btn-primary" >Login</a>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </div>
        <!-- /.row -->

       

        <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/chart.min.js"></script>
        <script src="js/easypiechart.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <script src="js/easypiechart-data.js"></script>
        <script type="text/javascript">
            
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
            $(".btn").click(function () {
                var user = $("#user").val();
                var password = $("#password").val();
                $.post("ajax.ashx", { action: "login", user: user, password: password }, function (data) {
                    if (data == "1") {
                        window.location = "index.aspx";
                    } else{
                        alert("用户名或密码错误");
                    }
                });
            });
            $("body").keydown(function () {
                if (event.keyCode == "13") {//keyCode=13是回车键
                    $('.btn').trigger('click');
                }
            });
	</script>
    </form>
</body>
</html>
