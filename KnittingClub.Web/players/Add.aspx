<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="admin_AddPlayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<fieldset>

<label>
  <span>First Name</span>
  <asp:TextBox ID="ctlFirstName" runat="server" />
</label>

<label>
  <span>Last Name</span>
  <asp:TextBox ID="ctlLastName" runat="server" />
</label>

<label>
  <span>Nick Name</span>
  <asp:TextBox ID="ctlNickName" runat="server" />
</label>

<label>
  <asp:Button ID="ctlCreatePlayer" runat="server" Text="Create Player" />
</label>

</fieldset>

</asp:Content>

