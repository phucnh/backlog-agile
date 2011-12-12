<%@ Page Title="" Language="C#" MasterPageFile="~/Share/Master.Master" AutoEventWireup="true"
    CodeBehind="FindIssue.aspx.cs" Inherits="Agile.IssueManagement.FindIssue" %>

<%@ Register TagPrefix="uc" TagName="IssueList" Src="~/IssueManagement/Controls/DieList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="home_header">
        Find issues</h1>
    <br />
    
        <asp:Panel runat="server" ID="pnlConditions">
            <div class="conditions">
                <div class="header">
                    <h2>
                        Search</h2>
                    <span style="margin-left: 8%">
                        <asp:Label runat='server' ID="lblProjectSearch" Text="Project: " />
                        <telerik:RadComboBox runat="server" ID="ddlProject" DataSourceID="ProjectDataSource1"
                            DataMember="ProjectID" DataValueField="ProjectID" DataTextField="ProjectName"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </span>
                    <br />
                    <br />
                </div>
                <div class="field">
                    <br />
                    <table>
                        <tr>
                            <td>
                                Status
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lbtnStatusAll" Text="All" OnClick="lbtnStatusAll_Click" />
                                <asp:Repeater ID="rptDieStatus" runat="server" DataSourceID="DieStatusDataSource1"
                                    OnItemDataBound="rptDieStatus_ItemDataBound" OnItemCommand="rptDieStatus_ItemCommand">
                                    <ItemTemplate>
                                        |&nbsp;<asp:LinkButton runat="server" ID="lbtnStatusName" CommandName="Filter" CommandArgument='<%# Bind("DieStatus") %>'
                                            Text='<%# Bind("DIENameStatus") %>' OnClick="lbtnStatusName_Click" />&nbsp;
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Category
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lbtnCategoryAll" Text="All" OnClick="lbtnCategoryAll_Click" />
                                <asp:Repeater ID="rptDieCategory" runat="server" DataSourceID="DieCategoryDataSource1"
                                    OnItemCommand="rptDieCategory_ItemCommand" OnItemDataBound="rptDieCategory_ItemDataBound">
                                    <ItemTemplate>
                                        |&nbsp;<asp:LinkButton runat="server" ID="lbtnCategoryName" CommandName="Filter"
                                            CommandArgument='<%# Bind("DIECategoryID") %>' Text='<%# Bind("DIECategoryName") %>' />&nbsp;
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                MileStone
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lbtnMileStoneAll" Text="All" OnClick="lbtnMileStoneAll_Click" />
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="MileStoleDataSource1" OnItemCommand="Repeater1_ItemCommand"
                                    OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        |&nbsp;<asp:LinkButton runat="server" ID="lbtnMileStoneName" CommandName="Filter"
                                            CommandArgument='<%# Bind("MileStoleID") %>' Text='<%# Bind("MileStoleName") %>' />&nbsp;
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
            </div>
            <data:ProjectDataSource ID="ProjectDataSource1" runat="server" SelectMethod="GetAll" />
            <data:DieStatusDataSource ID="DieStatusDataSource1" runat="server" SelectMethod="GetAll" />
            <data:DieCategoryDataSource ID="DieCategoryDataSource1" runat="server" SelectMethod="GetAll" />
            <data:MileStoleDataSource ID="MileStoleDataSource1" runat="server" SelectMethod="GetAll" />
        </asp:Panel>
        <br />
        <br />
        <uc:IssueList runat="server" ID="ucIssueList" />
</asp:Content>
