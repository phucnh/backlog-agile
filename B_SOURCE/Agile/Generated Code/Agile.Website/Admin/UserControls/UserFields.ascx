<%@ Control Language="C#" ClassName="UserFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassWord" runat="server" Text="Pass Word:" AssociatedControlID="dataPassWord" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassWord" Text='<%# Bind("PassWord") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPassWord" runat="server" Display="Dynamic" ControlToValidate="dataPassWord" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQlnsId" runat="server" Text="Qlns Id:" AssociatedControlID="dataQlnsId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataQlnsId" Text='<%# Bind("QlnsId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataQlnsId" runat="server" Display="Dynamic" ControlToValidate="dataQlnsId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmployeeName" runat="server" Text="Employee Name:" AssociatedControlID="dataEmployeeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmployeeName" Text='<%# Bind("EmployeeName") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRemove" runat="server" Text="Remove:" AssociatedControlID="dataRemove" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataRemove" SelectedValue='<%# Bind("Remove") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsLoginSystem" runat="server" Text="Is Login System:" AssociatedControlID="dataIsLoginSystem" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsLoginSystem" SelectedValue='<%# Bind("IsLoginSystem") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateDate" runat="server" Text="Update Date:" AssociatedControlID="dataUpdateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateDate" Text='<%# Bind("UpdateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserUpdate" runat="server" Text="User Update:" AssociatedControlID="dataUserUpdate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserUpdate" Text='<%# Bind("UserUpdate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUserUpdate" runat="server" Display="Dynamic" ControlToValidate="dataUserUpdate" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPageDefaultLogin" runat="server" Text="Page Default Login:" AssociatedControlID="dataPageDefaultLogin" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPageDefaultLogin" Text='<%# Bind("PageDefaultLogin") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateCreated" runat="server" Text="Date Created:" AssociatedControlID="dataDateCreated" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateCreated" Text='<%# Bind("DateCreated", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateCreated" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateRemoved" runat="server" Text="Date Removed:" AssociatedControlID="dataDateRemoved" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateRemoved" Text='<%# Bind("DateRemoved", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateRemoved" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsNoBody" runat="server" Text="Is No Body:" AssociatedControlID="dataIsNoBody" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsNoBody" SelectedValue='<%# Bind("IsNoBody") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


