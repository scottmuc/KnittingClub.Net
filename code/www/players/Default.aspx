<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_DisplayPlayers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Repeater ID="ctlPlayers" runat="server">
  <ItemTemplate>
  <%# Eval("FirstName") %><br />
  </ItemTemplate>
</asp:Repeater>
</asp:Content>

