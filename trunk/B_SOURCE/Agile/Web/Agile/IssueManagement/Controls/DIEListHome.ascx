<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DIEListHome.ascx.cs"
    Inherits="Agile.IssueManagement.Controls.DIEListHome" %>
<%@ Import Namespace="Agile.Common" %>
<%@ Import Namespace="Agile.Entities" %>
<data:EntityGridView ID="grvDieRequest" runat="server" AutoGenerateColumns="False"
    DataSourceID="HomeDieRequestDataSource" DataKeyNames="DieRequestId" AllowMultiColumnSorting="false"
    DefaultSortColumnName="DieDateSubmit" DefaultSortDirection="Descending" AllowExportToExcel="false"
    Width="100%" PagerSettings-Position="Bottom" PagerSettings-Mode="NextPreviousFirstLast"
    PageIndex="1" PageSize="50" AllowPaging="true" PagerStyle-CssClass="home_issue_pagger"
    ShowHeader="false">
    <RowStyle CssClass="home_issue_row" />
    <HeaderStyle CssClass="home_issue_header" />
    <AlternatingRowStyle CssClass="home_issue_alternating_row" />
    <Columns>
        <asp:BoundField DataField="DIETypeName" HeaderText="Die Type" ItemStyle-Width="10%"
            ItemStyle-BorderStyle="None" />
        <%--<data:HyperLinkField HeaderText="Die Type" ItemStyle-Width="10%" ItemStyle-BorderStyle="None"
            DataNavigateUrlFormatString="DieTypeEdit.aspx?DieTypeId={0}" DataNavigateUrlFields="DieTypeId"
            DataContainer="DieTypeIdSource" DataTextField="Initial" />--%>
        <asp:BoundField DataField="DieTag" HeaderText="Key" ItemStyle-Width="10%" ItemStyle-BorderStyle="None"
            SortExpression="[DIETag]" />
        <asp:TemplateField ItemStyle-Width="20%" ItemStyle-BorderStyle="None">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litUserUpdate" Text='<%# Bind("UserName") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-CssClass="home_issue_subject_cell" ItemStyle-Width="30%">
            <ItemTemplate>
                <asp:Label runat="server" ID="litDieName" Text='<%# Bind("DieName") %>' /><br />
                <asp:Label ForeColor="Gray" runat="server" ID="litStatus" Text='<%# Bind("DIENameStatus") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:BoundField DataField="UpdateTime" ItemStyle-BorderStyle="None" DataFormatString="{0:M}"
            HtmlEncode="False" HeaderText="Update Time" SortExpression="[UpdateTime]" />--%>
        <asp:TemplateField HeaderText="Update Time">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litUpdateTime" Text='<%# Ultility.GetTimeStringNow(((HomeDieRequest)Container.DataItem).UpdateTime)  %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <%--<data:HyperLinkField HeaderText="Project Id" DataNavigateUrlFormatString="ProjectEdit.aspx?ProjectId={0}"
            DataNavigateUrlFields="ProjectId" DataContainer="ProjectIdSource" DataTextField="ProjectName" />--%>
        <%--<data:HyperLinkField HeaderText="Status" HeaderStyle-Width="7%" DataNavigateUrlFormatString="DieStatusEdit.aspx?DieStatus={0}"
            DataNavigateUrlFields="DieStatus" DataContainer="DieStatusSource" DataTextField="DieNameStatus" />--%>
    </Columns>
    <EmptyDataTemplate>
        <b>No DieRequest Found!</b>
    </EmptyDataTemplate>
</data:EntityGridView>
<data:HomeDieRequestDataSource runat="server" ID="HomeDieRequestDataSource" SelectMethod="GetPaged"
    EnablePaging="true" EnableSorting="true">
</data:HomeDieRequestDataSource>
