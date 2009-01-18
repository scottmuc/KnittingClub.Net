<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="EditGame.aspx.cs" Inherits="EditGame" %>
<%@ Register TagPrefix="kc" Namespace="KnittingClub.UI.Web.Controls" Assembly="KnittingClub"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Repeater ID="ctlPlayersInGame" runat="server">

<ItemTemplate>
  <%# Eval("NickName") %><br />
</ItemTemplate>
</asp:Repeater>

<br />
<fieldset>

  <label>
    <kc:PlayersDropDownList id="ctlPlayers" runat="server" />
  </label>

  <label>
    <asp:Button ID="ctlAddPlayer" runat="server" Text="Add Player To Game" />
  </label>

</fieldset>

<asp:Literal ID="ctlMessage" runat="server" />

</asp:Content>

