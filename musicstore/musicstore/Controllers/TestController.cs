using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using musicstore.Models;
using Microsoft.EntityFrameworkCore;

namespace musicstore.Controllers
{
    public class TestController : Controller
    {
        private readonly MvcMusicStoreContext _context;


        public TestController(MvcMusicStoreContext context)
        {
            _context=context;
        }
        public IActionResult LINQTest()
        {
            try
            {
                var albums = from a in _context.Album 
                             join ar in _context.Artist on a.AlbumId equals ar.ArtistId
                             join g in _context.Genre on a.GenreId equals g.GenreId 
                             select new Album
                             {
                                 AlbumId=a.AlbumId,
                                 Title=a.Title,
                                 Price=a.Price,
                                 Artist=ar,
                                 Genre=g
                              

                             };
                return View(albums);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error occured" + ex.GetBaseException().Message);
                return View(new List<Album>());
            }
        }

        public IActionResult EFTest()
        {
            try
            {
                var albums = from anAlbum in _context.Album
                             .Include(a => a.Artist)
                             .Include(c => c.Genre)
                             select anAlbum;
                return View("LINQTest", albums);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error occured" + ex.GetBaseException().Message);
                return View(new List<Album>());
            }

        }

        public IActionResult FilterView()
        {
            //var album = from anAlbum in _context.Album
            //            .Include(a=>a.Artist)
            //            .Include(g=>g.Genre)
            //            where anAlbum.Title.Contains("Best")
            //            select anAlbum;

            // var album=_context.Album.include(a=>a.Artist).Include(a=>a.genre).Where(a=>a.Title.Contains("Best"));

            // var album = _context.Album.Include(a => a.Artist).Include(a => a.Genre).OrderBy(c => c.Artist.Name + c.Title);

            var album = from analbum in _context.Album.Include(a => a.Artist).Include(a => a.Genre)
                        orderby analbum.Artist.Name descending, analbum.Title ascending
                        select analbum;

           // var album = _context.Album.Skip(10).Take(10);

            return View(album);
        }

        public IActionResult PriceChange()
        {
            var album = from a in _context.Album.Include(a=>a.Artist)
                         select new PriceChange
                         {
                             
                             Title = a.Title,
                             Price = a.Price,
                             taxPrice=a.Price*1.3,
                             
                         };

            return View(album);
        }

        public IActionResult LinqGroupBy()
        {
            var crtistCount = from anAlbum in _context.Album.Include(a => a.Artist)
                              group anAlbum by new
                              {
                                  anAlbum.ArtistId,
                                  anAlbum.Artist.Name
                              } into condenseAlbum
                              select new LinqTestArtistCount
                              {
                                  Artist = condenseAlbum.Key.Name,
                                  Count = condenseAlbum.Count(),
                                  TotalPrice = condenseAlbum.Sum(a => a.Price),
                                  AvgPrice = condenseAlbum.Average(a => a.Price)


                              };

                             return View(crtistCount);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetExample()
        {
            return View();
        }
        public IActionResult Search(string query)
        {
            var albums = _context.Album.Include(a => a.Artist).Where(a => a.Title.Contains(query) || a.Artist.Name.Contains(query));
            return View(albums);
        }
    }
}