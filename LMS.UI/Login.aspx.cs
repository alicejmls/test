using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string pwd = txtPwd.Text.Trim();

        if (System.Web.Security.FormsAuthentication.Authenticate(username, pwd))
        {
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(username, false);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "msg", "alert('用户名或密码错误！！！')", true);
        }
    }
}