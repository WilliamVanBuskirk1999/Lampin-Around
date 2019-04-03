
<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LampinAround.index" %>

<%@ MasterType VirtualPath="~/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
  <div id="index-banner" class="section no-pad-bot">
    <div class="container">
      <br>
      <br>
      <h1 runat="server" id="h1PageLabel" class="header center red-text text-lighten-3">Our Featured Products</h1>
        
      <div class="row center">
        <h5 class="header col s12 light">A bright spot on the web.</h5>

      </div>
      <div class="row center">
        <a href="ShoppingCart.aspx" class="btn-floating btn-large waves-effect waves-light red"><i class="material-icons">shopping_basket</i></a>

      </div>
      <br>
      <br>
    </div>
  </div>
  <div class="container">
    <div class="section">

      <!--   Icon Section   -->
      <div class="row">


       
        <asp:Repeater ID="rptProductsMainPage" runat="server">
          <ItemTemplate>
            <div class="col s12 m4">
              <div class="icon-block">
                <asp:Image ID="imgFeaturedProduct" runat="server" ImageUrl='<%# string.Format("~/images/") + Eval("ProductImage") + (".jpg") %>' CssClass="circle responsive-img" Height="200" Width="200"></asp:Image>
                <a href="detailView.aspx?productID=<%# Eval("ProductID") %>">
                  <h5 class="center"><%# Eval("ProductName") %></h5>
                </a>

                <p class="light">
                  Product ID: <%# Eval("ProductID") %>
                  <br />
                  <%# Eval("Price","{0:c}") %>
                  <br />
                  <%# Eval("BriefDescription") %>
                </p>
              </div>
            </div>
          </ItemTemplate>

        </asp:Repeater>
      
      </div>


    </div>

  </div>
  <br>
  <br>
  <!--  Scripts-->
  <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
  <script src="js/materialize.js"></script>
  <script src="js/init.js"></script>
</asp:Content>
