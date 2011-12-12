<%@ Page Title="" Language="C#" MasterPageFile="~/Share/Master.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="Agile.Share.Home" %>

<%@ Register TagPrefix="uc" TagName="DIEListHome" Src="~/IssueManagement/Controls/DIEListHome.ascx" %>
<%@ Register TagPrefix="uc" TagName="DIEStatus" Src="~/IssueManagement/Controls/DIEStatus.ascx" %>
<%@ Register TagPrefix="uc" TagName="DIECategory" Src="~/CategoryManagement/Controls/CategoryList.ascx" %>
<%@ Register TagPrefix="uc" TagName="DIEMember" Src="~/UserManagement/Controls/UserList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div style="width: 66%; float: left;">
        <h1 class="home_header" style="width: 97.7%;">
            Project Home</h1>
        <div style="width: 100%;">
            <uc:DIEListHome runat="server" ID="DIEListHome1" />
        </div>
    </div>
    <div style="width: 30%; float: right;">
        <br />
        <div>
            <uc:DIEStatus runat="server" ID="DIEStatue1" />
        </div>
        <br />
        <br />
        <div>
            <uc:DIECategory runat="Server" id="DIECategory1" />
        </div>
        <br />
        <br />
        <div>
            <uc:DIEMember runat="server" id="DIEMember1" /></div>
    </div>
</asp:Content>
