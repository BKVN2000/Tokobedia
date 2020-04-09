<%@ Page Title="Home" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Tokobedia.View.Home" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="text-center">
            <asp:Panel runat="server" ID ="UnregistedPnl">
                <div class="jumbotron">
                    <div class="container">
                        <div class="row">
                            <div class="col-6">
                                 <img src="<%=ResolveClientUrl("~")%>Assets/Logo.jpg" class="card-img-top">
                            </div>
                            <div class="col-6">
                                <h1 class="display-4">TokeBedia</h1>
                                <p class="lead">Happy Shopping<br>Get your product in Tokobedia</p>
                                <asp:Button ID="Btn_Register" runat="server" onclick="Register_Click" Text="Be A New Member" /> 
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="row">
            <asp:Repeater runat="server" OnItemDataBound="RptProductList_ItemDataBound" ID="RptProductList">
                <ItemTemplate>
                    <div class="card col-2 mr-2" style="width: 18rem;">
                          <img src="<%=ResolveClientUrl("~")%>Assets/box.jpg" class="card-img-top">
                          <div class="card-body">
                              <h5 class="card-title">
                                  <asp:Label runat="server" Text='<%#Eval("Name")%>' id="litProductName"/>
                              </h5>
                              <h6 class="card-subtitle mb-2 text-muted">
                                  <asp:Label runat="server" Text='<%#"Price: "+Eval("Price")%>' id="litRating"/>
                              </h6>      
                              <h6 class="card-subtitle mb-2 text-muted">
                                  <asp:Label runat="server" Text='<%# "Stock: "+Eval("Stock")%>' id="litPrice"/>
                              </h6> 
                          </div>
                     </div>
                </ItemTemplate>
                <SeparatorTemplate>

                </SeparatorTemplate>
            </asp:Repeater>
        </div>
</asp:Content>

