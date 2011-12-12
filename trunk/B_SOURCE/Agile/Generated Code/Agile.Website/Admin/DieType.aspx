
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DieType.aspx.cs" Inherits="DieType" Title="DieType List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Die Type List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DieTypeDataSource"
				DataKeyNames="DieTypeId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DieType.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Initial" HeaderText="Initial" SortExpression="[Initial]"  />
				<asp:BoundField DataField="DieTypeName" HeaderText="Die Type Name" SortExpression="[DIETypeName]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<data:BoundRadioButtonField DataField="IsDefault" HeaderText="Is Default" SortExpression="[IsDefault]"  />
				<data:BoundRadioButtonField DataField="Selected" HeaderText="Selected" SortExpression="[Selected]"  />
				<data:BoundRadioButtonField DataField="Active" HeaderText="Active" SortExpression="[Active]"  />
				<asp:BoundField DataField="Order" HeaderText="Order" SortExpression="[Order]"  />
				<asp:BoundField DataField="ProjectId" HeaderText="Project Id" SortExpression="[ProjectID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DieType Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDieType" OnClientClick="javascript:location.href='DieTypeEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DieTypeDataSource ID="DieTypeDataSource" runat="server"
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
		</data:DieTypeDataSource>
	    		
</asp:Content>



