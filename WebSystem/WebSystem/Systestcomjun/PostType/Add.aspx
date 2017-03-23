<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebSystem.Systestcomjun.PostType.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="/Systestcomjun/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/datepicker3.css" rel="stylesheet" />
    <link href="/Systestcomjun/css/styles.css" rel="stylesheet" />
    <script language="javascript" charset="utf-8" src="/keditor/kindeditor.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/lang/zh_CN.js"></script>
	<script language="javascript" charset="utf-8" src="/keditor/plugins/code/prettify.js"></script>
</head>
<body style="padding-top: 15px;">
    <form id="form1" runat="server">
    <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                       职位类型
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            
                            <div class="form-group">
                                <label>类型名称</label>
                                <asp:TextBox ID="txtPostTypeName" runat="server" class="form-control" t="txt" n="1" MaxLength="30" placeholder="输入类型名称，必填"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>排序</label>
                                <asp:TextBox ID="txtSort" runat="server" class="form-control" t="int" n="1" MaxLength="4" placeholder="输入排序号，只能输入数字，必填"></asp:TextBox>
                            </div>
                            
                        </div>
                        <%--<div class="col-md-12" style="text-align: center;">--%>
                        <asp:Button ID="btnsave" runat="server" Text="保存" class="btn btn-primary btn_Save" OnClick="btnsave_Click" Width="100px" />
                        <%--</div>--%>
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
