
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="User.aspx.cs" Inherits="User" Title="User List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">User List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="UserDataSource"
				DataKeyNames="UserId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_User.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]"  />
				<asp:BoundField DataField="PassWord" HeaderText="Pass Word" SortExpression="[PassWord]"  />
				<asp:BoundField DataField="QlnsId" HeaderText="Qlns Id" SortExpression="[QlnsID]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="[EmployeeName]"  />
				<data:BoundRadioButtonField DataField="Remove" HeaderText="Remove" SortExpression="[Remove]"  />
				<data:BoundRadioButtonField DataField="IsLoginSystem" HeaderText="Is Login System" SortExpression="[IsLoginSystem]"  />
				<asp:BoundField DataField="UpdateDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Update Date" SortExpression="[UpdateDate]"  />
				<asp:BoundField DataField="UserUpdate" HeaderText="User Update" SortExpression="[UserUpdate]"  />
				<asp:BoundField DataField="PageDefaultLogin" HeaderText="Page Default Login" SortExpression="[PageDefaultLogin]"  />
				<asp:BoundField DataField="DateCreated" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Created" SortExpression="[DateCreated]"  />
				<asp:BoundField DataField="DateRemoved" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Removed" SortExpression="[DateRemoved]"  />
				<data:BoundRadioButtonField DataField="IsNoBody" HeaderText="Is No Body" SortExpression="[IsNoBody]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No User Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnUser" OnClientClick="javascript:location.href='UserEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:UserDataSource ID="UserDataSource" runat="server"
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
		</data:UserDataSource>
	    		
</asp:Content>



