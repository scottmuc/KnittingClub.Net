using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.ctlLogin.Authenticate += ctlLogin_Authenticate;
    }

    void ctlLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string username = ctlLogin.UserName.Trim();
        string password = ctlLogin.Password.Trim();

		if (FormsAuthentication.Authenticate(username, password))
		{
			FormsAuthentication.RedirectFromLoginPage(username, ctlLogin.RememberMeSet);
		}      
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
