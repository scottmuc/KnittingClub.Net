<%@ Page Title="" Language="C#" MasterPageFile="~/views/layouts/layout.master" AutoEventWireup="true" CodeFile="AddPayout.aspx.cs" Inherits="games_AddPayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<fieldset>
  <label>
    <span>How many places paid?</span>
    <asp:DropDownList ID="ctlNumberPaid" runat="server">
      <asp:ListItem Value="1" Text="1" />    
      <asp:ListItem Value="2" Text="2" />
      <asp:ListItem Value="3" Text="3" />
      <asp:ListItem Value="4" Text="4" />
    </asp:DropDownList>
  </label>
  
  <label>
    <span>First Place</span>
    <asp:TextBox ID="ctlFirstPlace" runat="server" />
  </label>
  
  <label>
    <span>Second Place</span>
    <asp:TextBox ID="ctlSecondPlace" runat="server" />
  </label>  

  <label>
    <span>Third Place</span>
    <asp:TextBox ID="ctlThirdPlace" runat="server" />
  </label>  
  
  <label>
    <span>Fourth Place</span>
    <asp:TextBox ID="ctlFourthPlace" runat="server" />
  </label>        
  
  <label>
    <asp:Button ID="ctlAddPayout" runat="server" Text="Add Payout" />
  </label>
  
</fieldset>
</asp:Content>

