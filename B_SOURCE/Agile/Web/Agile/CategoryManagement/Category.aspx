<%@ Page Title="" Language="C#" MasterPageFile="~/Share/Master.Master" AutoEventWireup="true"
    CodeBehind="Category.aspx.cs" Inherits="Agile.CategoryManagement.Category" %>

<%@ Register TagPrefix="UC" TagName="CategoryList" Src="~/CategoryManagement/Controls/CategoryList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <UC:CategoryList runat="server" ID="CategoryList" />
</asp:Content>
