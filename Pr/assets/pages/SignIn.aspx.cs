using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Pr.handlers;

namespace Pr.assets.pages
{

    public partial class SignIn : System.Web.UI.Page
    {
        public void Page_Load(){
            enter.ServerClick += onClick;
        }

        public void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Request.QueryString["error"] != null)
            {
                errorBox.InnerHtml = String.Format("<script>M.toast({{html: {0}, classes: 'rounded'}})</script>", Request.QueryString["error"]);
            }
        }

        private void onClick(object sender, EventArgs e){
            if (validate()){
                string token = DataBaseHandler.getToken(email.Value, password.Value);
                if (token == null){  // Если пользователь ошибся в данных
                    Response.Redirect("/signin?error='Введены ошибочные данные'");
                } else {
                    Response.Cookies.Add(getCookie(token));
                    Response.Redirect("/");  // Переходим на главную
                }
            } else {
                Response.Redirect("/signin?error='Формат данных не верен'");
            }
        }

        private HttpCookie getCookie(string token){
            HttpCookie cookie = new HttpCookie("data");
            cookie.Value = token;
            cookie.Expires = DateTime.Now.AddMinutes(100);
            return cookie;
        }

        private bool validate(){
            return emailValidate() && password.Value.Length > 0;
        }

        private bool emailValidate()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.Match(email.Value).Success;
        }

    }
}
