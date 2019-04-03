<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LampinAround.Login1" %>

<%@ MasterType VirtualPath="~/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="divLogin" class="row" runat="server" visible="true">
    <div class="container teal lighten-4">
      <asp:Label ID="lblMessage" Text="" runat="server"></asp:Label>
      <h2>Login</h2>
      <label class="active black-text" for="txtUserName">User Name</label>
      <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="rfvAccount" runat="server" ErrorMessage="Please enter valid username" ControlToValidate="txtUserName">*</asp:RequiredFieldValidator>
      <br>

      <label class="active black-text" for="txtPassword">Password</label>
      <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="rfvPword" runat="server" ErrorMessage="Please enter a valid password" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
      <br>

      <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
  </div>
</asp:Content>
