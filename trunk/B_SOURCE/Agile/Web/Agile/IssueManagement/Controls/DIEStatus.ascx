<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DIEStatus.ascx.cs" Inherits="Agile.IssueManagement.Controls.DIEStatus" %>
<div class="main_block">
    <div class="header">
        Status</div>
    <div class="content">
        <br />
        <br />
        <asp:Panel runat="server" ID="pnlPercent">
        </asp:Panel>
        <br />
        <br />
        <div>
            <asp:Repeater runat="server" ID="rptDIEStatus" DataSourceID="DieStatusDataSource"
                DataMember="DIEStatus" onitemdatabound="rptDIEStatus_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbtnDIENameStatus" Text='<%# Bind("DIENameStatus") %>' />
                    <asp:Literal runat="server" ID="litCountDIE" Text='' />&nbsp;|&nbsp;
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="footer">
    </div>
</div>
<data:DieRequestDataSource runat="server" ID="DieRequestDataSource" SelectMethod="GetAll" />
<data:DieStatusDataSource runat="server" ID="DieStatusDataSource" SelectMethod="GetAll" />
