<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="LampinAround.login" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <div class="row">
      <div class="col s3 offset-s6">
        <asp:TextBox ID="txtSearchAccount" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearchAccount" runat="server" Text="Search" OnClick="btnSearchAccount_Click" CausesValidation="false" />
      </div>
    </div>
    <div class="row">
      <div id="divCreateAccount" class="container teal lighten-4" runat="server" visible="true">
        <h2>Create Account</h2>
        <label class="active" for="txtUserName">User Name</label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Please enter valid username" ControlToValidate="txtUserName">*</asp:RequiredFieldValidator>
        <br>

        <label class="active" for="txtPassword">Password</label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please enter a valid password" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
        <br>

        <label class="active" for="txtPasswordConfirm">Confirm Password</label>
        <asp:TextBox ID="txtPasswordConfirm" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPasswordConfirm" runat="server" ErrorMessage="Passwords must match" ControlToValidate="txtPasswordConfirm">*</asp:RequiredFieldValidator>
        <br>

        <label class="active" for="txtFNname">First Name</label>
        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="Please enter a valid name" ControlToValidate="txtFName">*</asp:RequiredFieldValidator>
        <br>

        <label class="active" for="txtLNname">Last Name</label>
        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="Please enter a valid last name" ControlToValidate="txtLName">*</asp:RequiredFieldValidator>
        <br>

        <label class="active" for="txtEmail">E-Mail</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please enter a valid email" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
        <br />

        <label class="active" for="txtAddress">Address</label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please enter a valid address" ControlToValidate="txtAddress">*</asp:RequiredFieldValidator>
        <br />

        <label class="active" for="txtCity">City</label>
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Please enter a valid city" ControlToValidate="txtCity">*</asp:RequiredFieldValidator>
        <br />

        <label class="active" for="txtPostalCode">Postal Code</label>
        <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ErrorMessage="Ensure postal code is valid" ControlToValidate="txtPostalCode">*</asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revPostalCode" runat="server" ErrorMessage="Ensure the postal code is valid" ValidationExpression="^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$|^\d{5}$" ControlToValidate="txtPostalCode"></asp:RegularExpressionValidator>
        <br />

        <label class="active" for="ddlCountry">Country</label>
          <asp:DropDownList ID="ddlCountry" runat="server" CssClass="browser-default" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true">
              <asp:ListItem>Canada</asp:ListItem>
              <asp:ListItem>USA</asp:ListItem>
          </asp:DropDownList>
       
        
        <br />
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

          <br />
        <label class="active" for="ddlYear">Date Of Birth</label>
    
        <asp:TextBox ID="txtDOB" TextMode="Date" runat="server"></asp:TextBox>
         <asp:RangeValidator ID="rangeDOB" runat="server" ControlToValidate="txtDOB" ErrorMessage="Under 19 not allowed" Type="Date"></asp:RangeValidator>

        <br />

        <label class="active">Phone Number</label>
        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="Please enter a valid phone number" ControlToValidate="txtPhoneNumber">*</asp:RequiredFieldValidator>
          <!-- Goes after the required field validator for phone -->
        <br />
        <label>
            <input type="checkbox" ID="chkAdmin" runat="server" />
            <span>Admin</span>

        </label>
        <br />
        <!-- Goes before the create account button -->
        <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
        <asp:Button ID="btnUpdateAccount" runat="server" Text="Update Account" OnClick="btnUpdateAccount_Click" />
        <asp:Button ID="btnArchive" runat="server" Text="Archive Account" Visible="false" />
      </div>
    </div>
  </main>
</asp:Content>
