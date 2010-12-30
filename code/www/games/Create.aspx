<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="CreateGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<fieldset>
  <label>
    <span>Game Title</span>
    <asp:TextBox ID="ctlTitle" runat="server" />
  </label>
  
  <label>
    <span>Buy In</span>
    <asp:DropDownList ID="ctlBuyIn" runat="server">
      <asp:ListItem Text="$20" Value="20" Selected="True" />
      <asp:ListItem Text="$50" Value="50" />
      <asp:ListItem Text="$75" Value="75" />
    </asp:DropDownList>
  </label>
  
  <label>
    <asp:Button ID="ctlCreateGame" runat="server" Text="Create Game" />
  </label>
</fieldset>
</asp:Content>

