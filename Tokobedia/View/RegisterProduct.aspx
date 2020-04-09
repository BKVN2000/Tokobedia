<%@ Page Title="RegisterProduct" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="RegisterProduct.aspx.cs" Inherits="Tokobedia.View.RegisterProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <div class="form-group">
            <label for="NameTxt">Name</label>
            <asp:textbox ID="NameTxt" class="form-control" runat="server"></asp:textbox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ErrorMessage="Name cannot be blank" ControlToValidate="NameTxt" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

         <div class="form-group">
            <label for="Price">Price</label>
             <asp:textbox ID="PriceTxt" class="form-control" runat="server" type="number"></asp:textbox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ErrorMessage="Price cannot be blank" ControlToValidate="PriceTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator runat="server" id="custMultCheck"
                ControlToValidate="PriceTxt"
                OnServerValidate="IsMultiplicationOf1000Check"
                ErrorMessage="Input must be above 1000 and multiply of 1000" />
          </div>

        <div class="form-group">
            <label for="StockTxt">Stock</label>
            <asp:textbox ID="StockTxt" class="form-control" runat="server" type="number"></asp:textbox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
            ErrorMessage="Stock cannot be blank" ControlToValidate="StockTxt" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidatorStock" runat="server" ErrorMessage="Stock Must be atleast 1" ControlToValidate="StockTxt" ForeColor="Red" 
                MinimumValue="1" MaximumValue="1000000" Type="Integer"></asp:RangeValidator>  
        </div>

         <div class="form-group">
           <asp:DropDownList runat="server" ID="ProductType_ddl" class="form-control">                      
            </asp:DropDownList>
         </div>

        <asp:Button runat="server" class="btn btn-primary" OnClick="Btn_InsertProductOnClick" Text="Register"/>
    </div>
</asp:Content>
