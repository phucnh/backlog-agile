<%@ Control Language="C#" ClassName="DieTypeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataInitial" runat="server" Text="Initial:" AssociatedControlID="dataInitial" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInitial" Text='<%# Bind("Initial") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieTypeName" runat="server" Text="Die Type Name:" AssociatedControlID="dataDieTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieTypeName" Text='<%# Bind("DieTypeName") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsDefault" runat="server" Text="Is Default:" AssociatedControlID="dataIsDefault" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsDefault" SelectedValue='<%# Bind("IsDefault") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSelected" runat="server" Text="Selected:" AssociatedControlID="dataSelected" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSelected" SelectedValue='<%# Bind("Selected") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActive" runat="server" Text="Active:" AssociatedControlID="dataActive" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataActive" SelectedValue='<%# Bind("Active") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrder" runat="server" Text="Order:" AssociatedControlID="dataOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrder" Text='<%# Bind("Order") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataOrder" runat="server" Display="Dynamic" ControlToValidate="dataOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProjectId" runat="server" Text="Project Id:" AssociatedControlID="dataProjectId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProjectId" Text='<%# Bind("ProjectId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataProjectId" runat="server" Display="Dynamic" ControlToValidate="dataProjectId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


