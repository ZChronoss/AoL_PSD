<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AoL_PSD.Views.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center;">Home</h1>
        <div style="display:flex; flex-direction:column; align-items: center; justify-content: center; gap:10px;">
            <div class="premium-button">
                <asp:Button ID="premiumBtn" runat="server" Text="Upgrade to premium" BackColor="Yellow" Width="170" Height="40" onClick="premiumBtn_Click"/>
            </div>

            <div class="playlist">
                <asp:Label ID="playlistLbl" runat="server" Text="Your playlists"></asp:Label>
                <asp:Button ID="addPlaylistBtn" runat="server" Text="Add playlist" /><br />
                <%--gridview--%>
            </div>

            <div class="song">
                <asp:Label ID="songLbl" runat="server" Text="Your songs"></asp:Label>
                <asp:Button ID="addSongBtn" runat="server" Text="Add song" onClick="addSongBtn_Click"/><br />
                <%--gridview--%>
            </div>
        </div>
    </form>
</body>
</html>
