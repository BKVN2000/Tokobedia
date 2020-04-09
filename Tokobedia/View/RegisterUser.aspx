<%@ Page Title="ViewProfile" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Tokobedia.View.RegisterUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <div class="form-group">
                <label for="NameTxt">Email</label>
                <asp:textbox ID="TxtBox_Email" class="form-control" runat="server" Type="email"></asp:textbox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtBox_Email" ErrorMessage="Email Must be filled"></asp:RequiredFieldValidator>
                <asp:CustomValidator runat="server" id="custMultCheck"
                ControlToValidate="TxtBox_Email"
                OnServerValidate="CheckEmailAvailability"
                ErrorMessage="Email already taken" ForeColor="red" />
            </div>

            <div class="form-group">
                <label for="NameTxt">Name</label>
                <asp:textbox ID="TxtBox_Name" class="form-control" runat="server"></asp:textbox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtBox_Name" ErrorMessage="Name Must be filled"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="TxtBox_Password">Password</label>
                <asp:textbox ID="TxtBox_Password" class="form-control" runat="server" type="password"></asp:textbox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtBox_Password" ErrorMessage="Password Must be filled"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="TxtBox_ConfirmPassword">Confirm Password</label>
                <asp:textbox ID="TxtBox_ConfirmPassword" class="form-control" runat="server" type="password"></asp:textbox>
                <asp:CompareValidator ID="ComparePasswordValidator" runat="server" ControlToCompare="TxtBox_Password" ControlToValidate="TxtBox_ConfirmPassword"
                            ErrorMessage="Password and confirm password must be same" ForeColor="Red"></asp:CompareValidator>
            </div>

            <div class="form-group">
               <label for="NameTxt">Gender</label>
               <asp:RadioButtonList ID="rbl_Gender" runat="server">
                    <asp:ListItem Text="Male" Value="Male"/>
                    <asp:ListItem Text="Female" Value="Female" />
               </asp:RadioButtonList>
                <asp:RequiredFieldValidator runat="server" ID="genderRequired" Display="Dynamic"
                ControlToValidate="rbl_Gender" ErrorMessage="Choose Gender"></asp:RequiredFieldValidator>
            </div>

            <asp:Button runat="server" class="btn btn-primary text-uppercase" OnClick="Btn_SubmitUser" Text="Register"/>
        </div>
</asp:Content>