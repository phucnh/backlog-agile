<%@ Control Language="C#" ClassName="DieRequestFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataParentDie" runat="server" Text="Parent Die:" AssociatedControlID="dataParentDie" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataParentDie" DataSourceID="ParentDieDieRequestDataSource" DataTextField="DieName" DataValueField="DieRequestId" SelectedValue='<%# Bind("ParentDie") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DieRequestDataSource ID="ParentDieDieRequestDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieName" runat="server" Text="Die Name:" AssociatedControlID="dataDieName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieName" Text='<%# Bind("DieName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieTag" runat="server" Text="Die Tag:" AssociatedControlID="dataDieTag" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieTag" Text='<%# Bind("DieTag") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieDescription" runat="server" Text="Die Description:" AssociatedControlID="dataDieDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieDescription" Text='<%# Bind("DieDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieTypeId" runat="server" Text="Die Type Id:" AssociatedControlID="dataDieTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDieTypeId" DataSourceID="DieTypeIdDieTypeDataSource" DataTextField="Initial" DataValueField="DieTypeId" SelectedValue='<%# Bind("DieTypeId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DieTypeDataSource ID="DieTypeIdDieTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataResolutionsId" runat="server" Text="Resolutions Id:" AssociatedControlID="dataResolutionsId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataResolutionsId" DataSourceID="ResolutionsIdResolutionsDataSource" DataTextField="ResolutionsName" DataValueField="ResolutionsId" SelectedValue='<%# Bind("ResolutionsId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ResolutionsDataSource ID="ResolutionsIdResolutionsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdUserDataSource" DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UserDataSource ID="UserIdUserDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProjectId" runat="server" Text="Project Id:" AssociatedControlID="dataProjectId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProjectId" DataSourceID="ProjectIdProjectDataSource" DataTextField="ProjectName" DataValueField="ProjectId" SelectedValue='<%# Bind("ProjectId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ProjectDataSource ID="ProjectIdProjectDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieStatus" runat="server" Text="Die Status:" AssociatedControlID="dataDieStatus" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDieStatus" DataSourceID="DieStatusDieStatusDataSource" DataTextField="DieNameStatus" DataValueField="DieStatus" SelectedValue='<%# Bind("DieStatus") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DieStatusDataSource ID="DieStatusDieStatusDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriorityDieRequestId" runat="server" Text="Priority Die Request Id:" AssociatedControlID="dataPriorityDieRequestId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataPriorityDieRequestId" DataSourceID="PriorityDieRequestIdPriorityDieRequestDataSource" DataTextField="PriorityDieRequestName" DataValueField="PriorityDieRequestId" SelectedValue='<%# Bind("PriorityDieRequestId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:PriorityDieRequestDataSource ID="PriorityDieRequestIdPriorityDieRequestDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieDateSubmit" runat="server" Text="Die Date Submit:" AssociatedControlID="dataDieDateSubmit" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDieDateSubmit" Text='<%# Bind("DieDateSubmit", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDieDateSubmit" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCodeBy" runat="server" Text="Code By:" AssociatedControlID="dataCodeBy" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCodeBy" DataSourceID="CodeByUserDataSource" DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("CodeBy") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UserDataSource ID="CodeByUserDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOwner" runat="server" Text="Owner:" AssociatedControlID="dataOwner" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataOwner" DataSourceID="OwnerUserDataSource" DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("Owner") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UserDataSource ID="OwnerUserDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateTime" runat="server" Text="Update Time:" AssociatedControlID="dataUpdateTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateTime" Text='<%# Bind("UpdateTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdateTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastUserUpdate" runat="server" Text="Last User Update:" AssociatedControlID="dataLastUserUpdate" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLastUserUpdate" DataSourceID="LastUserUpdateUserDataSource" DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("LastUserUpdate") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UserDataSource ID="LastUserUpdateUserDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTargetDate" runat="server" Text="Target Date:" AssociatedControlID="dataTargetDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTargetDate" Text='<%# Bind("TargetDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataTargetDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompletedReleaseId" runat="server" Text="Completed Release Id:" AssociatedControlID="dataCompletedReleaseId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCompletedReleaseId" DataSourceID="CompletedReleaseIdReleaseDataSource" DataTextField="ProjectId" DataValueField="ReleaseId" SelectedValue='<%# Bind("CompletedReleaseId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ReleaseDataSource ID="CompletedReleaseIdReleaseDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMilestoneId" runat="server" Text="Milestone Id:" AssociatedControlID="dataMilestoneId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataMilestoneId" DataSourceID="MilestoneIdMileStoleDataSource" DataTextField="MileStoleName" DataValueField="MileStoleId" SelectedValue='<%# Bind("MilestoneId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:MileStoleDataSource ID="MilestoneIdMileStoleDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDieCategoryId" runat="server" Text="Die Category Id:" AssociatedControlID="dataDieCategoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDieCategoryId" DataSourceID="DieCategoryIdDieCategoryDataSource" DataTextField="DieCategoryName" DataValueField="DieCategoryId" SelectedValue='<%# Bind("DieCategoryId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DieCategoryDataSource ID="DieCategoryIdDieCategoryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEstimated" runat="server" Text="Estimated:" AssociatedControlID="dataEstimated" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEstimated" Text='<%# Bind("Estimated") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataEstimated" runat="server" Display="Dynamic" ControlToValidate="dataEstimated" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActual" runat="server" Text="Actual:" AssociatedControlID="dataActual" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActual" Text='<%# Bind("Actual") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataActual" runat="server" Display="Dynamic" ControlToValidate="dataActual" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


