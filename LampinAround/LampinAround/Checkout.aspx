<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="LampinAround.Checkout" %>

<%@ MasterType VirtualPath="~/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
    <div class="col s12 m6">
      <div class="card blue-grey darken-1">
        <div class="card-content white-text">
          <span class="card-title">Confirm Address and Shipping Details</span>
          <p>
            Please confirm the address you wish to use for your billing information.
          </p>
        </div>
      </div>
    </div>
  </div>
    <asp:Repeater ID="rptUserInfo" runat="server">
        <ItemTemplate>
            
                <span>Name</span>
                <span><%# Eval("FullName") %></span>
                <br />

                <span>Address</span>
                <asp:TextBox ID="txtAddress" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Address Required" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                <br />
                <span>Billing Address</span>
                <asp:TextBox ID="txtBilling" runat="server" Text='<%# Eval("BillingAddress") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Billing Address Required" ControlToValidate="txtBilling"></asp:RequiredFieldValidator>
                <br />
                <span>PostalCode</span>
                <asp:TextBox ID="txtPostalCode" runat="server" Text='<%# Eval("PostalCode") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ErrorMessage="Postal Code Required" ControlToValidate="txtPostalCode"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPostal" runat="server" ErrorMessage="Incorrect Postal code" ControlToValidate="txtPostalCode" ValidationExpression="^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$|^\d{5}$"></asp:RegularExpressionValidator>
                <br />
                <span>City</span>
                <asp:TextBox ID="txtCity" runat="server" Text='<%#Eval("City") %>'></asp:TextBox> 
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="City Required" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
                <br />
               
                <br />
                <span>Phone Number</span>
                <asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:TextBox> 
                <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="Country required" ControlToValidate="txtPhoneNumber"></asp:RequiredFieldValidator>
                <br />
                <span class="black-text">Email Address</span>
                <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
               <%-- <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please enter a valid email" ControlToValidate="txtEmail" ValidationExpression="\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"></asp:RegularExpressionValidator>--%>
            
        </ItemTemplate>
    </asp:Repeater>
    <br />
     <span>Province or State</span>
                <asp:DropDownList ID="DropDownListState" runat="server" CssClass="browser-default">
	                <asp:ListItem Value="AL">Alabama</asp:ListItem>
	                <asp:ListItem Value="AK">Alaska</asp:ListItem>
	                <asp:ListItem Value="AZ">Arizona</asp:ListItem>
	                <asp:ListItem Value="AR">Arkansas</asp:ListItem>
	                <asp:ListItem Value="CA">California</asp:ListItem>
	                <asp:ListItem Value="CO">Colorado</asp:ListItem>
	                <asp:ListItem Value="CT">Connecticut</asp:ListItem>
	                <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	                <asp:ListItem Value="DE">Delaware</asp:ListItem>
	                <asp:ListItem Value="FL">Florida</asp:ListItem>
	                <asp:ListItem Value="GA">Georgia</asp:ListItem>
	                <asp:ListItem Value="HI">Hawaii</asp:ListItem>
	                <asp:ListItem Value="ID">Idaho</asp:ListItem>
	                <asp:ListItem Value="IL">Illinois</asp:ListItem>
	                <asp:ListItem Value="IN">Indiana</asp:ListItem>
	                <asp:ListItem Value="IA">Iowa</asp:ListItem>
	                <asp:ListItem Value="KS">Kansas</asp:ListItem>
	                <asp:ListItem Value="KY">Kentucky</asp:ListItem>
	                <asp:ListItem Value="LA">Louisiana</asp:ListItem>
	<asp:ListItem Value="ME">Maine</asp:ListItem>
	<asp:ListItem Value="MD">Maryland</asp:ListItem>
	<asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	<asp:ListItem Value="MI">Michigan</asp:ListItem>
	<asp:ListItem Value="MN">Minnesota</asp:ListItem>
	<asp:ListItem Value="MS">Mississippi</asp:ListItem>
	<asp:ListItem Value="MO">Missouri</asp:ListItem>
	<asp:ListItem Value="MT">Montana</asp:ListItem>
	<asp:ListItem Value="NE">Nebraska</asp:ListItem>
	<asp:ListItem Value="NV">Nevada</asp:ListItem>
	<asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	<asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	<asp:ListItem Value="NM">New Mexico</asp:ListItem>
	<asp:ListItem Value="NY">New York</asp:ListItem>
	<asp:ListItem Value="NC">North Carolina</asp:ListItem>
	<asp:ListItem Value="ND">North Dakota</asp:ListItem>
	<asp:ListItem Value="OH">Ohio</asp:ListItem>
	<asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	<asp:ListItem Value="OR">Oregon</asp:ListItem>
	<asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	<asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	<asp:ListItem Value="SC">South Carolina</asp:ListItem>
	<asp:ListItem Value="SD">South Dakota</asp:ListItem>
	<asp:ListItem Value="TN">Tennessee</asp:ListItem>
	<asp:ListItem Value="TX">Texas</asp:ListItem>
	<asp:ListItem Value="UT">Utah</asp:ListItem>
	<asp:ListItem Value="VT">Vermont</asp:ListItem>
	<asp:ListItem Value="VA">Virginia</asp:ListItem>
	<asp:ListItem Value="WA">Washington</asp:ListItem>
	<asp:ListItem Value="WV">West Virginia</asp:ListItem>
	<asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	<asp:ListItem Value="WY">Wyoming</asp:ListItem>
</asp:DropDownList>

 <asp:DropDownList ID="DropDownListProvinces" runat="server" CssClass="browser-default">
	<asp:ListItem Value="AL">Alberta</asp:ListItem>
	<asp:ListItem Value="BC">British Columbia</asp:ListItem>
	<asp:ListItem Value="MN">Manitoba</asp:ListItem>
	<asp:ListItem Value="ON">Ontario</asp:ListItem>
	<asp:ListItem Value="QC">Quebec</asp:ListItem>
	<asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
	<asp:ListItem Value="NL">Newfoundland</asp:ListItem>
	<asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
	<asp:ListItem Value="NB">New Brunswick</asp:ListItem>
	<asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
	<asp:ListItem Value="YK">Yukon</asp:ListItem>
	<asp:ListItem Value="NW">Northwest Territories</asp:ListItem>
	<asp:ListItem Value="NT">Nunavut</asp:ListItem>
</asp:DropDownList>
    <asp:Button ID="btnUpdate" runat="server" Text="Update Info" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnChoosePayment" runat="server" Text="Continue to Choose Payment" OnClick="btnChoosePayment_Click" />
</asp:Content>
