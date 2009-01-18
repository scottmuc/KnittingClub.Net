<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="CreateGame.aspx.cs" Inherits="CreateGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<fieldset>
  <label>
    <span>Game Title</span>
    <asp:TextBox ID="ctlTitle" runat="server" />
  </label>
  
  <label>
    <asp:Button ID="ctlCreateGame" runat="server" Text="Create Game" />
  </label>
</fieldset>
</asp:Content>

