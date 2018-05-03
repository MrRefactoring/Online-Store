using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Pr.handlers;

namespace Pr
{

    public partial class Index : System.Web.UI.Page
    {
        
        private HttpCookie cookie;

        public void Page_Load(){
            buy.ServerClick += onBuyClick;
            cookie = Request.Cookies.Get("data");
        }

        public void onBuyClick(object sender, EventArgs e){
            if (field.Value.Equals("notSelected"))
                return;
            if (cookie != null){
                Dictionary<string, object> user = DataBaseHandler.getUser(cookie.Value);
                if (user != null){  // Если пользователь найден
                    string id = field.Value.Split('m')[1];  // id мотоцикла, которую выбрал пользователь
                    if (DataBaseHandler.addItemToBasket(cookie.Value, id)){  // Добавляем мотоцикл в корзину пользователя
                        toast("Мотоцикл добавлен в корзину!");
                    } else {
                        toast("Произошли какие-то внутренние проблемы, попробуйте позже");
                    }
                } else {
                    toast("Ваш token подделан!");
                }
            } else {
                toast("<a href='/signin'>Войдите</a>,&nbsp;чтобы сделать заказ");
            }
        }

        public void generateEntryControllers(){
            if (cookie != null){
                Dictionary<string, object> user = DataBaseHandler.getUser(cookie.Value);

                if (user != null)
                {  // Если пользователь найден
                    string role = (string)user["role"];
                    if (role.Equals("base"))
                    {
                        Response.Write(String.Format(@"
                    <span class='welcome'>ДОБРО ПОЖАЛОВАТЬ, {0}</span>
                    <a id='basket' class='waves-effect waves-light btn blue-grey lighten-1'>Корзина<i class='material-icons right'>shopping_cart</i></a>
                    <a id='exit' class='waves-effect waves-light btn blue-grey lighten-1'>Выйти<i class='material-icons right'>exit_to_app</i></a>", (string)user["username"]));
                    }
                    else if (role.Equals("admin"))
                    {
                        Response.Write(String.Format(@"
                    <span class='welcome'>ДОБРО ПОЖАЛОВАТЬ, {0}</span>
                    <a id='admin' class='waves-effect waves-light btn blue-grey lighten-1'>Панель администратора<i class='material-icons right'>build</i></a>
                    <a id='orders' class='waves-effect waves-light btn blue-grey lighten-1'>Заказы<i class='material-icons right'>shopping_basket</i></a>
                    <a id='exit' class='waves-effect waves-light btn blue-grey lighten-1'>Выйти<i class='material-icons right'>exit_to_app</i></a>", (string)user["username"]));
                    }
                }
                else
                {  // Если пользователь не найден
                    Response.Write("<a id='signin' class='waves-effect waves-light btn blue-grey lighten-1' style='margin-right: 6px;'>Войти<i class='material-icons right'>account_circle</i></a>" +
                                   "<a id='signup' class='waves-effect waves-light btn blue-grey lighten-1'>Зарегистрироваться<i class='material-icons right'>queue</i></a>");
                }
            } else
            {  // Если пользователь не найден
                Response.Write("<a id='signin' class='waves-effect waves-light btn blue-grey lighten-1' style='margin-right: 6px;'>Войти<i class='material-icons right'>account_circle</i></a>" +
                               "<a id='signup' class='waves-effect waves-light btn blue-grey lighten-1'>Зарегистрироваться<i class='material-icons right'>queue</i></a>");
            }
        }

        public void generatePageBody(){
            int count = 0;  // Сколько мотоциклов уже сгенерированно. Нужно для перескакивания строк
            List<Dictionary<string, object>> motorcycles;
            using (StreamReader sr = new StreamReader(Server.MapPath("~/databases/motorcycles.json")))
            {
                motorcycles = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
            }

            string text = "";

            foreach (Dictionary<string, object> motorcycle in motorcycles)
            {
                if (count % 3 == 0)
                {  // Если пора перескакивать на новую строку
                    if (count != 0)
                        text += "</div>";
                    text += "<div class='row'>";
                }
                text += String.Format("<div class='col s4'>{0}</div>", generateOneMoto(
                    (string)motorcycle["id"],
                    (string)motorcycle["title"],
                    (string)motorcycle["description"],
                    (string)motorcycle["price"],
                    JsonConvert.DeserializeObject<string[]>(motorcycle["pictures"].ToString())
                ));
                count++;
            }

            text += "</div>";

            Response.Write(text);

        }

        private void toast(string message){
            ScriptManager.RegisterStartupScript(this, GetType(), "toast", "toast('" + message.Replace("'", "\\'") + "')", true);
        }

        private string generateOneMoto(string id, string title, string description, string price, string[] pictures){
            string text = String.Format(@"
                <div class='white card' style='width: 100 %;'>
                      <div class='card-image'>
                        <div class='carousel carousel-slider center' style='height: 100px;'>
                            {0}
                        </div>
                    </div>
                    <div class='card-content paper'>
                        <span class='title'>{1}</span>
                        <hr/>
                        <p class='description'>{2}</p>

                        <a id='{4}' class='waves-effect waves-light btn blue-grey lighten-1 moto'><i class='material-icons left'>shopping_cart</i>{3}₽</a>

                    </div>
                </div>
            ", generatePicturesCode(pictures), title, description, price, "m" + id);

            return text;
        }

        private string generatePicturesCode(string[] pictures){
            string text = "";
            foreach (var picture in pictures){
                text += String.Format(
                    "<div class='carousel-item'><img src='{0}'></div>",
                    picture
                );
            }
            return text;
        }

    }
}
