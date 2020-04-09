<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="RegisterProductType.aspx.cs" Inherits="Tokobedia.View.RegisterProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <div class="form-group">
            <label for="NameTxt">Name</label>
            <asp:textbox ID="NameTxt" class="form-control" runat="server"></asp:textbox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ErrorMessage="Name cannot be blank" ControlToValidate="NameTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator runat="server" id="productTypeNameTypeCheck"
                    ControlToValidate="NameTxt"
                    OnServerValidate="ValidateProductTypeName"
                    ErrorMessage="Must be filled, unique, and consists of 5 characters or more" />
        </div>

         <div class="form-group">
                <label for="DescTxt">Description</label>
                 <asp:textbox ID="DescTxt" class="form-control" runat="server" type="text"></asp:textbox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="DescTxt" ErrorMessage="Desc must be filled"></asp:RequiredFieldValidator>
          </div>

        <asp:Button runat="server" class="btn btn-primary" OnClick="Btn_SubmitProductType" Text="Submit"/>
    </div>
</asp:Content>
