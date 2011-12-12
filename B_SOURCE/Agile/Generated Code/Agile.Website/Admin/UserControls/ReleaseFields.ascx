<%@ Control Language="C#" ClassName="ReleaseFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProjectId" runat="server" Text="Project Id:" AssociatedControlID="dataProjectId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProjectId" Text='<%# Bind("ProjectId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProjectId" runat="server" Display="Dynamic" ControlToValidate="dataProjectId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataProjectId" runat="server" Display="Dynamic" ControlToValidate="dataProjectId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReleaseDate" runat="server" Text="Release Date:" AssociatedControlID="dataReleaseDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReleaseDate" Text='<%# Bind("ReleaseDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataReleaseDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataReleaseDate" runat="server" Display="Dynamic" ControlToValidate="dataReleaseDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReleaseName" runat="server" Text="Release Name:" AssociatedControlID="dataReleaseName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReleaseName" Text='<%# Bind("ReleaseName") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReleaseNote" runat="server" Text="Release Note:" AssociatedControlID="dataReleaseNote" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReleaseNote" Text='<%# Bind("ReleaseNote") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActive" runat="server" Text="Active:" AssociatedControlID="dataActive" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataActive" SelectedValue='<%# Bind("Active") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserId" Text='<%# Bind("UserId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUserId" runat="server" Display="Dynamic" ControlToValidate="dataUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastUserUpdate" runat="server" Text="Last User Update:" AssociatedControlID="dataLastUserUpdate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastUserUpdate" Text='<%# Bind("LastUserUpdate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLastUserUpdate" runat="server" Display="Dynamic" ControlToValidate="dataLastUserUpdate" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastDateUpdate" runat="server" Text="Last Date Update:" AssociatedControlID="dataLastDateUpdate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastDateUpdate" Text='<%# Bind("LastDateUpdate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastDateUpdate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


