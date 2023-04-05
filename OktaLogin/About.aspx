<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OktaLogin.About" %>
<%@ Import Namespace="System.Security.Claims" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <h2>OpenID Connect Claims</h2>
    <dl>
        <asp:DataList runat="server" ID="dlClaims">
            <ItemTemplate>
                <dt><%# ((Claim) Container.DataItem).Type %></dt>
                <dd><%# ((Claim) Container.DataItem).Value %></dd>
            </ItemTemplate>
        </asp:DataList>
    </dl>
</asp:Content>
