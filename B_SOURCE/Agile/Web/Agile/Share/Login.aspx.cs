using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using Agile.Entities;
using Agile.Services;

namespace Agile.Share
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginForm_Authenticate(object sender, AuthenticateEventArgs e)
        {
            System.Web.UI.WebControls.Login loginForm = 
                (System.Web.UI.WebControls.Login)Common.Ultility.GetControl(this.Page, "LoginForm");

            string username = loginForm.UserName.Trim();
            string password = loginForm.Password.Trim();

            if (Membership.ValidateUser(username, password))
            {
                e.Authenticated = true;

                UserService userService = new UserService();
                User user = userService.GetByUserName(username);

                FormsAuthentication.RedirectFromLoginPage(loginForm.UserName, loginForm.RememberMeSet);
                //FormsAuthentication.SetAuthCookie(username, true);

                //FormsAuthentication.R
            }
            else
                e.Authenticated = false;
        }
    }
}