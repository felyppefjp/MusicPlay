using System;
using System.Web.Mvc;
using MusicPlay.Core.Models;
using MusicPlay.Repository.Repositories;


namespace MusicPlay.Web.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var a = new Artistas
                {
                    Nom_Artista = "artista",
                    Dat_IniCarreira = new DateTime(1992, 01, 01),
                    Num_SeqlGenero = 1,
                    Cod_UsuaCad = 1,
                    Dat_Cad = new DateTime(2015, 01, 01)
                };

                var teste = new ArtistasRepository();
                teste.PostArtista(a);


                return View();
            }
            catch (Exception e)
            {
                throw e;
                
            }
            
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

    public class Usuario
    {
    }
}