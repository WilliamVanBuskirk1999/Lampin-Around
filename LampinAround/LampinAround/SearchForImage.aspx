<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SearchForImage.aspx.cs" Inherits="LampinAround.VerifyImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Search For An Image</h2> <br />
    <div class="center-align">
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <br /><br />

    <asp:Repeater ID="rptResults" runat="server">
        <ItemTemplate>
            <a href="ImageDetailedView.aspx?imageID=<%# Eval("ImageID") %>"><h4><%# Eval("ImageName") %></h4></a> <br />
            <asp:Image ID="imgSearched" runat="server" ImageUrl='<%# string.Format("~/TempImages/") + Eval("ImageName")%>' />
        </ItemTemplate>
    </asp:Repeater>
        </div>
</asp:Content>
