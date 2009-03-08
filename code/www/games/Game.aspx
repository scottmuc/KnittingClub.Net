<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="games_Game" %>
<%@ Import Namespace="KnittingClub.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  <h3>Players in this game</h3>
  <asp:Repeater ID="ctlPlayers" runat="server">
    <ItemTemplate>
      <%# Eval("NickName") %><br />
    </ItemTemplate>
  </asp:Repeater>
  
  <h3>Payout Structure</h3>
  <asp:Repeater ID="ctlPayouts" runat="server">
    <ItemTemplate>
      <%# Eval("AmountToBePaid") %><br />
    </ItemTemplate>
  </asp:Repeater>  
  
  
  <h3>Game Results</h3>
  <asp:Repeater ID="ctlResults" runat="server">
    <ItemTemplate>
      <%# Eval("Place") %> <%# ((GameResult) Container.DataItem).Player.NickName %> <%# GetKnockedOutPlayerString((GameResult) Container.DataItem) %><br />
    </ItemTemplate>
  </asp:Repeater>    

  <br />

  <ul>
    <li><a href="AddPlayers.aspx?gameId=<%= this.GameId %>">Add Players</a></li>
    <li><a href="AddPayout.aspx?gameId=<%= this.GameId %>">Add Payout</a></li>
    <li><a href="KnockOutPlayers.aspx?gameId=<%= this.GameId %>">Knock Out Players</a></li>
  </ul>

</asp:Content>

