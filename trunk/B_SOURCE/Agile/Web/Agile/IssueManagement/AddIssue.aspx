<%@ Page Title="" Language="C#" MasterPageFile="~/Share/Master.Master" AutoEventWireup="true"
    CodeBehind="AddIssue.aspx.cs" Inherits="Agile.IssueManagement.AddIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="home_header">
        Project Home</h1>
    <br />
    <br />
    <data:MultiFormView ID="FormView1" DataKeyNames="DieRequestId" runat="server" DataSourceID="DieRequestDataSource"
        CssClass="add_issue_wrapper" Height="57px">
        <EditItemTemplatePaths>
            <data:TemplatePath Path="Controls/DieRequestFields.ascx" />
        </EditItemTemplatePaths>
        <InsertItemTemplatePaths>
            <data:TemplatePath Path="Controls/DieRequestFields.ascx" />
        </InsertItemTemplatePaths>
        <EmptyDataTemplate>
            <b>DieRequest not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <br />
            <br />
            <telerik:RadButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert">
            </telerik:RadButton>
            <telerik:RadButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            <telerik:RadButton ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
        </FooterTemplate>
    </data:MultiFormView>
    <data:DieRequestDataSource ID="DieRequestDataSource" runat="server" SelectMethod="GetByDieRequestId"
        OnInserting="DieRequestDataSource_Inserting" OnInserted="DieRequestDataSource_Inserted"
        OnAfterUpdated="DieRequestDataSource_AfterUpdated">
        <Parameters>
            <asp:QueryStringParameter Name="DieRequestId" QueryStringField="DieRequestId" Type="String" />
        </Parameters>
    </data:DieRequestDataSource>
</asp:Content>
