<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs"
    Inherits="Agile.CategoryManagement.Controls.CategoryList" %>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingCategoryList" runat="server" Skin="Default">
</telerik:RadAjaxLoadingPanel>
<telerik:RadAjaxPanel ID="RadAjaxPanelCategoryList" LoadingPanelID="RadAjaxLoadingCategoryList"
    runat="server" CssClass="main_block">
    <%--<div class="main_block">--%>
        <telerik:RadListView runat="server" ID="livCategoryList" DataSourceID="DieCategoryDataSource"
            ItemPlaceholderID="plhCategoryList" OnItemCommand="livCategoryList_ItemCommand"
            OnItemDataBound="livCategoryList_ItemDataBound">
            <LayoutTemplate>
                <div class="header">
                    Category</div>
                <div class="content">
                    <br />
                    <asp:LinkButton runat="server" ID="lbtnInsert" Text="Insert" OnClick="lbtnInsert_Click" />
                    <br />
                    <br />
                    <asp:PlaceHolder runat="server" ID="plhCategoryList" />
                    <br />
                </div>
                <div class="footer">
                </div>
            </LayoutTemplate>
            <InsertItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblDIECategoryName" Text="Category Name" AssociatedControlI="DIECategoryName" />
                        </td>
                        <td>
                            <telerik:RadTextBox runat="server" ID="DIECategoryName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblDEICategoryDescription" Text="Description" AssociatedControlID="DEICategoryDescription" />
                        </td>
                        <td>
                            <telerik:RadTextBox runat="server" ID="DEICategoryDescription" Rows="3" TextMode="MultiLine" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton runat="server" ID="btnPerformInsert" Text="Insert" CommandName="Insert" />
                        </td>
                        <td>
                            <telerik:RadButton runat="server" ID="btnCancel" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                <div>
                    <asp:Literal runat="server" ID="CategoryName" Text='<%# Bind("DIECategoryName") %>' />&nbsp;
                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server" Text="Edit" />
                </div>
                <div>
                    <br />
                    <asp:Panel ID="pnlPercent" runat="server" Width="80%">
                    </asp:Panel>
                    <br />
                    <br />
                </div>
            </ItemTemplate>
            <EditItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblDIECategoryName" Text="Category Name" AssociatedControlI="DIECategoryName" />
                        </td>
                        <td>
                            <telerik:RadTextBox runat="server" ID="DIECategoryName" Text='<%# Eval("DIECategoryName") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblDEICategoryDescription" Text="Description" AssociatedControlID="DEICategoryDescription" />
                        </td>
                        <td>
                            <telerik:RadTextBox runat="server" ID="DEICategoryDescription" Rows="3" TextMode="MultiLine"
                                Text='<%# Eval("DEICategoryDescription") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton runat="server" ID="btnPerformInsert" Text="Insert" CommandName="Update" />
                        </td>
                        <td>
                            <telerik:RadButton runat="server" ID="btnCancel" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </telerik:RadListView>
    <%--</div>--%>
    <data:DieCategoryDataSource ID="DieCategoryDataSource" runat="server" EnablePaging="True"
        EnableSorting="True">
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
        </Parameters>
    </data:DieCategoryDataSource>
</telerik:RadAjaxPanel>
