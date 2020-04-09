<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Tokobedia.View.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="gv_ViewUsers">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="linkSelect" runat="server" Text="Update" CommandArgument='<%#Eval("Id") %>' OnClick="linkUpdate_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Role.Name" HeaderText="RoleName"/>
       </Columns>
    </asp:GridView>

        <%--<!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Edit Profile</h4>
                            </div>
                            <div class="modal-body">
                                  <div class="form-group">
                                        <label for="NameTxt">Role</label>
                                        <asp:DropDownList ID="ddl_Role" runat="server" class="form-control">
                                        </asp:DropDownList>
                                  </div>

                                  <div class="form-group">
                                    <label for="exampleInputPassword1">Status</label>
                                        <asp:DropDownList ID="ddl_Status" runat="server" class="form-control">
                                            <asp:ListItem Value="Active">Active</asp:ListItem>
                                            <asp:ListItem Value="Blocked">Blocked</asp:ListItem>
                                        </asp:DropDownList>
                                  </div>
                                  <asp:Button runat="server" class="btn btn-primary" OnClick="Btn_UpdateUserOnclick" Text="Update"/>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    <!--End Modal-->--%>

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModal" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Edit Profile</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                        <label for="NameTxt">Role</label>
                        <asp:DropDownList ID="ddl_Role" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Status</label>
                        <asp:DropDownList ID="ddl_Status" runat="server" class="form-control">
                            <asp:ListItem Value="Active">Active</asp:ListItem>
                            <asp:ListItem Value="Blocked">Blocked</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:HiddenField ID="HdnUserId" runat="server" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" class="btn btn-primary" OnClick="Btn_UpdateUserOnclick" Text="Update" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>