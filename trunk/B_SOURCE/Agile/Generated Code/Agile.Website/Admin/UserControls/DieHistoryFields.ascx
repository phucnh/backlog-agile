<%@ Control Language="C#" ClassName="DieHistoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieRequestId" runat="server" Text="Die Request Id:" AssociatedControlID="dataDieRequestId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieRequestId" Text='<%# Bind("DieRequestId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDieRequestId" runat="server" Display="Dynamic" ControlToValidate="dataDieRequestId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDieRequestId" runat="server" Display="Dynamic" ControlToValidate="dataDieRequestId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieDateSubmit" runat="server" Text="Die Date Submit:" AssociatedControlID="dataDieDateSubmit" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieDateSubmit" Text='<%# Bind("DieDateSubmit", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDieDateSubmit" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDieDateSubmit" runat="server" Display="Dynamic" ControlToValidate="dataDieDateSubmit" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieStatus" runat="server" Text="Die Status:" AssociatedControlID="dataDieStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieStatus" Text='<%# Bind("DieStatus") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDieStatus" runat="server" Display="Dynamic" ControlToValidate="dataDieStatus" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDieStatus" runat="server" Display="Dynamic" ControlToValidate="dataDieStatus" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieHistoryNote" runat="server" Text="Die History Note:" AssociatedControlID="dataDieHistoryNote" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieHistoryNote" Text='<%# Bind("DieHistoryNote") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieHistoryNoteJp" runat="server" Text="Die History Note Jp:" AssociatedControlID="dataDieHistoryNoteJp" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieHistoryNoteJp" Text='<%# Bind("DieHistoryNoteJp") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReleaseId" runat="server" Text="Release Id:" AssociatedControlID="dataReleaseId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReleaseId" Text='<%# Bind("ReleaseId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataReleaseId" runat="server" Display="Dynamic" ControlToValidate="dataReleaseId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserId" Text='<%# Bind("UserId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUserId" runat="server" Display="Dynamic" ControlToValidate="dataUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOwner" runat="server" Text="Owner:" AssociatedControlID="dataOwner" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOwner" Text='<%# Bind("Owner") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataOwner" runat="server" Display="Dynamic" ControlToValidate="dataOwner" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastUserUpdate" runat="server" Text="Last User Update:" AssociatedControlID="dataLastUserUpdate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastUserUpdate" Text='<%# Bind("LastUserUpdate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLastUserUpdate" runat="server" Display="Dynamic" ControlToValidate="dataLastUserUpdate" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastTimeUpdate" runat="server" Text="Last Time Update:" AssociatedControlID="dataLastTimeUpdate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastTimeUpdate" Text='<%# Bind("LastTimeUpdate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastTimeUpdate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActionTypeId" runat="server" Text="Action Type Id:" AssociatedControlID="dataActionTypeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActionTypeId" Text='<%# Bind("ActionTypeId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataActionTypeId" runat="server" Display="Dynamic" ControlToValidate="dataActionTypeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


