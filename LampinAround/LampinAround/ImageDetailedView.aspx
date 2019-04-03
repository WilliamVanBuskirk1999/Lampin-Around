<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ImageDetailedView.aspx.cs" Inherits="LampinAround.ImageDetailedView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3>
       Image Name:
     </h3>
     
      <asp:Repeater ID="rptDetailView" runat="server">
        <ItemTemplate>
            <div class="center-align">
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("ImageName") %>'> </asp:Label>
                <br />
                <asp:Image ID="imgDetailedImageView" runat="server" ImageUrl='<%# string.Format("~/TempImages/") + Eval("ImageName") %>' CssClass="circle responsive-img"></asp:Image>
                <br />

                <h4>Date Added: <%# Eval("DateAdded", "{0:d}") %></h4>
           </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="center-align">
        <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" /> <br />
        <asp:Button ID="btnDelete" runat="server" Text="Remove" OnClick="btnDelete_Click" />
    </div>
</asp:Content>
