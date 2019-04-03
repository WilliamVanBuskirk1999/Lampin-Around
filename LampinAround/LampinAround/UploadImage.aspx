<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UploadImage.aspx.cs" Inherits="LampinAround.ManageImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="uplPics" runat="server" /> <br />
    <asp:Label ID="lblName" runat="server" Text="Name to save as:"></asp:Label> <br />
    <asp:TextBox ID="txtImgName" runat="server"></asp:TextBox> <br />
    <asp:Label ID="lblAltText" runat="server" Text="Please enter some alt text"></asp:Label><br />
    <asp:TextBox ID="txtAlt" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" /> <br />
    <asp:Image ID="imgUploaded" runat="server"/> <br /><br />

    <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
</asp:Content>
