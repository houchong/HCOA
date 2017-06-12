<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" EnableViewState="false" Inherits="HCWebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox runat="server" ID="txtName" Text=""></asp:TextBox>
    <asp:Button runat="server" Text="回发" OnClick="Unnamed1_Click" />
    </div>
    </form>
    <form id="formClient" action="WebForm1.aspx">
        <input type="text" id="txtUserName" />
        <input type="submit" id="btnSub" value="回发" />
    </form>
</body>
</html>
