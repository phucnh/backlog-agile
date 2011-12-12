	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Web.Security;

using Agile.Entities;
using Agile.Entities.Validation;

using Agile.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace Agile.Services
{		
	/// <summary>
	/// An component type implementation of the 'tblUser' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class UserService : Agile.Services.UserServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the UserService class.
		/// </summary>
		public UserService() : base()
		{
		}
		#endregion Constructors

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool ValidateUser(string username, string password)
        {
            User user = GetByUserName(username);

            if (user == null) return false;

            if (string.Compare(user.PassWord, password) != 0) return false;
            
            return true;
        }

	}//End Class

} // end namespace
