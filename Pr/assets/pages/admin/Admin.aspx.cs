using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;
using Pr.handlers;

namespace Pr.assets.pages.admin
{

    public partial class Admin : System.Web.UI.Page
    {

        private string[] lolVideos = new string[] {
            "https://www.youtube.com/watch?v=wZZ7oFKsKzY",
            "https://www.youtube.com/watch?v=8ZcmTl_1ER8",
            "https://www.youtube.com/watch?v=sCNrK-n68CM",
            "https://www.youtube.com/watch?v=cwhLueAWItA",
            "https://www.youtube.com/watch?v=MJbTjBLEKBU",
            "https://www.youtube.com/watch?v=Sagg08DrO5U"
        };

        public void Page_Load(){
            if (Request.Cookies["data"] == null || DataBaseHandler.role(Request.Cookies["data"].Value) != "admin"){  // Если пытается войти не администратор
                // Реализуем пасхалку
                Response.Redirect(lolVideos[new Random().Next(lolVideos.Length)]);
            }



        }

        public void onDeleteClick(object sendler, EventArgs e){
            
        }

        public void generateItems(){
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
                        
                        <p style='padding: 10px;'>Цена: {3}₽</p>
                        <a id='{4}' class='waves-effect waves-light btn red moto'><i class='material-icons left'>delete_forever</i>Удалить</a>

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

    }
}
