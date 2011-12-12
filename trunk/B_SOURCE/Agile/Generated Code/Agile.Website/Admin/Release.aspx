
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Release.aspx.cs" Inherits="Release" Title="Release List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Release List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ReleaseDataSource"
				DataKeyNames="ReleaseId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Release.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ProjectId" HeaderText="Project Id" SortExpression="[ProjectID]"  />
				<asp:BoundField DataField="ReleaseDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Release Date" SortExpression="[ReleaseDate]"  />
				<asp:BoundField DataField="ReleaseName" HeaderText="Release Name" SortExpression="[ReleaseName]"  />
				<asp:BoundField DataField="ReleaseNote" HeaderText="Release Note" SortExpression="[ReleaseNote]"  />
				<data:BoundRadioButtonField DataField="Active" HeaderText="Active" SortExpression="[Active]"  />
				<asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="[UserID]"  />
				<asp:BoundField DataField="LastUserUpdate" HeaderText="Last User Update" SortExpression="[LastUserUpdate]"  />
				<asp:BoundField DataField="LastDateUpdate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Date Update" SortExpression="[LastDateUpdate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Release Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnRelease" OnClientClick="javascript:location.href='ReleaseEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ReleaseDataSource ID="ReleaseDataSource" runat="server"
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
		</data:ReleaseDataSource>
	    		
</asp:Content>



