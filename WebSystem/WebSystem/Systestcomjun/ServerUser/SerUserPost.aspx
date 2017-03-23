<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SerUserPost.aspx.cs" Inherits="WebSystem.Systestcomjun.ServerUser.SerUserPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
                <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
    
    <style>
    </style>
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
                    <div class="panel-heading">人才经纪人职位</div>
                    <div class="panel-body" style="padding-bottom: 0px">
                        <div class="pull-left">
                            <a href="javascript:;" class="btn btn-primary" name="add" >添加</a>
                            <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger" OnClientClick="return comfirm('确定要删除吗？')" OnClick="btndel_Click" />
                            <asp:Button ID="btnSaveSort" runat="server" Text="保存排序" CssClass="btn btn-warning" OnClick="btnSaveSort_Click" />
                            <asp:Button ID="btnSetSole" runat="server" Text="设为独家"  CssClass="btn btn-primary" OnClick="btnSetSole_Click" />
                            <asp:Button ID="btnDelSole" runat="server" Text="取消独家"  CssClass="btn btn-primary" OnClick="btnDelSole_Click" />
                        </div>
                        <div class="columns btn-group pull-right">
                            <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-success" OnClick="Button1_Click" />
                        </div>
                        <div class="pull-right search" style="padding-right: 10px;">
                            <asp:TextBox ID="txtkey" class="searchtxt" runat="server" placeholder="姓名/职位/公司"></asp:TextBox>
                        </div>
                       <div class="pull-right search" style="padding-right: 10px;">
                           <asp:DropDownList ID="ddlIsSole" runat="server" CssClass="searchtxt">
                               <asp:ListItem Value="" Text="是否独家"></asp:ListItem>
                               <asp:ListItem Value="1" Text="独家"></asp:ListItem>
                               <asp:ListItem Value="2" Text="普通"></asp:ListItem>
                           </asp:DropDownList>
                        </div>
                    </div>
                    <div class="panel-body " style="padding-bottom: 0px">
                        <div class="tabdiv">
                            <table width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" id="chkall" /></th>
                                        <th>经纪人</th>
                                        <th>职位</th>
                                        <th>公司</th>
                                        <th>行业</th>
                                        <th>规模</th>
                                        <th>性质</th>
                                        <th>薪资</th>
                                        <th>工作地区</th>
                                        <th>是否独家</th>
                                        <th>排序</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkid" runat="server" name="subBox" />
                                                <asp:HiddenField ID="txtid" runat="server" Value='<%#Eval("SerUserPostID") %>' />
                                            </td>
                                            <td><a href="javascript:;" name="resume" userid="<%#Eval("SerUserID") %>"><%#Eval("RealName") %></a></td>
                                            <td><%#Eval("PostName") %></td>
                                            <td><%#Eval("Company") %></td>
                                            <td><%#Eval("Trade") %></td>
                                            <td><%#Eval("Scale") %></td>
                                            <td><%#Eval("Nature") %></td>
                                            <td><%#Eval("Salary") %></td>
                                            <td><%#Eval("WorkAdress") %></td>
                                            <td><%#Eval("IsSole").ToString()=="1"?"独家":"普通" %></td>
                                            <td>
                                                 <asp:TextBox ID="txtSort" runat="server" class="form-control" t="int" n="1" MaxLength="5" Text='<%#Eval("Colvalue") %>' Width="50px"></asp:TextBox>
                                            </td>
                                            <td><a href="javascript:;" name="more">详细</a>
                                                <a href="javascript:;" name="edit">编辑</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <div class="panel-body " style="">
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="false" CssClass="pagination" LayoutType="div" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="20" OnPageChanged="AspNetPager1_PageChanged" AlwaysShow="True">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->
        <script src="/Systestcomjun/js/jquery-1.11.1.min.js"></script>
        <script src="/Systestcomjun/js/bootstrap.min.js"></script>
        <script src="/Systestcomjun/js/layer/layer.js"></script>
        <%--<script src="/Systestcomjun/js/pubfunction.js"></script>--%>
        <script type="text/javascript">
            $(function () {
                $("#chkall").click(function () {
                    $("span[name='subBox'] input[type=checkbox]").prop("checked", this.checked);
                });
                var $subBox = $("span[name='subBox'] input[type=checkbox]");
                $subBox.click(function () {
                    $("#chkall").prop("checked", $subBox.length == $("span[name='subBox'] input[type=checkbox]:checked").length ? true : false);
                });

                $("a[name=resume]").click(function () {
                    var id = $(this).attr("userid");
                    layer.open({
                        title: "职业介绍人更多信息",
                        type: 2,
                        area: ['700px', '530px'],
                        fix: false, //不固定
                        content: 'More.aspx?SerUserID=' + id
                    });
                });
                $("a[name=more]").click(function () {
                    var id = $(this).parent().parent().find("input[type=hidden]").val();
                    layer.open({
                        title: "职位详情",
                        type: 2,
                        area: ['700px', '530px'],
                        fix: false, //不固定
                        content: 'Post.aspx?SerUserPostID=' + id
                    });
                });
                $("a[name=edit]").click(function () {
                    var id = $(this).parent().parent().find("input[type=hidden]").val();
                    layer.open({
                        title: "编辑职位",
                        type: 2,
                        area: ['1200px', '730px'],
                        fix: false, //不固定
                        content: 'PostEdit.aspx?SerUserPostID=' + id
                    });
                });
                $("a[name=add]").click(function () {
                    layer.open({
                        title: "添加职位",
                        type: 2,
                        area: ['1200px', '730px'],
                        fix: false, //不固定
                        content: 'PostEdit.aspx?'
                    });
                });
            });
            </script>
    </form>
</body>
</html>
