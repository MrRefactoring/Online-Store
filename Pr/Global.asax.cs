using System.Web;
using System.Web.Routing;

namespace Pr
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("index", "", "~/assets/Index.aspx");
            routes.MapPageRoute("signout", "signout", "~/assets/pages/SignOut.aspx");  //  Страница выхода
            routes.MapPageRoute("signin", "signin", "~/assets/pages/SignIn.aspx");  // Страница входа
            routes.MapPageRoute("signup", "signup", "~/assets/pages/SignUp.aspx");  // Страница регистрации
            routes.MapPageRoute("basket", "basket", "~/assets/pages/Basket.aspx");  // Корзина пользователя

            routes.MapPageRoute("admin", "admin", "~/assets/pages/admin/Admin.aspx");  // Страница администрации
            routes.MapPageRoute("orders", "orders", "~/assets/pages/admin/Ordera.aspx");  // Страница обработки заказов
            routes.MapPageRoute("add", "add", "~/assets/pages/admin/AddItem.aspx");  // Страница добавления товаров

        }

    }
}
