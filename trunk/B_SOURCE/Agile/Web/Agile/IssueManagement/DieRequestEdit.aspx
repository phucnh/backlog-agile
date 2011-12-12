<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Share/Master.Master" AutoEventWireup="true" Inherits="DieRequestEdit" Title="DieRequest Edit" Codebehind="DieRequestEdit.aspx.cs" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">Die Request - Add/Edit</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="DieRequestId" runat="server" DataSourceID="DieRequestDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="DieRequestFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="DieRequestFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>DieRequest not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DieRequestDataSource ID="DieRequestDataSource" runat="server"
			SelectMethod="GetByDieRequestId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="DieRequestId" QueryStringField="DieRequestId" Type="String" />

			</Parameters>
		</data:DieRequestDataSource>
		
		<br />

</asp:Content>

