using System;
using System.Web;
using System.Web.UI;

namespace Pr.assets.pages
{

    public partial class SignOut : System.Web.UI.Page
    {
        public void Page_Load()
        {
            HttpCookie cookie = Request.Cookies["data"];

            cookie.Expires = DateTime.Now.AddDays(-1);  // Удаляем cookie

            Response.Cookies.Add(cookie);
            Response.Redirect("/");  // Переходим на главную
        }

    }
}
