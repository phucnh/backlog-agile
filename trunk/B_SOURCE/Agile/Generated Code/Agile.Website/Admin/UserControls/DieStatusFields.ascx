<%@ Control Language="C#" ClassName="DieStatusFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieNameStatus" runat="server" Text="Die Name Status:" AssociatedControlID="dataDieNameStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieNameStatus" Text='<%# Bind("DieNameStatus") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrder" runat="server" Text="Order:" AssociatedControlID="dataOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrder" Text='<%# Bind("Order") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataOrder" runat="server" Display="Dynamic" ControlToValidate="dataOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVisible" runat="server" Text="Visible:" AssociatedControlID="dataVisible" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataVisible" SelectedValue='<%# Bind("Visible") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSelected" runat="server" Text="Selected:" AssociatedControlID="dataSelected" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSelected" SelectedValue='<%# Bind("Selected") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsDefault" runat="server" Text="Is Default:" AssociatedControlID="dataIsDefault" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsDefault" SelectedValue='<%# Bind("IsDefault") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIconLink" runat="server" Text="Icon Link:" AssociatedControlID="dataIconLink" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIconLink" Text='<%# Bind("IconLink") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsCompleted" runat="server" Text="Is Completed:" AssociatedControlID="dataIsCompleted" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsCompleted" SelectedValue='<%# Bind("IsCompleted") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
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
					<asp:TextBox runat="server" ID="dataColorName" Text='<%# Bind("ColorName") %>' MaxLength="10"></asp:TextBox>
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


