
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DieAttachFile.aspx.cs" Inherits="DieAttachFile" Title="DieAttachFile List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Die Attach File List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DieAttachFileDataSource"
				DataKeyNames="DieAttachFileId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DieAttachFile.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="DieFileUrl" HeaderText="Die File Url" SortExpression="[DIEFileUrl]"  />
				<data:HyperLinkField HeaderText="Die Request Id" DataNavigateUrlFormatString="DieRequestEdit.aspx?DieRequestId={0}" DataNavigateUrlFields="DieRequestId" DataContainer="DieRequestIdSource" DataTextField="DieName" />
				<asp:BoundField DataField="DieFileName" HeaderText="Die File Name" SortExpression="[DIEFileName]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DieAttachFile Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDieAttachFile" OnClientClick="javascript:location.href='DieAttachFileEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DieAttachFileDataSource ID="DieAttachFileDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DieAttachFileProperty Name="DieRequest"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DieAttachFileDataSource>
	    		
</asp:Content>



