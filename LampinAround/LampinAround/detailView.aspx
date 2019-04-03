<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="detailView.aspx.cs" Inherits="LampinAround.detailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptDetailView" runat="server">
        <ItemTemplate>
            <div class="center-align">
                <h3>
                Product ID: <%# Eval("ProductId") %>
                </h3>

                <h4>
                <%# Eval("ProductName") %>
                </h4>
                <br />
                <asp:Image ID="imgFeaturedProduct" runat="server" ImageUrl='<%# string.Format("~/images/") + Eval("ProductImage") + (".jpg") %>' CssClass="circle responsive-img"></asp:Image>
                <br />
                <p>
                Full Description : 
                <%# Eval("FullDescription") %>
                <br />
                Price :
                <%# Eval("Price", "{0:c}") %>  
                <br />
                Product Status:
                <%# Eval("ProductStatus") + "vailable" %>
               </p>
           </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="center-align">
    <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click"  CssClass="waves-effect waves-light btn"/>
   </div>

    <%--<asp:Button ID="editDetailView" runat="server" OnClick="editDetailView_Click" text="Edit"/>--%>
    <!--Start of editing product fields -->

    <!--End of editing product fields-->

</asp:Content>
