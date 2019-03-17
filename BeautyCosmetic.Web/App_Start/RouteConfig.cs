using System.Web.Mvc;
using System.Web.Routing;

namespace BeautyCosmetic.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
              name: "Confirm Order",
              url: "xac-nhan-don-hang_html",
              defaults: new { controller = "ShoppingCart", action = "ConfirmOrder", id = UrlParameter.Optional },
              namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
             );
            routes.MapRoute(
               name: "Cancel Order",
               url: "huy-don-hang_html",
               defaults: new { controller = "ShoppingCart", action = "CancelOrder", id = UrlParameter.Optional },
               namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
              );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he_html",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
               );
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
            );
            routes.MapRoute(
                 name: "Login",
                 url: "dang-nhap_html",
                 defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                 namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
             );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky_html",
               defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
               namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
              );
            routes.MapRoute(
           name: "Cart",
           url: "gio-hang_html",
           defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
           namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
       );
            routes.MapRoute(
         name: "Checkout",
         url: "thanh-toan_html",
         defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
         namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
     );
            routes.MapRoute(
               name: "Page",
               url: "trang/{alias}_html",
               defaults: new { controller = "Page", action = "Index", alias = UrlParameter.Optional },
               namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
             );
            routes.MapRoute(
             name: "Product Category",
             url: "{alias}_pc-{id}",
             defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
               namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
            );

            routes.MapRoute(
             name: "Product",
             url: "{alias}_p-{productId}",
             defaults: new { controller = "Product", action = "Detail", productId = UrlParameter.Optional },
               namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
           );
            routes.MapRoute(
            name: "TagList",
            url: "tag/{tagId}_html",
            defaults: new { controller = "Product", action = "ListByTag", tagId = UrlParameter.Optional },
              namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
          );
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BeautyCosmetic.Web.Controllers" }
            );
        }
    }
}