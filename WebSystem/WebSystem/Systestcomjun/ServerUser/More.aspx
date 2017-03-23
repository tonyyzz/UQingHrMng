<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="More.aspx.cs" Inherits="WebSystem.Systestcomjun.ServerUser.More" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
    <script src="../js/My97DatePicker/WdatePicker.js"></script>
    <!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        职业介绍人更多信息
                    </div>
                    <div class="panel-body">
                        <div>
                            <div>自我介绍</div>
                           <p Class="suojin"> <asp:Literal ID="ltldes"  runat="server"></asp:Literal></p>
                        </div>
                        <div class="row">
                            <div>工作经历</div>
                            
                                <asp:Repeater ID="rptWork" runat="server">
                                    <ItemTemplate>
                                       <div class="col-md-4"> 公司：<%#Eval("Company") %>(<%#Eval("StartTime") %>-<%#Eval("EndTime") %>) </div>
                                       <div class="col-md-4"> 职位：<%#Eval("Position") %></div>
                                       <div class="col-md-4"> 经历描述：<%#Eval("WorkDes") %></div>
                                    </ItemTemplate>                     
                                </asp:Repeater>
                           
                        </div>
                        <div class="row">
                            <div>教育经历</div>
                            <asp:Repeater ID="rptEdu" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-3"> 学校：<%#Eval("SchoolName")%> (<%#Eval("StartTime") %>-<%#Eval("EndTime") %>)</div>
                                    <div class="col-md-3">专业：<%#Eval("Major") %></div>
                                    <div class="col-md-3">学历：<%#Eval("Education") %></div>
                                    <div class="col-md-3">教育经历：<%#Eval("EduDes") %></div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                          <div class="row">
                            <div>标签</div>
                            <asp:Repeater ID="rptTag" runat="server">
                                <ItemTemplate>
                                    <p class="suojin"><%#Eval("TagName") %></p>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="row">
                            <div>对他的点评</div>
                            <asp:Repeater ID="rptEvaluate" runat="server">
                                <ItemTemplate>
                                      <p class="suojin"><%#Eval("EvaluateName") %><%#Eval("EvaluateTime") %></p>
                                     <p class="suojin"><%#Eval("EvaluateCon") %></p>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <!-- /.row -->
        </div>
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <script src="/Systestcomjun/js/pubfunction.js"></script>
        <script type="text/javascript">
            
        </script>
    </form>
</body>
</html>
