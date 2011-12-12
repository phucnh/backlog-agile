<%@ Page Language="C#" MasterPageFile="~/Share/Master.Master" %>
<script runat="server">
	private void Page_Load(object sender, EventArgs e)
	{
		FormsAuthentication.SignOut();
		Response.Redirect("~/Share/Home.aspx?task=logout");
	}
</script>
