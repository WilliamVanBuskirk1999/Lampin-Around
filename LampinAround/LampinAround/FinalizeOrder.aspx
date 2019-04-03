<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FinalizeOrder.aspx.cs" Inherits="LampinAround.FinalizeOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%-- Replace all credit card and debit info --%>
  <asp:DropDownList ID="ddlPaymentOptions" runat="server" CssClass="browser-default" OnSelectedIndexChanged="ddlPaymentOptions_SelectedIndexChanged">
    <asp:ListItem>Credit Card</asp:ListItem>
    <asp:ListItem>Debit Card</asp:ListItem>
  </asp:DropDownList>
  <%-- End code replacement --%>

  
    <div runat="server" id="amountOwed">
    <label><b>Tax</b></label>
    <asp:Label ID="lblTax" runat="server" Text=""></asp:Label><br />
    <label>Shipping Cost</label>
    <asp:Label ID="lblShipping" runat="server" Text="Label"></asp:Label><br />
    <label><b>Total</b></label>
    <asp:Label ID="lblTotal" runat="server" ></asp:Label>
       
    </div>

    <asp:Button ID="btnFinalize" runat="server" Text="Finalize Order" OnClick="btnFinalize_Click" />
</asp:Content>
