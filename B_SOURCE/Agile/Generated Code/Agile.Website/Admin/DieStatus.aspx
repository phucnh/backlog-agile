
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DieStatus.aspx.cs" Inherits="DieStatus" Title="DieStatus List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Die Status List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DieStatusDataSource"
				DataKeyNames="DieStatus"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DieStatus.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="DieNameStatus" HeaderText="Die Name Status" SortExpression="[DIENameStatus]"  />
				<asp:BoundField DataField="Order" HeaderText="Order" SortExpression="[Order]"  />
				<data:BoundRadioButtonField DataField="Visible" HeaderText="Visible" SortExpression="[Visible]"  />
				<data:BoundRadioButtonField DataField="Selected" HeaderText="Selected" SortExpression="[Selected]"  />
				<data:BoundRadioButtonField DataField="IsDefault" HeaderText="Is Default" SortExpression="[IsDefault]"  />
				<asp:BoundField DataField="IconLink" HeaderText="Icon Link" SortExpression="[IconLink]"  />
				<data:BoundRadioButtonField DataField="IsCompleted" HeaderText="Is Completed" SortExpression="[IsCompleted]"  />
				<asp:BoundField DataField="Color" HeaderText="Color" SortExpression="[Color]"  />
				<asp:BoundField DataField="ColorName" HeaderText="Color Name" SortExpression="[ColorName]"  />
				<asp:BoundField DataField="ProjectId" HeaderText="Project Id" SortExpression="[ProjectID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DieStatus Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDieStatus" OnClientClick="javascript:location.href='DieStatusEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DieStatusDataSource ID="DieStatusDataSource" runat="server"
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
		</data:DieStatusDataSource>
	    		
</asp:Content>



