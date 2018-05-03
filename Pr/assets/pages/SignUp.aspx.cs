using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Threading;

using Pr.handlers;

namespace Pr.assets.pages
{

    public partial class SignUp : System.Web.UI.Page
    {

        public void Page_Load()
        {
            send.ServerClick += onClick;
        }

        public void onClick(object sender, EventArgs e)
        {
            if (validate())
            {
                string token = Tokenizer.getToken();  // Получаем новый токен для пользователя
                DataBaseHandler.addNewUser(
                    name.Value,
                    last_name.Value,
                    username.Value,
                    phone.Value,
                    email.Value,
                    password.Value,
                    token
                );

                Response.Cookies.Add(setCookie(token));

                Response.Redirect("/");  // Перенаправляем на главную
            }
        }

        private HttpCookie setCookie(string token){
            HttpCookie cookie = new HttpCookie("data");
            cookie.Value = token;
            cookie.Expires = DateTime.Now.AddMinutes(10);
            return cookie;
        }

        private bool validate()
        {  // Метод отвечает за валидацию
            return (
                name.Value.Length <= 20 &&
                last_name.Value.Length <= 20 &&
                username.Value.Length <= 15 &&
                phoneValidate() &&
                emailValidate() &&
                password.Value == password_repeat.Value &&
                password.Value.Length <= 20
            );
        }

        private bool phoneValidate()
        {
            long a;
            return long.TryParse(phone.Value, out a);
        }

        private bool emailValidate()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.Match(email.Value).Success;
        }

    }
}
