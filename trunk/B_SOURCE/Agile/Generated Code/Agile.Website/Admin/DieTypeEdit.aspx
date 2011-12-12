<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DieTypeEdit.aspx.cs" Inherits="DieTypeEdit" Title="DieType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Die Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="DieTypeId" runat="server" DataSourceID="DieTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DieTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DieTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>DieType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DieTypeDataSource ID="DieTypeDataSource" runat="server"
			SelectMethod="GetByDieTypeId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="DieTypeId" QueryStringField="DieTypeId" Type="String" />

			</Parameters>
		</data:DieTypeDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewDieRequest1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewDieRequest1_SelectedIndexChanged"			 			 
			DataSourceID="DieRequestDataSource1"
			DataKeyNames="DieRequestId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_DieRequest.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="DieName" HeaderText="Die Name" SortExpression="[DIEName]" />				
				<asp:BoundField DataField="DieTag" HeaderText="Die Tag" SortExpression="[DIETag]" />				
				<asp:BoundField DataField="DieDescription" HeaderText="Die Description" SortExpression="[DIEDescription]" />				
				<data:HyperLinkField HeaderText="Die Type Id" DataNavigateUrlFormatString="DieTypeEdit.aspx?DieTypeId={0}" DataNavigateUrlFields="DieTypeId" DataContainer="DieTypeIdSource" DataTextField="Initial" />
				<data:HyperLinkField HeaderText="Resolutions Id" DataNavigateUrlFormatString="ResolutionsEdit.aspx?ResolutionsId={0}" DataNavigateUrlFields="ResolutionsId" DataContainer="ResolutionsIdSource" DataTextField="ResolutionsName" />
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<data:HyperLinkField HeaderText="Project Id" DataNavigateUrlFormatString="ProjectEdit.aspx?ProjectId={0}" DataNavigateUrlFields="ProjectId" DataContainer="ProjectIdSource" DataTextField="ProjectName" />
				<data:HyperLinkField HeaderText="Die Status" DataNavigateUrlFormatString="DieStatusEdit.aspx?DieStatus={0}" DataNavigateUrlFields="DieStatus" DataContainer="DieStatusSource" DataTextField="DieNameStatus" />
				<data:HyperLinkField HeaderText="Priority Die Request Id" DataNavigateUrlFormatString="PriorityDieRequestEdit.aspx?PriorityDieRequestId={0}" DataNavigateUrlFields="PriorityDieRequestId" DataContainer="PriorityDieRequestIdSource" DataTextField="PriorityDieRequestName" />
				<asp:BoundField DataField="DieDateSubmit" HeaderText="Die Date Submit" SortExpression="[DIEDateSubmit]" />				
				<data:HyperLinkField HeaderText="Code By" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="CodeBySource" DataTextField="UserName" />
				<data:HyperLinkField HeaderText="Owner" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="OwnerSource" DataTextField="UserName" />
				<asp:BoundField DataField="UpdateTime" HeaderText="Update Time" SortExpression="[UpdateTime]" />				
				<data:HyperLinkField HeaderText="Last User Update" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="LastUserUpdateSource" DataTextField="UserName" />
				<asp:BoundField DataField="TargetDate" HeaderText="Target Date" SortExpression="[TargetDate]" />				
				<data:HyperLinkField HeaderText="Completed Release Id" DataNavigateUrlFormatString="ReleaseEdit.aspx?ReleaseId={0}" DataNavigateUrlFields="ReleaseId" DataContainer="CompletedReleaseIdSource" DataTextField="ProjectId" />
				<data:HyperLinkField HeaderText="Milestone Id" DataNavigateUrlFormatString="MileStoleEdit.aspx?MileStoleId={0}" DataNavigateUrlFields="MileStoleId" DataContainer="MilestoneIdSource" DataTextField="MileStoleName" />
				<data:HyperLinkField HeaderText="Die Category Id" DataNavigateUrlFormatString="DieCategoryEdit.aspx?DieCategoryId={0}" DataNavigateUrlFields="DieCategoryId" DataContainer="DieCategoryIdSource" DataTextField="DieCategoryName" />
				<asp:BoundField DataField="Estimated" HeaderText="Estimated" SortExpression="[Estimated]" />				
				<asp:BoundField DataField="Actual" HeaderText="Actual" SortExpression="[Actual]" />				
				<data:HyperLinkField HeaderText="Parent Die" DataNavigateUrlFormatString="DieRequestEdit.aspx?DieRequestId={0}" DataNavigateUrlFields="DieRequestId" DataContainer="ParentDieSource" DataTextField="DieName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Die Request Found! </b>
				<asp:HyperLink runat="server" ID="hypDieRequest" NavigateUrl="~/admin/DieRequestEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:DieRequestDataSource ID="DieRequestDataSource1" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:DieRequestFilter  Column="DieTypeId" QueryStringField="DieTypeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:DieRequestDataSource>		
		
		<br />
		

</asp:Content>

