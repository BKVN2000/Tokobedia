<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="Tokobedia.View.ViewProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-10">
            <asp:GridView runat="server" ID="Gv_ProductType">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkSelect" runat="server" Text="Update" CommandArgument='<%#Eval("Id") %>' OnClick="linkUpdate_Click" />
                            <asp:LinkButton ID="LinkBtn_Delete" runat="server" Text="Delete" CommandArgument='<%#Eval("Id") %>' OnClick="linkDeleteTriggerModal_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

       <div class="col-md-2">
            <asp:Button ID="Btn_InsertNewType" runat="server" Text="Insert New Product Type" class="btn btn-primary float-right" OnClick="Btn_InsertProductTypeOnClick"/>
       </div>
    </div>

    <div class="modal" id="DeleteModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Confirmation</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p><asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label></p>
                        </div>
                        <asp:HiddenField id="HdnProductTypeId" runat="server"/>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button id="Btn_DeleteProductType" runat="server" class="btn btn-primary" OnClick="Btn_DeleteProductTypeOnclick" Text="Yes"/>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
