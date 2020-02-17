using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult AlbumList()
        {
            List<Album> albums = new List<Album>();
            for (int i=0; i<10; i++)
            {
                albums.Add(new Album { Title = "Album " + i });
            }            
            return View(albums);
        }

        public IActionResult Sample()
        {
            ViewBag.message = "This is the Viewbag property";
            return View();
        }

        public string Index()
        {
            return "Hello from Store Index";
        }

        public string  Browse(string genre)
        {
            return "Hello from Browse and Genre passed is - " + genre;
        }

        public string Details(int id)
        {
            return "Hello from Details in Store. Id passed is - " + id.ToString();
        }
    }
}