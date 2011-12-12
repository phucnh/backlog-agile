
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DieHistory.aspx.cs" Inherits="DieHistory" Title="DieHistory List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Die History List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DieHistoryDataSource"
				DataKeyNames="DieHistoryId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DieHistory.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="DieRequestId" HeaderText="Die Request Id" SortExpression="[DIERequestID]"  />
				<asp:BoundField DataField="DieDateSubmit" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Die Date Submit" SortExpression="[DIEDateSubmit]"  />
				<asp:BoundField DataField="DieStatus" HeaderText="Die Status" SortExpression="[DIEStatus]"  />
				<asp:BoundField DataField="DieHistoryNote" HeaderText="Die History Note" SortExpression="[DIEHistoryNote]"  />
				<asp:BoundField DataField="DieHistoryNoteJp" HeaderText="Die History Note Jp" SortExpression="[DIEHistoryNoteJP]"  />
				<asp:BoundField DataField="ReleaseId" HeaderText="Release Id" SortExpression="[ReleaseID]"  />
				<asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="[UserID]"  />
				<asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="[Owner]"  />
				<asp:BoundField DataField="LastUserUpdate" HeaderText="Last User Update" SortExpression="[LastUserUpdate]"  />
				<asp:BoundField DataField="LastTimeUpdate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Time Update" SortExpression="[LastTimeUpdate]"  />
				<asp:BoundField DataField="ActionTypeId" HeaderText="Action Type Id" SortExpression="[ActionTypeID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DieHistory Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDieHistory" OnClientClick="javascript:location.href='DieHistoryEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DieHistoryDataSource ID="DieHistoryDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DieHistoryDataSource>
	    		
</asp:Content>



