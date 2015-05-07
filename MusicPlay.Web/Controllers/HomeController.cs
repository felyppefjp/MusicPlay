using System.Web.Mvc;


namespace MusicPlay.Web.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Hello gitHub (teste) Edmar Junior
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}