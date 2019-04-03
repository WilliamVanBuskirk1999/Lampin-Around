<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="LampinAround.adminPage" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container teal lighten-4">
    <h2>Edit Category Information</h2>

    <asp:DropDownList ID="ddlCatId" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="browser-default" OnSelectedIndexChanged="ddlCatId_SelectedIndexChanged">
      <asp:ListItem>SELECT CATEGORY</asp:ListItem>
      <asp:ListItem>Add Category</asp:ListItem>
    </asp:DropDownList>

    <br />
    <label for="txtCatName">Category Name</label>
    <asp:TextBox ID="txtCatName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please provide a category name" ControlToValidate="txtCatName" ValidationGroup="categories">*</asp:RequiredFieldValidator>
    <br />
    <label for="txtCatDescription">Category Description</label>
    <asp:TextBox ID="txtCatDescription" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please provide a category description" ControlToValidate="txtCatDescription" ValidationGroup="categories"></asp:RequiredFieldValidator>
    <asp:Button ID="btnSaveCategory" runat="server" Text="Save Category" OnClick="btnSaveCategory_Click" CausesValidation="true" ValidationGroup="categories" />
      <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" ValidationGroup="categories" />
  </div>
  <div class="container teal lighten-4">
    <h2>Edit Product Information</h2>
    <asp:DropDownList ID="ddlProdName" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="browser-default" OnSelectedIndexChanged="ddlProdName_SelectedIndexChanged">
      <asp:ListItem>SELECT Product</asp:ListItem>
      <asp:ListItem>Add Product</asp:ListItem>
    </asp:DropDownList>
    <label class="active" for="txtProductName">Product Name</label>
    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ErrorMessage="Please enter a product name" ControlToValidate="txtProductName" ValidationGroup="products">*</asp:RequiredFieldValidator>
    <br>

    <label class="active" for="txtFullDescription">Full Description</label>
    <asp:TextBox ID="txtFullDescription" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFullDescription" runat="server" ErrorMessage="Please enter a full description" ControlToValidate="txtFullDescription" ValidationGroup="products">*</asp:RequiredFieldValidator>
    <br />

    <label class="active" for="txtPrice">Price</label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Please enter a valid price" ControlToValidate="txtPrice" ValidationGroup="products">*</asp:RequiredFieldValidator>
    <br />

    <label class="active" for="txtCategoryID">Category ID</label>
    <asp:TextBox ID="txtCategoryID" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCategoryId" runat="server" ErrorMessage="Please enter a proper category Id" ControlToValidate="txtCategoryID" ValidationGroup="products"></asp:RequiredFieldValidator>
    <br />

    <label class="active" for="txtFeatured">Featured</label>
    <asp:TextBox ID="txtFeatured" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFeatured" runat="server" ErrorMessage="Ensure that you have if the product is featured or not" ControlToValidate="txtFeatured" ValidationGroup="products"></asp:RequiredFieldValidator>
    <br />

    <label class="active" for="txtProductStatus">Product Status</label>
    <asp:TextBox ID="txtProductStatus" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revProductStatus" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^a|b$" ControlToValidate="txtProductStatus" ValidationGroup="products"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rfvProductStatus" runat="server" ErrorMessage="Please enter a correct product status" ControlToValidate="txtProductStatus" ValidationGroup="products"></asp:RequiredFieldValidator>
    <asp:Button ID="btnSaveToDatabase" runat="server" text="Save Product" OnClick="btnSaveToDatabase_Click" ValidationGroup="products" />
      <asp:Button ID="btnDeleteProduct" runat="server" Text="Delete" OnClick="btnDeleteProduct_Click" ValidationGroup="products" />
  </div>
</asp:Content>
