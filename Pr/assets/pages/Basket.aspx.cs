using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;
using Pr.handlers;

namespace Pr.assets.pages
{

    public partial class Basket : System.Web.UI.Page
    {

        private HttpCookie cookie;
        private Dictionary<string, object> user;
        private List<string> basket;

        public void Page_Load(){
            cookie = Request.Cookies["data"];
            if (cookie == null){
                Response.Redirect("/");
            }
            user = DataBaseHandler.getUser(cookie.Value);
            basket = JsonConvert.DeserializeObject<List<string>>(user["basket"].ToString());
            delete.ServerClick += onDeleteClick;
        }

        public void onDeleteClick(object sendler, EventArgs e)
        {
            DataBaseHandler.deleteBasketItem(cookie.Value, field.Value.Split('m')[1]);  // Удаляем товар из корзины
            Response.Redirect("/basket");  // Делаем перезагрузку страницы, чтобы обновить список мотоциклов
        }

        public void generateBody(){
            int count = 0;  // Сколько мотоциклов уже сгенерированно. Нужно для перескакивания строк
            List<Dictionary<string, object>> motorcycles;
            using (StreamReader sr = new StreamReader(Server.MapPath("~/databases/motorcycles.json")))
            {
                motorcycles = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
            }

            string text = "";

            foreach (Dictionary<string, object> motorcycle in motorcycles)
            {
                if (!basket.Contains((string)motorcycle["id"])) continue;  // Если такой мотоцикл не выбран пользователем
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

        private string generateOneMoto(string id, string title, string description, string price, string[] pictures)
        {
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

                        <a class='waves-effect waves-light btn green moto'><i class='material-icons left'>payment</i>Оплатить {3}₽</a>
                        <a id='{4}' class='waves-effect waves-light btn red d'><i class='material-icons left'>delete_forever</i>Удалить</a>

                    </div>
                </div>
            ", generatePicturesCode(pictures), title, description, price, "m" + id);

            return text;
        }

        private string generatePicturesCode(string[] pictures)
        {
            string text = "";
            foreach (var picture in pictures)
            {
                text += String.Format(
                    "<div class='carousel-item'><img src='{0}'></div>",
                    picture
                );
            }
            return text;
        }

        public string getUsername(){
            return (string)user["username"];
        }

    }
}
