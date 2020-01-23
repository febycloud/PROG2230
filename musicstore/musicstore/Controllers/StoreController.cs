using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using musicstore.Models;

namespace musicstore.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult AlbumList()
        {
            List<Album> albums = new List<Album>();
            for(int i = 0; i < 10; i++)
            {
                albums.Add(new Album { Title = "Album" + i });
            }
            ViewBag.Albums = albums;
            return View(albums);
        }
        public IActionResult Sample()
        {
            ViewBag.message = "this is viewbag message";
            return View();
        }

        public string index()
        {
            return "hello index";
      }
    }
}