<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="GoogleHomeConsole.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="CSS/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GoogleHomeConsole</title>
</head>
<body>
    <form id="frmMain" runat="server">
        <div>
            <h1>Google Home Console</h1>
        </div>
        <div>
            ngrok URL : <asp:Label ID="lblNgrokDomain" ForeColor="red" runat="server" Text=""></asp:Label>
        </div>
        <hr />
        <div style="margin-bottom: 10px;" class="outer">
            <div class="v-center">
                <span>話したい言葉：</span>
                <asp:TextBox ID="tbxSay" Width="300" Height="20" style="margin-right: 10px;" runat="server"></asp:TextBox>
                <asp:Button ID="btnSay" runat="server" Width="120" Height="40" CssClass="btn" Text="喋らせる" OnClick="BtnSay_Click" />
                <br />
                <asp:Label ID="lblResult" ForeColor="Blue" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div>
            <asp:Button ID="btn1" runat="server" Width="120" Height="40" CssClass="btn" OnClick="CommonButtons_Click" Text="こんにちは" />
            <asp:Button ID="btn2" runat="server" Width="120" Height="40" CssClass="btn" OnClick="CommonButtons_Click" Text="お疲れ様でした" />
            <asp:Button ID="btn3" runat="server" Width="120" Height="40" CssClass="btn" OnClick="CommonButtons_Click" Text="いってらっしゃい" />
            <asp:Button ID="btn4" runat="server" Width="120" Height="40" CssClass="btn" OnClick="CommonButtons_Click" Text="おかえりなさい" />
        </div>
    </form>
</body>
</html>
