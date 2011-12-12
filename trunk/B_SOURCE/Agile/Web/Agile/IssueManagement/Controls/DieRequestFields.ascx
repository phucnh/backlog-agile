<%@ Control Language="C#" ClassName="DieRequestFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <div>
            <span class="section">
                <br />
                <asp:Label ID="lbldataDieName" runat="server" Text="Subject:" AssociatedControlID="dataDieName" />
                <telerik:RadTextBox runat="server" ID="dataDieName" Text='<%# Bind("DieName") %>'
                    Width="85%" Style="margin-left: 21px;" /><br />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="dataDieName" ErrorMessage="Require"
                    Display="Dynamic" />
            </span>
            <hr />
            <span class="section" style="text-align: left">
                <br />
                <asp:Label ID="lbldataDieDescription" runat="server" Text="Description:" AssociatedControlID="dataDieDescription" />
                <telerik:RadTextBox runat="server" ID="dataDieDescription" Text='<%# Bind("DieDescription") %>'
                    TextMode="MultiLine" Rows="8" Width="85%" />
            </span>
            <br />
            <hr />
            <br />
            <div class="section" style="text-align: left; margin-left: 30px;">
                <p>
                    Attributes</p>
                <div class="subsection">
                    <div class="left_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataDieTypeId" runat="server" Text="Issue Type" AssociatedControlID="dataDieTypeId" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox ID="dataDieTypeId" AppendDataBoundItems="true" runat="server"
                                DataSourceID="DieTypeIdDieTypeDataSource" DataTextField="DIETypeName" DataValueField="DieTypeId"
                                SelectedValue='<%# Bind("DieTypeId") %>'>
                            </telerik:RadComboBox>
                        </div>
                        <%--<data:EntityDropDownList runat="server" ID="dataDieTypeId" DataSourceID="DieTypeIdDieTypeDataSource"
                        DataTextField="Initial" DataValueField="DieTypeId" SelectedValue='<%# Bind("DieTypeId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />--%>
                        <data:DieTypeDataSource ID="DieTypeIdDieTypeDataSource" runat="server" SelectMethod="GetAll" />
                    </div>
                    <div class="right_column">
                        <div class="attribute_header">
                            <asp:Label ID="lblPriority" runat="server" Text="Priority" AssociatedControlID="dataDieTypeId" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox ID="dataPriorityDieRequestId" runat="server" DataSourceID="PriorityDieRequestIdPriorityDieRequestDataSource"
                                DataTextField="PriorityDieRequestName" DataValueField="PriorityDieRequestId"
                                SelectedValue='<%# Bind("PriorityDieRequestId") %>' />
                        </div>
                        <%--<data:EntityDropDownList runat="server" ID="dataPriorityDieRequestId" DataSourceID="PriorityDieRequestIdPriorityDieRequestDataSource"
                        DataTextField="PriorityDieRequestName" DataValueField="PriorityDieRequestId"
                        SelectedValue='<%# Bind("PriorityDieRequestId") %>' AppendNullItem="true" Required="false"
                        NullItemText="< Please Choose ...>" />--%>
                        <data:PriorityDieRequestDataSource ID="PriorityDieRequestIdPriorityDieRequestDataSource"
                            runat="server" SelectMethod="GetAll" />
                    </div>
                </div>
                <div class="subsection">
                    <div class="left_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataDieCategoryId" runat="server" Text="Category" AssociatedControlID="dataDieCategoryId" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox ID="dataDieCategoryId" runat="server" DataSourceID="DieCategoryIdDieCategoryDataSource"
                                DataTextField="DieCategoryName" DataValueField="DieCategoryId" SelectedValue='<%# Bind("DieCategoryId") %>' />
                        </div>
                        <%--<data:EntityDropDownList runat="server" ID="dataDieCategoryId" DataSourceID="DieCategoryIdDieCategoryDataSource"
                        DataTextField="DieCategoryName" DataValueField="DieCategoryId" SelectedValue='<%# Bind("DieCategoryId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />--%>
                        <data:DieCategoryDataSource ID="DieCategoryIdDieCategoryDataSource" runat="server"
                            SelectMethod="GetAll" />
                    </div>
                    <div class="right_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataDieStatus" runat="server" Text="Status" AssociatedControlID="dataDieStatus" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox runat="server" ID="dataDieStatus" DataSourceID="DieStatusDieStatusDataSource"
                                DataTextField="DieNameStatus" Enabled="false" DataValueField="DieStatus" SelectedValue='<%# Bind("DieStatus") %>' />
                            <%--<asp:Literal ID="dataDieStatus" runat='server' Text="New" />--%>
                            <%--<data:EntityDropDownList runat="server" ID="dataDieStatus" DataSourceID="DieStatusDieStatusDataSource"
                        DataTextField="DieNameStatus" DataValueField="DieStatus" SelectedValue='<%# Bind("DieStatus") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />--%>
                            <data:DieStatusDataSource ID="DieStatusDieStatusDataSource" runat="server" SelectMethod="GetAll" />
                        </div>
                    </div>
                </div>
                <div class="subsection">
                    <div class="left_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataProjectId" runat="server" Text="Project" AssociatedControlID="dataProjectId" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox ID="dataProjectId" runat="server" DataSourceID="ProjectIdProjectDataSource"
                                DataTextField="ProjectName" DataValueField="ProjectId" SelectedValue='<%# Bind("ProjectId") %>' />
                            <%--<data:EntityDropDownList runat="server" ID="dataProjectId" DataSourceID="ProjectIdProjectDataSource"
                        DataTextField="ProjectName" DataValueField="ProjectId" SelectedValue='<%# Bind("ProjectId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />--%>
                            <data:ProjectDataSource ID="ProjectIdProjectDataSource" runat="server" SelectMethod="GetAll" />
                        </div>
                    </div>
                    <div class="right_column">
                        <div class="attribute_header">
                            <asp:Label ID="Label2" runat="server" Text="Resolutions" AssociatedControlID="dataResolutionsId" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox ID="dataResolutionsId" runat="server" DataSourceID="ResolutionsIdResolutionsDataSource"
                                DataTextField="ResolutionsName" DataValueField="ResolutionsId" SelectedValue='<%# Bind("ResolutionsId") %>' />
                            <%--<data:EntityDropDownList runat="server" ID="dataResolutionsId" DataSourceID="ResolutionsIdResolutionsDataSource"
                        DataTextField="ResolutionsName" DataValueField="ResolutionsId" SelectedValue='<%# Bind("ResolutionsId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />--%>
                            <data:ResolutionsDataSource ID="ResolutionsIdResolutionsDataSource" runat="server"
                                SelectMethod="GetAll" />
                        </div>
                    </div>
                </div>
                <div class="subsection">
                    <div class="left_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataMilestoneId" runat="server" Text="Milestone" AssociatedControlID="dataMilestoneId" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox ID="dataMilestoneId" runat="server" DataSourceID="MilestoneIdMileStoleDataSource"
                                DataTextField="MileStoleName" DataValueField="MileStoleId" SelectedValue='<%# Bind("MilestoneId") %>' />
                            <%--<data:EntityDropDownList runat="server" ID="dataMilestoneId" DataSourceID="MilestoneIdMileStoleDataSource"
                        DataTextField="MileStoleName" DataValueField="MileStoleId" SelectedValue='<%# Bind("MilestoneId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />--%>
                            <data:MileStoleDataSource ID="MilestoneIdMileStoleDataSource" runat="server" SelectMethod="GetAll" />
                        </div>
                    </div>
                    <div class="right_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataOwner" runat="server" Text="Assignee" AssociatedControlID="dataOwner" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadComboBox ID="dataOwner" runat="server" DataSourceID="OwnerUserDataSource"
                                DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("Owner") %>' />
                            <%--<data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdUserDataSource"
                        DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />--%>
                            <data:UserDataSource ID="OwnerUserDataSource" runat="server" SelectMethod="GetAll" />
                        </div>
                    </div>
                </div>
                <div class="subsection">
                    <div class="left_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataEstimated" runat="server" Text="Estimated Hours" AssociatedControlID="dataEstimated" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadTextBox runat="server" ID="dataEstimated" Text='<%# Bind("Estimated") %>'
                                Width="155px" />
                            <asp:Label ID="lblEstimatedHours" runat="server" Text="hours" AssociatedControlID="dataEstimated" />
                        </div>
                    </div>
                    <div class="right_column">
                        <div class="attribute_header">
                            <asp:Label ID="lbldataActual" runat="server" Text="Actual Hours" AssociatedControlID="dataActual" />
                        </div>
                        <div class="attribute_input">
                            <telerik:RadTextBox runat="server" ID="dataActual" Text='<%# Bind("Actual") %>' Width="155px" />
                            <asp:Label ID="lblActualHours" runat="server" Text="hours" AssociatedControlID="dataActual" />
                            <%--<asp:RangeValidator ID="RangeVal_dataActual" runat="server" Display="Dynamic" ControlToValidate="dataActual"
                                ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999"
                                Type="Double"></asp:RangeValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="subsection">
                    <div class="attribute_header" style="float: left; width: 9.6%; margin-left: 2%; margin-top: 10px;">
                        <asp:Label ID="lbldataDieDateSubmit" runat="server" Text="Start Date" AssociatedControlID="dataDieDateSubmit" />
                    </div>
                    <div class="attribute_input" style="float: left; width: 80%">
                        <telerik:RadDatePicker ID="dataDieDateSubmit" runat="server" Width="180px" DbSelectedDate='<%# Bind("DieDateSubmit") %>'>
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="subsection">
                    <div class="attribute_header" style="float: left; width: 9.6%; margin-left: 2%; margin-top: 10px;">
                        <asp:Label ID="lbldataTargetDate" runat="server" Text="Due Date" AssociatedControlID="dataTargetDate" />
                    </div>
                    <div class="attribute_input" style="float: left; width: 80%">
                        <telerik:RadDatePicker ID="dataTargetDate" runat="server" Width="180px" DbSelectedDate='<%# Bind("TargetDate") %>' />
                    </div>
                </div>
            </div>
        <hr />
        <div class="section" style="text-align: left; margin-left: 30px;">
            <p>
                Attach File</p>
            <div class="subsection" style="text-align: center; height: auto;">
                <br />
                <telerik:RadUpload ID="RadAttachFile" runat="server" Width="100%" Style="text-align: center;
                    margin: 5px 0px 5px 0px" TargetFolder="~/Share/Uploads/">
                </telerik:RadUpload>
                <br />
            </div>
        </div>
        </div>
    </ItemTemplate>
</asp:FormView>
