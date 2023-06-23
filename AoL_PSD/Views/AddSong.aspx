<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSong.aspx.cs" Inherits="AoL_PSD.Views.AddSong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center;">Add a song</h1>
        <div style="display:flex; flex-direction:column; align-items: center; justify-content: center; gap:10px;">

            <div class="title" style="text-align:center;">
                <asp:TextBox ID="TitleTextBox" runat="server" placeholder="Song title" Width="300" Height="40" Font-Size="Medium"></asp:TextBox><br />
                <asp:Label ID="TitleValid" runat="server" Visible="false" style="color:red;" Text="There has to be a song title!" ></asp:Label>
            </div>

            <div class="genre">
                    <asp:Label ID="GenreTextBox" runat="server" Text="Genre:"></asp:Label>
                    <asp:DropDownList ID="GenreDropList" runat="server" Width="100" Height="30" Font-Size="Medium"></asp:DropDownList>
            </div>

            <div class="file" style="text-align:center;">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Label ID="FileValid" runat="server" Visible="false" style="color:red;" Text="Insert a song file!" ></asp:Label>
            </div>

            <div class="button">
                <asp:Button ID="addMusicBtn" runat="server" Text="Add song!" OnClick="addMusicBtn_Click" BackColor="LightGreen" Width="100"/>
            </div>

        </div>
    </form>
</body>
</html>
