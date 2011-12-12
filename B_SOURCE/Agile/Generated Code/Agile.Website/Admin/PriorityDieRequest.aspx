
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PriorityDieRequest.aspx.cs" Inherits="PriorityDieRequest" Title="PriorityDieRequest List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Priority Die Request List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="PriorityDieRequestDataSource"
				DataKeyNames="PriorityDieRequestId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_PriorityDieRequest.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="PriorityDieRequestName" HeaderText="Priority Die Request Name" SortExpression="[PriorityDIERequestName]"  />
				<asp:BoundField DataField="PriorityDieRequestDescription" HeaderText="Priority Die Request Description" SortExpression=""  />
				<asp:BoundField DataField="Color" HeaderText="Color" SortExpression="[Color]"  />
				<asp:BoundField DataField="ColorName" HeaderText="Color Name" SortExpression="[ColorName]"  />
				<asp:BoundField DataField="PriorityDieRequestOrder" HeaderText="Priority Die Request Order" SortExpression="[PriorityDIERequestOrder]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No PriorityDieRequest Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnPriorityDieRequest" OnClientClick="javascript:location.href='PriorityDieRequestEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:PriorityDieRequestDataSource ID="PriorityDieRequestDataSource" runat="server"
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
		</data:PriorityDieRequestDataSource>
	    		
</asp:Content>



