<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="Tokobedia.View.UpdateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row"><%-- class="border-dark mt-5"<%-- style="border: 2px solid black; width: 100%;--%>
        <div class="col-md-6">
            <div class="form-group">
                <label for="TxtBox_Email">Email</label>
                <asp:TextBox ID="TxtBox_Email" class="form-control" runat="server" Type="email"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtBox_Email" ErrorMessage="Email Must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CustomValidator runat="server" ID="ChkEmail"
                    ControlToValidate="TxtBox_Email"
                    OnServerValidate="CheckEmailAvailability"
                    ErrorMessage="Email already taken" ForeColor="red" />
            </div>

            <div class="form-group">
                <label for="NameTxt">Name</label>
                <asp:TextBox ID="TxtBox_Name" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtBox_Name" ErrorMessage="Name Must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="NameTxt">Gender</label>
                <asp:RadioButtonList ID="rbl_Gender" runat="server">
                    <asp:ListItem Text="Male" Value="Male" />
                    <asp:ListItem Text="Female" Value="Female" />
                </asp:RadioButtonList>
            </div>

            <asp:Button runat="server" class="btn btn-primary" OnClick="Btn_SubmitUserOnClick" Text="Update User" />
            <asp:Button runat="server" class="btn btn-primary" OnClick="Btn_ChangePassword" Text="Change Password" />
        </div>
        <hr />
        <div class="col-md-6">
             <label for="NameTxt">Nama :</label>
             <asp:Literal runat ="server" ID="Lit_NameTxt"></asp:Literal> <br />

             <label for="EmailTxt">Email :</label>
             <asp:Literal runat ="server" ID="Lit_EmailTxt"></asp:Literal> <br />

             <label for="GenderTxt">Gender :</label>
             <asp:Literal runat ="server" ID="Lit_GenderTxt"></asp:Literal> <br />

        </div>
    </div>
   
</asp:Content>
