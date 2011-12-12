<%@ Control Language="C#" ClassName="ResolutionsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataResolutionsName" runat="server" Text="Resolutions Name:" AssociatedControlID="dataResolutionsName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataResolutionsName" Text='<%# Bind("ResolutionsName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


