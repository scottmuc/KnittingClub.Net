<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DisplayGames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Repeater ID="ctlGames" runat="server">
  <ItemTemplate>
    <a href="Game.aspx?gameId=<%# Eval("Id") %>"><%# Eval("Title") %></a><br />
  </ItemTemplate>
</asp:Repeater>
<br /><br />


</asp:Content>

