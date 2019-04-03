<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="LampinAround.ShoppingCart" %>

<%@ MasterType VirtualPath="~/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:GridView ID="cartGrid" runat="server" Font-Names="Verdana" BorderColor="Black"
        DataKeyNames="qty"
        GridLines="Vertical"
        CellPadding="4" Font-Size="12pt" ShowFooter="True" HeaderStyle-CssClass="CartListHead"
        FooterStyle-CssClass="CartListFooter"
        RowStyle-CssClass="browser-default"
        AlternatingRowStyle-CssClass="CartListItemAlt"
        AutoGenerateColumns="False" CssClass="browser-default" style="opacity:10">
       
<AlternatingRowStyle ></AlternatingRowStyle>
        <Columns>
          <asp:TemplateField HeaderText="Product&#160;ID">
            <ItemTemplate>
              <asp:Label ID="ProductID" runat="server" 
                Text='<%# Eval("ProductID")%>'>
              </asp:Label>
            </ItemTemplate>
          </asp:TemplateField>

          <asp:BoundField DataField="ProductName" HeaderText="Product Name"></asp:BoundField>

          <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
              <asp:TextBox ID="Quantity" runat="server" MaxLength="3"
                Text='<%# Eval("Qty")%>' Width="40px" />
            </ItemTemplate>
          </asp:TemplateField>

          <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:c}"></asp:BoundField>

            <asp:TemplateField HeaderText="Subtotal">
                <ItemTemplate>
                    <asp:Label ID="lblSubtotal" runat="server" Text='<%# Bind("ItemSubtotal", "{0:c}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

          <asp:TemplateField HeaderText="Remove" ControlStyle-CssClass="browser-default">
            <ItemTemplate>
             
                <label><input type="checkbox" ID="Remove" runat="server"/> <span>Remove</span></label>
             
            </ItemTemplate>
              <ControlStyle CssClass="browser-default" BorderStyle="Solid" />
          </asp:TemplateField>
        </Columns>

<FooterStyle CssClass="CartListFooter"></FooterStyle>

<HeaderStyle CssClass="CartListHead"></HeaderStyle>

<RowStyle CssClass="CartListItem"></RowStyle>
      </asp:GridView>
     <%-- Begin Buttons and Totals --%>
  <asp:Button ID="btnUpdateQty" runat="server" Text="Update Quantity" OnClick="btnUpdateQty_Click" CssClass="waves-effect waves-light btn" />
  <asp:Button ID="btnDelete" runat="server" Text="Remove Items From Cart" OnClick="btnDelete_Click" CssClass="waves-effect waves-light btn" />
  <asp:Button ID="btnCheckOut" runat="server" Text="Checkout" OnClick="btnCheckOut_Click" CssClass="waves-effect waves-light btn" />
  <a href="index.aspx" class="waves-effect waves-light btn">Continue Shopping</a>
  <div class="col s6 offset-s6">
    <h3>Tax</h3>
    <asp:Label ID="lblTax" runat="server" Text=""></asp:Label>
    <br>
    <h3>Total</h3>
    <asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>
    <br>
    <label class=">Total</label>
    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>    
  </div>
  <%-- End Buttons and subtotal --%>
    </asp:Content>
