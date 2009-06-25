<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1>CBC Knitting Club</h1>


<table>
  <tr>
    <th>Name</th>
    <th>Total Points</th>
    <th>Games Played</th>
  </tr>
<asp:Repeater ID="ctlYearlyStats" runat="server">
<ItemTemplate>
  <tr>
    <td><%# Eval("NickName") %></td>
    <td><%# Eval("TotalEarnings") %></td>
    <td><%# Eval("GamesPlayed") %></td>
  </tr>
</ItemTemplate>

</asp:Repeater>

</table>

</asp:Content>

