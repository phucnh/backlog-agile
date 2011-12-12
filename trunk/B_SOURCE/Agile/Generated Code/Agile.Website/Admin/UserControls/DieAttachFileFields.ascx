<%@ Control Language="C#" ClassName="DieAttachFileFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieFileUrl" runat="server" Text="Die File Url:" AssociatedControlID="dataDieFileUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieFileUrl" Text='<%# Bind("DieFileUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieRequestId" runat="server" Text="Die Request Id:" AssociatedControlID="dataDieRequestId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDieRequestId" DataSourceID="DieRequestIdDieRequestDataSource" DataTextField="DieName" DataValueField="DieRequestId" SelectedValue='<%# Bind("DieRequestId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DieRequestDataSource ID="DieRequestIdDieRequestDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieFileName" runat="server" Text="Die File Name:" AssociatedControlID="dataDieFileName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieFileName" Text='<%# Bind("DieFileName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDieFileName" runat="server" Display="Dynamic" ControlToValidate="dataDieFileName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


