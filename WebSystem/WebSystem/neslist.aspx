﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="neslist.aspx.cs" Inherits="WebSystem.neslist" %>

<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>优青网</title>
		<link rel="stylesheet" type="text/css" href="css/index.css"/>
		<script src="js/jquery-2.1.4.min.js" type="text/javascript" charset="utf-8"></script>
            <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
            <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
	</head>
	<body>
        <form id="form1" runat="server">
		<!--header start-->
		<div class="header">
			<div class="fix-top">
				<div class="header-content">
					<a href="index.aspx"><img src="<%=log %>"/></a>
					<ul>
						<li><i class="icon-400"></i><%=phone %></li>
						<li><i class="icon-email"></i><%=mail %></li>
					</ul>
				</div>
			</div>
		</div>
		<!--header end-->
		<div class="p-reg">
			<div class="inner" style="background:url(<%=bjtu %>) center top no-repeat">
				<div class="inner-wrap">
					<div class="inner-con">
						<ul style="top: 0;">
							<li class="inner-img first"> </li>
							<li class="inner-img second"> </li>
							<li class="inner-img third"> </li>
							<li class="inner-img fourth"> </li>
						</ul>
					</div>
				</div>
				<div class="inner-b">
					<div class="width" style="width:356px;">
						<i class="before"></i>
						<a class="login dialog"></a>
						<i class="after"></i>
					</div>
				</div>
			</div>
		</div>
		<!--main start-->
		<div id="newslistMain">
			<div id="middlebox">
				<div id="prolistleft">
					<div id="box">
						<div class="newstop">
							<img src="img/banner1.png" />
						</div>
						<h1>新闻动态</h1>
						<div>
							<ul>
                            <asp:Repeater runat="server" ID="rptnewshot">
                                <ItemTemplate>
                                 <li><a href="newsdetai.aspx?type=news&id=<%#Eval("NewsID") %>"><%#Eval("Title") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
							</ul>
						</div>
					</div>
				</div>
				<div id="newstright"> 
				    <div class="topimg"><img src="img/news-1.jpg" /></div>
				    <div id="listcontent">公司新闻</div>
				    <div id="newslist">
					    <ul>
                            <asp:Repeater runat="server" ID="rptnews">
                                <ItemTemplate>
                                 <li><a href="newsdetai.aspx?type=news&id=<%#Eval("NewsID") %>"><%#Eval("Title") %></a><span><%#Eval("CreateTime") %></span></li>
                                </ItemTemplate>
                            </asp:Repeater>
					      
					    </ul>
                          <div class="digg">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="false" CssClass="pagination" LayoutType="div" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="10" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True">
                            </webdiyer:AspNetPager>
                            </div>
					<!--
                    	<p style="margin:10px; text-align:right">上一页 1 2 3 4 下一页</p>
                    -->
                        
				   </div>
			    </div>
		    </div>
		</div>
		<div class="footer">
            <span>本站内容来自互联网，如果侵犯了你的权益，请与我们联系！欢迎咨询优青网站：http://www.com.cn/</span>
            <span>专业的职业网站，快快咨询吧</span>
            <span>本站友情链接交换联系QQ：11669937</span>

        </div>
		<div class="footfixed">
			<div class="width">
				<ul>
					<li class="lx"></li>
					<li class="lg1"></li>
					<li class="lg2"></li>
				</ul>
				
			</div>
		</div>
		
            </form>
	</body>
</html>
