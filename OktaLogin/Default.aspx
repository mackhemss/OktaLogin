<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OktaLogin._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
     <asp:LoginView runat="server" ViewStateMode="Disabled">
<AnonymousTemplate>
  <ul class="nav navbar-nav navbar-right">
    <li>
      <a
        href="Site.Master"
        runat="server"
        onserverclick="btnLogin_Click">Login</a>
    </li>
  </ul>
  </AnonymousTemplate>
  <LoggedInTemplate>
    <ul class="nav navbar-nav navbar-right">
      <li>
        <asp:LoginStatus runat="server"
          LogoutAction="Redirect"
          LogoutText="Logout"
          LogoutPageUrl="~/"
        OnLoggingOut="Unnamed_LoggingOut" />
      </li>
    </ul>
  </LoggedInTemplate>
</asp:LoginView>
    </div>

 
</asp:Content>
