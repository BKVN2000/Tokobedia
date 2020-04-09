<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Tokobedia.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
<form id="form1" runat="server">
      <div class="form-group">
            <label for="NameTxt">Email</label>
            <asp:textbox ID="EmailTxt" class="form-control" runat="server" type="email"></asp:textbox>
      </div>

      <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <asp:textbox ID="PasswodTxt" class="form-control" runat="server" type="password"></asp:textbox>
      </div>
        <div class="form-group form-check">
            <asp:CheckBox ID="ChkBox_RememberMe" runat="server" Text="Remember Me" class="form-check-input"/>  
        </div>
      <asp:Button runat="server" class="btn btn-primary" OnClick="Btn_LogInOnclick" Text="Log-in"/>
</form>
</body>
</html>
