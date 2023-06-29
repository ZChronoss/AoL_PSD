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
                <asp:Label ID="premiumUserLabel" runat="server" Text="You are a premium user!" ForeColor="Green" Visible="false"></asp:Label>
            </div>

            <div class="playlist">
                <asp:Label ID="playlistLbl" runat="server" Text="Your playlist"></asp:Label>
                <asp:GridView ID="PlaylistGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Music.Title" HeaderText="Name" SortExpression="Music.Title" />
                        <asp:BoundField DataField="User.username" HeaderText="Artist" SortExpression="User.username" />
                        <asp:BoundField DataField="DateAddedToPlaylist" HeaderText="Date added to Playlist" SortExpression="DateAddedToPlaylist" />
                    </Columns>
                </asp:GridView>             
            </div>

            <div class="song" >
                <asp:Label ID="songLbl" runat="server" Text="Your songs"></asp:Label>
                <asp:Button ID="addSongBtn" runat="server" Text="Add song" onClick="addSongBtn_Click"/><br /><br />
                <div>
                    <asp:Label ID="notPremiumLbl" runat="server" Text="You are not a premium user, you can only play random song."></asp:Label>
                    <asp:Literal ID="audioLiteral" runat="server"></asp:Literal>
                </div>
                
                <asp:Label ID="noMusicLbl" runat="server" Text="There is no music yet!" Visible="false"></asp:Label>

                <asp:GridView ID="MusicGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="MusicGridView_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                        <asp:BoundField DataField="Title" HeaderText="Name" SortExpression="Title" />
                        <asp:BoundField DataField="Genre.Name" HeaderText="Genre" SortExpression="Genre.Name" />
                        <asp:BoundField DataField="User.username" HeaderText="Artist" SortExpression="User.Username" />
                        <asp:BoundField DataField="DateAdded" HeaderText="Date added" SortExpression="DateAdded" />
                        <asp:BoundField DataField="FileLocation" HeaderText="Song" SortExpression="FileLocation" />
                        <asp:TemplateField HeaderText="Play" Visible="false">
                            <ItemTemplate>
                                <audio controls>
                                    <source src="../Song/<%#Eval("FileLocation") %>" type="audio/ogg" />
                                </audio>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Add to playlist" ShowHeader="True" Text="Add" />
                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
