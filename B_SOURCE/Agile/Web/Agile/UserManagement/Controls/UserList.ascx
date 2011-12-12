<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserList.ascx.cs" Inherits="Agile.UserManagement.Controls.UserList" %>
<telerik:RadAjaxLoadingPanel ID="AjaxUserListLoadingPanel" runat="server" Skin="Default">
</telerik:RadAjaxLoadingPanel>
<telerik:RadAjaxPanel runat="server" ID="AjaxUserList" LoadingPanelID="AjaxUserListLoadingPanel"
    ClientIDMode="AutoID" EnableAJAX="true">
    <div class="main_block">
        <telerik:RadListView runat="server" ID="livUserList" DataSourceID="UserDataSource"
            ItemPlaceholderID="plhUserList" AllowPaging="True" DataMember="UserName">
            <LayoutTemplate>
                <div class="header">
                    Project Member</div>
                <div class="content">
                    <asp:PlaceHolder runat="server" ID="plhUserList" />
                </div>
                <div class="footer" style="height: 55px">
                    <br />
                    <telerik:RadDataPager ID="UserRadDataPager" runat="server" PagedControlID="livUserList">
                        <Fields>
                            <telerik:RadDataPagerButtonField FieldType="Numeric" />
                        </Fields>
                    </telerik:RadDataPager>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="main_block_item">
                    <br />
                    <asp:Literal runat="server" ID="litUsername" Text='<%# Bind("UserName") %>' />
                    <br />
                </div>
            </ItemTemplate>
        </telerik:RadListView>
    </div>
    <data:UserDataSource ID="UserDataSource" runat="server" EnablePaging="true" EnableSorting="true"
        Sort="UserName">
    </data:UserDataSource>
</telerik:RadAjaxPanel>
<%--<data:DieCategoryDataSource ID="DieCategoryDataSource" runat="server" EnablePaging="True"
    EnableSorting="True">
    <Parameters>
        <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
        <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
    </Parameters>
</data:DieCategoryDataSource>
--%>