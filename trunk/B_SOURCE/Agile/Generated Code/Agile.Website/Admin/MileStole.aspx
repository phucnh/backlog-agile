
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="MileStole.aspx.cs" Inherits="MileStole" Title="MileStole List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Mile Stole List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="MileStoleDataSource"
				DataKeyNames="MileStoleId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_MileStole.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MileStoleName" HeaderText="Mile Stole Name" SortExpression="[MileStoleName]"  />
				<asp:BoundField DataField="OriginalDueDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Original Due Date" SortExpression="[OriginalDueDate]"  />
				<asp:BoundField DataField="RevisedDueDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Revised Due Date" SortExpression="[RevisedDueDate]"  />
				<asp:BoundField DataField="CompleteDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Complete Date" SortExpression="[CompleteDate]"  />
				<asp:BoundField DataField="Progress" HeaderText="Progress" SortExpression="[Progress]"  />
				<asp:BoundField DataField="ProjectId" HeaderText="Project Id" SortExpression="[ProjectID]"  />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
				<asp:BoundField DataField="MileStoleOrder" HeaderText="Mile Stole Order" SortExpression="[MileStoleOrder]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No MileStole Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnMileStole" OnClientClick="javascript:location.href='MileStoleEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:MileStoleDataSource ID="MileStoleDataSource" runat="server"
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
		</data:MileStoleDataSource>
	    		
</asp:Content>



