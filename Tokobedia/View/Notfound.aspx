<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notfound.aspx.cs" Inherits="Tokobedia.View.Notfound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Error.The Page is either not found or broken 
            </h1>    
            <a class="dropdown-item" href="<%=ResolveClientUrl("~")%>View/Home.aspx">Go Back to Home</a>  
        </div>
    </form>
</body>
</html>
