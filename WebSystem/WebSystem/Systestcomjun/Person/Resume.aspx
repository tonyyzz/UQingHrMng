<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resume.aspx.cs" Inherits="WebSystem.Systestcomjun.Person.Resume" %>

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
<body style="padding-top: 15px;">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        简历信息
                    </div>
                    <div class="panel-body" style="padding: 0 15px 15px 15px;">
                        <div>
                            <div style="font-size:16px;height:25px;line-height:25px;color:#30a5ff;">基本信息</div>
                            <asp:Image ID="imgPhoto" ImageUrl="" runat="server" style="position: absolute;width: 150px;right: 10%;height: 200px;" />
                            <div>姓名：<asp:Literal ID="ltlRealName" runat="server"></asp:Literal></div>
                            <div>性别：<asp:Literal ID="ltlSex" runat="server"></asp:Literal></div>
                            <div>所在城市：<asp:Literal ID="ltlCity" runat="server"></asp:Literal></div>
                            <div>最高学历：<asp:Literal ID="ltlEducation" runat="server"></asp:Literal></div>
                            <div>工作年限：<asp:Literal ID="ltlWorkLife" runat="server"></asp:Literal></div>
                            <div>联系电话：<asp:Literal ID="ltlPhne" runat="server"></asp:Literal></div>
                            <div>联系邮箱：<asp:Literal ID="ltlEmail" runat="server"></asp:Literal></div>
                        </div>
                        <div>
                            <div style="font-size:16px;height:25px;line-height:25px;color:#30a5ff;">期望工作</div>
                            <div>期望职位：<asp:Literal ID="ltlExpectedPostion" runat="server"></asp:Literal></div>
                            <div>工作类型：<asp:Literal ID="ltlWorkType" runat="server"></asp:Literal></div>
                            <div>期望城市：<asp:Literal ID="ltlExCity" runat="server"></asp:Literal></div>
                            <div>期望薪水：<asp:Literal ID="ltlExSalary" runat="server"></asp:Literal></div>
                            <div>补充说明：<asp:Literal ID="ltlReMark" runat="server"></asp:Literal></div>
                        </div>
                        <div>
                            <div style="font-size:16px;height:25px;line-height:25px;color:#30a5ff;">工作经历</div>
                            <asp:Repeater ID="rptPerWork" runat="server">
                                <ItemTemplate>
                                    <div>公司名称：<%#Eval("ComPanyName") %>（<%#Eval("EntryTime") %>-<%#Eval("QuitTime") %>）</div>
                                    <div>所在职位：<%#Eval("Position") %></div>
                                    <div>工作内容：<%#Eval("WorkCon") %></div>
                                    <asp:LinkButton ID="btnDel" runat="server" CommandArgument='<%#Eval("PerWordID") %>' CommandName="del" Visible="false">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div>
                            <div style="font-size:16px;height:25px;line-height:25px;color:#30a5ff;">教育经历</div>
                            <asp:Repeater ID="rptEducation" runat="server">
                                <ItemTemplate>
                                    <div>学校名称：<%#Eval("SchoolName") %>（<%#Eval("GraduationYear") %>）</div>
                                    <div>所学专业：<%#Eval("Major") %></div>
                                    <div>学历：<%#Eval("Education") %></div>
                                    <asp:LinkButton ID="btnDel" runat="server" CommandArgument='<%#Eval("PerEduID") %>' CommandName="del" Visible="false">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div>
                            <div style="font-size:16px;height:25px;line-height:25px;color:#30a5ff;">项目经历</div>
                            <asp:Repeater ID="rptPerProject" runat="server">
                                <ItemTemplate>
                                    <div>项目名称：<%#Eval("ProName") %>（<%#Eval("StartTime") %>-<%#Eval("EndTime") %>）</div>
                                    <div>项目职责：<%#Eval("ProDuty") %></div>
                                    <div>项目描述：<%#Eval("ProDes") %></div>
                                    <div>项目链接：<%#Eval("ProLink") %></div>
                                    <asp:LinkButton ID="btnDel" runat="server" CommandArgument='<%#Eval("PerProID") %>' CommandName="del" Visible="false">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div>
                            <div style="font-size:16px;height:25px;line-height:25px;color:#30a5ff;">技能评价</div>
                            <asp:Repeater ID="rptPerSkill" runat="server">
                                <ItemTemplate>
                                    <div>技能名称：<%#Eval("SkillName") %></div>
                                    <div>掌握程度：<%# skillMasterDegree(Eval("MasterDegree")+"") %></div>
                                    <asp:LinkButton ID="btnDel" runat="server" CommandArgument='<%#Eval("PerSkillID") %>' CommandName="del" Visible="false">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div>
                            <div style="font-size:16px;height:25px;line-height:25px;color:#30a5ff;">自我描述</div>
                            <asp:Literal ID="ltlMyDes" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

</html>
