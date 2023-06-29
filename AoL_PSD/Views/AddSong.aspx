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

            <div>
                <asp:Button ID="HomeBtn" runat="server" Text="Cancel" OnClick="HomeBtn_Click" BackColor="DarkRed" style="color:white;" Height="30" Width="70" />
            </div>

            <div class="title" style="text-align:center;">
                <asp:TextBox ID="TitleTextBox" runat="server" placeholder="Song title" Width="300" Height="40" Font-Size="Medium"></asp:TextBox><br />
                <asp:Label ID="TitleValid" runat="server" Visible="false" style="color:red;" Text="There has to be a song title!" ></asp:Label>
            </div>

            <div class="genre">
                    <asp:Label ID="GenreTextBox" runat="server" Text="Genre:"></asp:Label>
                    <asp:DropDownList ID="GenreDropList" runat="server" Width="100" Height="30" Font-Size="Medium"></asp:DropDownList><br />
                    <asp:Label ID="GenreValid" runat="server" Visible="false" style="color:red;" Text="Select a genre!" ></asp:Label>
            </div>

            <div class="file" style="text-align:center;">
                <asp:FileUpload ID="SongFile" runat="server" accept=".mp3,.m4a,.wav"  /><br />
                <asp:Label ID="FileValid" runat="server" Visible="false" style="color:red;" Text="Insert a song file!" ></asp:Label>  
                <asp:Label ID="FileValid2" runat="server" Visible="false" style="color:red;" Text="Please insert a file with a valid type! (.mp3, .m4a, or .wav)" ></asp:Label>   
            </div>

            <div class="button">
                <asp:Button ID="addMusicBtn" runat="server" Text="Add song!" OnClick="addMusicBtn_Click" BackColor="LightGreen" Width="120" Height="40" Font-Size="Medium" />
            </div>

            <div class="errorMessage">
                <asp:Label ID="ErrorLabel" runat="server" Visible="false" BorderStyle="Solid" BackColor="Red" style="padding:20px;" Text="You inserted this song already!"></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
