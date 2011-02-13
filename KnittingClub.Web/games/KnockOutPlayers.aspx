<%@ Page MasterPageFile="~/views/layouts/layout.master" CodeFile="KnockOutPlayers.aspx.cs" Inherits="games_KnockOutPlayers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Label ID="message" runat="server" />
<fieldset>

  <label>
    <span>This Player</span>
    <asp:DropDownList ID="ctlKnockedOut" runat="server" />
  </label>
  
  <label>
    <span>Got knocked out by this Player</span>
    <asp:DropDownList ID="ctlKnockerOuter" runat="server" />
  </label>  

  <label>
    <asp:Button ID="ctlKnockOutPlayer" runat="server" Text="Knock Out Player" />
  </label>

</fieldset>

</asp:Content>

