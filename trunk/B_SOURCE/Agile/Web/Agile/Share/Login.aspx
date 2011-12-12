<%@ Page Title="" Language="C#" MasterPageFile="~/Share/Master.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Agile.Share.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="LoginForm" runat="server" OnAuthenticate="LoginForm_Authenticate">
    </asp:Login>
</asp:Content>
