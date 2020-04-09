<%@ Page Title="ViewProduct" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="Tokobedia.View.ViewProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group row mt-5">
        <div class="col-md-10">
            <label for="inputPassword" class="col-md-2 col-form-label">ProductType</label>
            <div class="col-md-6">
                <asp:DropDownList runat="server" ID="ProductType_ddl" class="form-control" AutoPostBack="true"
                    onselectedindexchanged="ProductType_ddl_SelectedIndexChanged">                      
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-md-2">
            <asp:Button ID="Btn_InsertNewProd" runat="server" Text="Insert New Product" class="btn btn-primary float-right" OnClick="Btn_InsertProductOnClick" Visible="false"/>
        </div>       
    </div>

    <div class="row">
        <asp:Repeater runat="server" ID="RptProductListByType" OnItemCommand="RptProductList_ItemCommand" OnItemCreated="InitRepeater">
            <ItemTemplate>
                <div class="card col-2 mr-2 mt-4" style="width: 20rem;">
                        <img src="<%=ResolveClientUrl("~")%>Assets/box.jpg" class="card-img-top">
                        <div class="card-body">
                            <h5 class="card-title">
                                <asp:Label runat="server" Text='<%#Eval("Name")%>' id="litProductName"/>
                            </h5>
                            <h6 class="card-subtitle mb-2 text-muted">
                                <asp:Label runat="server" Text='<%# "ID: "+Eval("ID")%>' id="Label1"/>
                            </h6>
                            <h6 class="card-subtitle mb-2 text-muted">
                                <asp:Label runat="server" Text='<%# "Type: "+Eval("ProductTypes.Name")%>' id="Label2"/>
                            </h6>
                            <h6 class="card-subtitle mb-2 text-muted">
                                <asp:Label runat="server" Text='<%#"Price: "+Eval("Price")%>' id="litPrice"/>
                            </h6>      
                            <h6 class="card-subtitle mb-2 text-muted">
                                <asp:Label runat="server" Text='<%# "Stock: "+Eval("Stock")%>' id="litStock"/>
                            </h6> 
                        </div>
                        <asp:Panel runat="server" ID="Pnl_ProductionAction" Visible="false">
                            <div class="card-footer">
                                <asp:Button ID="Btn_UpdateProduct" runat="server"  Text="Update" Font-Size="X-Small" class="btn btn-primary col-md-5 p-2" CommandName="UpdateProduct" CommandArgument='<%#Eval("ID")%>'/> 
                                <asp:Button ID="Btn_DeleteProduct" runat="server"  Text="Delete" Font-Size="X-Small" class="btn btn-primary col-md-5 p-2 float-right btn-danger" CommandName="DeleteProduct" CommandArgument='<%#Eval("ID")%>'/> 
                            </div>
                        </asp:Panel>
                    </div>                  
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
