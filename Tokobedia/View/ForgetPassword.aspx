<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="Tokobedia.View.ForgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <label for="NameTxt">Old Password</label>
        <asp:TextBox ID="Txt_OldPassword" class="form-control" runat="server" type="password"></asp:TextBox>
        <asp:CustomValidator runat="server" ID="custMultCheck"
            ControlToValidate="Txt_OldPassword"
            OnServerValidate="CheckOldPasswordValidation"
            ErrorMessage="Old Password doesnt match!!" ForeColor="Red" />
    </div>

    <div class="form-group">
        <label for="NewPasswordTxt">New Password</label>
        <asp:TextBox ID="NewPasswordTxt" class="form-control" runat="server" type="password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ErrorMessage="Password cannot be blank" ControlToValidate="NewPasswordTxt" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <label for="ConPasswordTxt">Confirm Password</label>
        <asp:TextBox ID="ConPasswordTxt" class="form-control" runat="server" type="password"></asp:TextBox>
        <asp:CompareValidator ID="ComparePasswordValidator" runat="server" ControlToCompare="NewPasswordTxt" ControlToValidate="ConPasswordTxt"
            ErrorMessage="Password and confirm password must be same" ForeColor="Red"></asp:CompareValidator>
    </div>

     <asp:Button runat="server" id="Btn_ChangePassword" class="btn btn-primary" OnClick="Btn_ChangePasswordOnclick" Text="Update Password" />

</asp:Content>
