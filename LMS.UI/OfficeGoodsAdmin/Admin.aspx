<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="OfficeGoodsAdmin_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Styles/GuangBang.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
        <script>
            $(function () {
                //使用样式表文件GuangBang
                //$("#gvwRecords tr:not(:first):odd").addClass("odd");
                //$("#gvwRecords tr:not(:first):even").addClass("even");

                //$("#gvwRecords tr:not(:first)").mouseover(function () {
                //    $(this).toggleClass("over");
                //}).mouseout(function () {
                //    $(this).toggleClass("over");
                //});

                //不使用样式表
                //$("#gvwRecords tr:not(:first):odd").css("background-color", "#E8D3E3");
                //$("#gvwRecords tr:not(:first):even").css("background-color", "#D2A6C7");

                $("#gvwRecords tr:not(:first)").mouseover(function () {
                    //$(this).css("background-color", "#00AE72");
                    $(this).css({"background-color":"#00AE72","cursor":"pointer"});
                }).mouseout(function () {
                    $("#gvwRecords tr:not(:first):odd").css("background-color", "#E8D3E3");
                    $("#gvwRecords tr:not(:first):even").css("background-color", "#D2A6C7");
                }).mouseout();      //.mouseout()触发事件
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend>领用办公用品</legend>
        <p>员工编号：<asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpID" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp&nbsp&nbsp 物品：<asp:DropDownList ID="ddlOfficeGoodsInfo" runat="server"></asp:DropDownList>&nbsp&nbsp&nbsp 数量：<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>备注：<asp:TextBox ID="txtRemark" runat="server" Height="97px" TextMode="MultiLine" Width="593px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="添加" />
        </p>
    </fieldset>
        <fieldset>
            <legend>领用记录查询</legend>
            员工编号 :<asp:TextBox ID="txtSearchEmpID" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CausesValidation="False" />
            <br />
            <br />
            <asp:GridView ID="gvwRecords" runat="server" AutoGenerateColumns="False" DataKeyNames="SupplyId" OnRowDeleting="gvwRecords_RowDeleting" OnRowEditing="gvwRecords_RowEditing" OnRowCancelingEdit="gvwRecords_RowCancelingEdit" OnRowUpdating="gvwRecords_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("SupplyId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="员工编号">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmpID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="领用时间">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("SupplyTime", "{0:yyyy-M-d HH:mm:ss}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="物品名称">
                        <EditItemTemplate>
                            <asp:HiddenField ID="hfdGoodId" runat="server" Value='<%# Eval("GoodID") %>' />
                            <asp:DropDownList ID="ddlGoods" runat="server" DataTextField="GoodName" DataValueField="GoodID"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("GoodName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="数量">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="False" CommandName="Update" Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('确认删除？')" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    <h2>查无此员工！！！！</h2>
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
    </fieldset>
    </div>
    </form>
</body>
</html>
