
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Project.aspx.cs" Inherits="Project" Title="Project List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Project List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProjectDataSource"
				DataKeyNames="ProjectId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Project.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ProjectName" HeaderText="Project Name" SortExpression="[ProjectName]"  />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]"  />
				<asp:BoundField DataField="Deadline" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Deadline" SortExpression="[Deadline]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<data:BoundRadioButtonField DataField="Active" HeaderText="Active" SortExpression="[Active]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Project Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProject" OnClientClick="javascript:location.href='ProjectEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ProjectDataSource ID="ProjectDataSource" runat="server"
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
		</data:ProjectDataSource>
	    		
</asp:Content>



