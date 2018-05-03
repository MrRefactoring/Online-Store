using System;
using System.Web;
using System.Web.UI;
using Pr.handlers;

namespace Pr.assets.pages.admin
{

    public partial class AddItem : System.Web.UI.Page
    {
        private string[] lolVideos = new string[] {
            "https://www.youtube.com/watch?v=wZZ7oFKsKzY",
            "https://www.youtube.com/watch?v=8ZcmTl_1ER8",
            "https://www.youtube.com/watch?v=sCNrK-n68CM",
            "https://www.youtube.com/watch?v=cwhLueAWItA",
            "https://www.youtube.com/watch?v=MJbTjBLEKBU",
            "https://www.youtube.com/watch?v=Sagg08DrO5U"
        };

        public void Page_Load()
        {
            if (Request.Cookies["data"] == null || DataBaseHandler.role(Request.Cookies["data"].Value) != "admin")
            {  // Если пытается войти не администратор
                // Реализуем пасхалку
                Response.Redirect(lolVideos[new Random().Next(lolVideos.Length)]);
            }
            addButton.ServerClick += onAddClick;
            Console.WriteLine("Load");
        }

        public void onAddClick(object sendler, EventArgs e){
            if (title.Value == "" ||
                description.Value == ""){
                toast("Название товара или описание не заполнено");
                return;
            }
            if (price.Value == ""){
                toast("Поле 'Цена' не заполнено");
                return;
            }
            if (photos.Value == ""){
                toast("Добавте хотя бы одну фотографию к товару");
                return;
            }

            DataBaseHandler.addItem(title.Value, description.Value, price.Value, photos.Value.Split(' '));  // Добавляем товар в список товаров
            Response.Redirect("/admin");
        }

        private void toast(string message){
            ScriptManager.RegisterStartupScript(this, GetType(), "toast", "toast('" + message.Replace("'", "\\'") + "')", true);
        }

    }
}
