
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DieRequest.aspx.cs" Inherits="DieRequest" Title="DieRequest List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Die Request List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DieRequestDataSource"
				DataKeyNames="DieRequestId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DieRequest.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Parent Die" DataNavigateUrlFormatString="DieRequestEdit.aspx?DieRequestId={0}" DataNavigateUrlFields="DieRequestId" DataContainer="ParentDieSource" DataTextField="DieName" />
				<asp:BoundField DataField="DieName" HeaderText="Die Name" SortExpression="[DIEName]"  />
				<asp:BoundField DataField="DieTag" HeaderText="Die Tag" SortExpression="[DIETag]"  />
				<asp:BoundField DataField="DieDescription" HeaderText="Die Description" SortExpression=""  />
				<data:HyperLinkField HeaderText="Die Type Id" DataNavigateUrlFormatString="DieTypeEdit.aspx?DieTypeId={0}" DataNavigateUrlFields="DieTypeId" DataContainer="DieTypeIdSource" DataTextField="Initial" />
				<data:HyperLinkField HeaderText="Resolutions Id" DataNavigateUrlFormatString="ResolutionsEdit.aspx?ResolutionsId={0}" DataNavigateUrlFields="ResolutionsId" DataContainer="ResolutionsIdSource" DataTextField="ResolutionsName" />
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<data:HyperLinkField HeaderText="Project Id" DataNavigateUrlFormatString="ProjectEdit.aspx?ProjectId={0}" DataNavigateUrlFields="ProjectId" DataContainer="ProjectIdSource" DataTextField="ProjectName" />
				<data:HyperLinkField HeaderText="Die Status" DataNavigateUrlFormatString="DieStatusEdit.aspx?DieStatus={0}" DataNavigateUrlFields="DieStatus" DataContainer="DieStatusSource" DataTextField="DieNameStatus" />
				<data:HyperLinkField HeaderText="Priority Die Request Id" DataNavigateUrlFormatString="PriorityDieRequestEdit.aspx?PriorityDieRequestId={0}" DataNavigateUrlFields="PriorityDieRequestId" DataContainer="PriorityDieRequestIdSource" DataTextField="PriorityDieRequestName" />
				<asp:BoundField DataField="DieDateSubmit" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Die Date Submit" SortExpression="[DIEDateSubmit]"  />
				<data:HyperLinkField HeaderText="Code By" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="CodeBySource" DataTextField="UserName" />
				<data:HyperLinkField HeaderText="Owner" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="OwnerSource" DataTextField="UserName" />
				<asp:BoundField DataField="UpdateTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Update Time" SortExpression="[UpdateTime]"  />
				<data:HyperLinkField HeaderText="Last User Update" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="LastUserUpdateSource" DataTextField="UserName" />
				<asp:BoundField DataField="TargetDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Target Date" SortExpression="[TargetDate]"  />
				<data:HyperLinkField HeaderText="Completed Release Id" DataNavigateUrlFormatString="ReleaseEdit.aspx?ReleaseId={0}" DataNavigateUrlFields="ReleaseId" DataContainer="CompletedReleaseIdSource" DataTextField="ProjectId" />
				<data:HyperLinkField HeaderText="Milestone Id" DataNavigateUrlFormatString="MileStoleEdit.aspx?MileStoleId={0}" DataNavigateUrlFields="MileStoleId" DataContainer="MilestoneIdSource" DataTextField="MileStoleName" />
				<data:HyperLinkField HeaderText="Die Category Id" DataNavigateUrlFormatString="DieCategoryEdit.aspx?DieCategoryId={0}" DataNavigateUrlFields="DieCategoryId" DataContainer="DieCategoryIdSource" DataTextField="DieCategoryName" />
				<asp:BoundField DataField="Estimated" HeaderText="Estimated" SortExpression="[Estimated]"  />
				<asp:BoundField DataField="Actual" HeaderText="Actual" SortExpression="[Actual]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DieRequest Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDieRequest" OnClientClick="javascript:location.href='DieRequestEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DieRequestDataSource ID="DieRequestDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DieRequestProperty Name="DieCategory"/> 
					<data:DieRequestProperty Name="DieRequest"/> 
					<data:DieRequestProperty Name="DieStatus"/> 
					<data:DieRequestProperty Name="DieType"/> 
					<data:DieRequestProperty Name="MileStole"/> 
					<data:DieRequestProperty Name="PriorityDieRequest"/> 
					<data:DieRequestProperty Name="Project"/> 
					<data:DieRequestProperty Name="Release"/> 
					<data:DieRequestProperty Name="Resolutions"/> 
					<data:DieRequestProperty Name="User"/> 
					<%--<data:DieRequestProperty Name="DieAttachFileCollection" />--%>
					<%--<data:DieRequestProperty Name="DieRequestCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DieRequestDataSource>
	    		
</asp:Content>



