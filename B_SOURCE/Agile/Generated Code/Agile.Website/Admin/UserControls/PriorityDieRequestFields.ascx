<%@ Control Language="C#" ClassName="PriorityDieRequestFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriorityDieRequestName" runat="server" Text="Priority Die Request Name:" AssociatedControlID="dataPriorityDieRequestName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriorityDieRequestName" Text='<%# Bind("PriorityDieRequestName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriorityDieRequestDescription" runat="server" Text="Priority Die Request Description:" AssociatedControlID="dataPriorityDieRequestDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriorityDieRequestDescription" Text='<%# Bind("PriorityDieRequestDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataColor" runat="server" Text="Color:" AssociatedControlID="dataColor" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataColor" Text='<%# Bind("Color") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataColorName" runat="server" Text="Color Name:" AssociatedControlID="dataColorName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataColorName" Text='<%# Bind("ColorName") %>' MaxLength="150"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriorityDieRequestOrder" runat="server" Text="Priority Die Request Order:" AssociatedControlID="dataPriorityDieRequestOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriorityDieRequestOrder" Text='<%# Bind("PriorityDieRequestOrder") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPriorityDieRequestOrder" runat="server" Display="Dynamic" ControlToValidate="dataPriorityDieRequestOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


