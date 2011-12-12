<%@ Control Language="C#" ClassName="MileStoleFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMileStoleName" runat="server" Text="Mile Stole Name:" AssociatedControlID="dataMileStoleName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMileStoleName" Text='<%# Bind("MileStoleName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOriginalDueDate" runat="server" Text="Original Due Date:" AssociatedControlID="dataOriginalDueDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOriginalDueDate" Text='<%# Bind("OriginalDueDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataOriginalDueDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRevisedDueDate" runat="server" Text="Revised Due Date:" AssociatedControlID="dataRevisedDueDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRevisedDueDate" Text='<%# Bind("RevisedDueDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRevisedDueDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompleteDate" runat="server" Text="Complete Date:" AssociatedControlID="dataCompleteDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompleteDate" Text='<%# Bind("CompleteDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCompleteDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProgress" runat="server" Text="Progress:" AssociatedControlID="dataProgress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProgress" Text='<%# Bind("Progress") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataProgress" runat="server" Display="Dynamic" ControlToValidate="dataProgress" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProjectId" runat="server" Text="Project Id:" AssociatedControlID="dataProjectId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProjectId" Text='<%# Bind("ProjectId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataProjectId" runat="server" Display="Dynamic" ControlToValidate="dataProjectId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMileStoleOrder" runat="server" Text="Mile Stole Order:" AssociatedControlID="dataMileStoleOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMileStoleOrder" Text='<%# Bind("MileStoleOrder") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMileStoleOrder" runat="server" Display="Dynamic" ControlToValidate="dataMileStoleOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


