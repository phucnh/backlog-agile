<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DieList.ascx.cs" Inherits="Agile.IssueManagement.Controls.DieList" %>
<telerik:RadAjaxLoadingPanel runat="server" ID="DieListAjaxLoadingPanel" />
<telerik:RadAjaxPanel ID="DieListAjaxPanel" runat="server" LoadingPanelID="DieListAjaxLoadingPanel">
    <data:EntityGridView ID="grvDieRequest" runat="server" AutoGenerateColumns="False"
        DataSourceID="DieRequestDataSource" DataKeyNames="DieRequestId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_DieRequest.xls"
        Width="100%" PagerSettings-Position="Top" PagerSettings-Mode="NumericFirstLast"
        PageIndex="1" PageSize="20" AllowPaging="true" PagerStyle-CssClass="issue_pagger"
        OnSelectedIndexChanged="grvDieRequest_SelectedIndexChanged">
        <HeaderStyle CssClass="issue_header" />
        <RowStyle CssClass="issue_row" />
        <AlternatingRowStyle CssClass="issue_alternating_row" />
        <Columns>
            <%--<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />--%>
            <data:HyperLinkField HeaderText="Die Type" HeaderStyle-Width="5%" DataNavigateUrlFormatString="DieTypeEdit.aspx?DieTypeId={0}"
                DataNavigateUrlFields="DieTypeId" DataContainer="DieTypeIdSource" DataTextField="DieTypeName" />
            <asp:BoundField DataField="DieTag" HeaderText="Key" HeaderStyle-Width="5%" SortExpression="[DIETag]" />
            <asp:BoundField DataField="DieName" HeaderText="Subject" HeaderStyle-Width="20%"
                SortExpression="[DIEName]" />
            <data:HyperLinkField HeaderText="Priority" HeaderStyle-Width="2%" DataNavigateUrlFormatString="PriorityDieRequestEdit.aspx?PriorityDieRequestId={0}"
                DataNavigateUrlFields="PriorityDieRequestId" DataContainer="PriorityDieRequestIdSource"
                DataTextField="PriorityDieRequestName" />
            <asp:BoundField DataField="DieDateSubmit" DataFormatString="{0:M}" HtmlEncode="False"
                HeaderText="Date Submit" HeaderStyle-Width="7%" SortExpression="[DIEDateSubmit]" />
            <%--<asp:BoundField DataField="DieDescription" HeaderText="Die Description" SortExpression="" />--%>
            <%--<data:HyperLinkField HeaderText="Resolutions Id" DataNavigateUrlFormatString="ResolutionsEdit.aspx?ResolutionsId={0}"
            DataNavigateUrlFields="ResolutionsId" DataContainer="ResolutionsIdSource" DataTextField="ResolutionsName" />--%>
            <%--<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}"
            DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />--%>
            <asp:BoundField DataField="Estimated" HeaderText="Estimated Hours" HeaderStyle-Width="7%"
                SortExpression="[Estimated]" />
            <asp:BoundField DataField="Actual" HeaderText="Actual Hours" HeaderStyle-Width="7%"
                SortExpression="[Actual]" />
            <asp:BoundField DataField="UpdateTime" DataFormatString="{0:M}" HtmlEncode="False"
                HeaderText="Update Time" HeaderStyle-Width="7%" SortExpression="[UpdateTime]" />
            <%--<data:HyperLinkField HeaderText="Project Id" DataNavigateUrlFormatString="ProjectEdit.aspx?ProjectId={0}"
            DataNavigateUrlFields="ProjectId" DataContainer="ProjectIdSource" DataTextField="ProjectName" />--%>
            <data:HyperLinkField HeaderText="Registered by" HeaderStyle-Width="6%" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}"
                DataNavigateUrlFields="UserId" DataContainer="OwnerSource" SortExpression="[Owner]"
                DataTextField="UserName" />
            <%--<asp:BoundField DataField="Owner" HeaderText="Registered by" HeaderStyle-Width="6%"
            SortExpression="[Owner]" />--%>
            <data:HyperLinkField HeaderText="Assignee" HeaderStyle-Width="6%" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}"
                DataNavigateUrlFields="UserId" DataContainer="CodeBySource" SortExpression="[CodeBy]"
                DataTextField="UserName" />
            <%--<asp:BoundField DataField="CodeBy" HeaderText="Assignee" HeaderStyle-Width="6%" SortExpression="[CodeBy]" />--%>
            <data:HyperLinkField HeaderText="Status" HeaderStyle-Width="7%" DataNavigateUrlFormatString="DieStatusEdit.aspx?DieStatus={0}"
                DataNavigateUrlFields="DieStatus" DataContainer="DieStatusSource" DataTextField="DieNameStatus" />
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label runat="server" ID="lblAttachFileHeader" Text="Attach" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hidDieRequestId" Value='<%# Bind("DIERequestID") %>' />
                    <asp:Repeater runat="server" ID="rptDieAttachFile" DataSourceID="DieAttachFileDataSource"
                        DataMember="DIEAttachFileID">
                        <ItemTemplate>
                            <asp:HyperLink runat='server' ID="hplFileName" Text='<%# Bind("DIEFileName") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    <data:DieAttachFileDataSource runat="server" ID="DieAttachFileDataSource" SelectMethod="GetByDieRequestId">
                        <Parameters>
                        </Parameters>
                    </data:DieAttachFileDataSource>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="LastUserUpdate" HeaderText="Last User Update" SortExpression="[LastUserUpdate]" />--%>
            <%--<asp:BoundField DataField="TargetDate" DataFormatString="{0:d}" HtmlEncode="False"
            HeaderText="Target Date" SortExpression="[TargetDate]" />--%>
            <%--<data:HyperLinkField HeaderText="Completed Release Id" DataNavigateUrlFormatString="ReleaseEdit.aspx?ReleaseId={0}"
            DataNavigateUrlFields="ReleaseId" DataContainer="CompletedReleaseIdSource" DataTextField="ProjectId" />--%>
            <%--<data:HyperLinkField HeaderText="Milestone Id" DataNavigateUrlFormatString="MileStoleEdit.aspx?MileStoleId={0}"
            DataNavigateUrlFields="MileStoleId" DataContainer="MilestoneIdSource" DataTextField="MileStoleName" />--%>
            <%--<data:HyperLinkField HeaderText="Die Category Id" DataNavigateUrlFormatString="DieCategoryEdit.aspx?DieCategoryId={0}"
            DataNavigateUrlFields="DieCategoryId" DataContainer="DieCategoryIdSource" DataTextField="DieCategoryName" />--%>
            <%--<data:HyperLinkField HeaderText="Parent Die" DataNavigateUrlFormatString="DieRequestEdit.aspx?DieRequestId={0}"
            DataNavigateUrlFields="DieRequestId" DataContainer="ParentDieSource" DataTextField="DieName" />--%>
        </Columns>
        <EmptyDataTemplate>
            <b>No DieRequest Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <data:DieRequestDataSource ID="DieRequestDataSource" runat="server" SelectMethod="GetPaged"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:DieRequestProperty Name="DieCategory" />
                <data:DieRequestProperty Name="DieRequest" />
                <data:DieRequestProperty Name="DieStatus" />
                <data:DieRequestProperty Name="DieType" />
                <data:DieRequestProperty Name="MileStole" />
                <data:DieRequestProperty Name="PriorityDieRequest" />
                <data:DieRequestProperty Name="Project" />
                <data:DieRequestProperty Name="Release" />
                <data:DieRequestProperty Name="Resolutions" />
                <data:DieRequestProperty Name="User" />
                <%--<data:DieRequestProperty Name="DieAttachFileCollection" />--%>
                <%--<data:DieRequestProperty Name="DieRequestCollection" />--%>
                <%--<data:DieRequestProperty Name="DieHistoryCollection" />--%>
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <%--<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />--%>
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="grvDieRequest" PropertyName="PageIndex"
                Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="grvDieRequest" PropertyName="PageSize"
                Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:DieRequestDataSource>
</telerik:RadAjaxPanel>
