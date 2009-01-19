<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="games_Game" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <ul>
    <li><a href="AddPlayers.aspx?gameId=<%= this.GameId %>">Add Players</a></li>
    <li><a href="AddPayout.aspx?gameId=<%= this.GameId %>">Add Payout</a></li>
    <li><a href="KnockOutPlayers.aspx?gameId=<%= this.GameId %>">Knock Out Players</a></li>
  </ul>

</asp:Content>

