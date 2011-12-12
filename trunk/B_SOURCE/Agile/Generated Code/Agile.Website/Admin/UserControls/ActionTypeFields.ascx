<%@ Control Language="C#" ClassName="ActionTypeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataActionTypeName" runat="server" Text="Action Type Name:" AssociatedControlID="dataActionTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActionTypeName" Text='<%# Bind("ActionTypeName") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


