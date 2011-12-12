<%@ Control Language="C#" ClassName="DieCategoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieCategoryName" runat="server" Text="Die Category Name:" AssociatedControlID="dataDieCategoryName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieCategoryName" Text='<%# Bind("DieCategoryName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDeiCategoryDescription" runat="server" Text="Dei Category Description:" AssociatedControlID="dataDeiCategoryDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDeiCategoryDescription" Text='<%# Bind("DeiCategoryDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


