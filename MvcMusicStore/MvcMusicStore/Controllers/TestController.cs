using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class TestController : Controller
    {
        private readonly MvcMusicStoreContext _context;

        public TestController(MvcMusicStoreContext context)
        {
            _context = context;

        }

        public IActionResult LINQTest()
        {
            try
            {
                var albums = from a in _context.Album
                             join ar in _context.Artist on a.ArtistId equals ar.ArtistId
                             join g in _context.Genre on a.GenreId equals g.GenreId
                             select new Album
                             {
                                 AlbumId = a.AlbumId,
                                 Title = a.Title,
                                 Price = a.Price,
                                 Artist = ar,
                                 Genre = g
                             };
                return View(albums);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error Occured" + ex.GetBaseException().Message);
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error Occured" + ex.GetBaseException().Message);
                return View(new List<Album>());
            }
        }

        public IActionResult FilterView()
        {
            // Filtering using Where
            // Linq Syntax

            //var album = from anAlbum in _context.Album
            //            .Include(a => a.Artist)
            //            .Include(c => c.Genre)
            //            where anAlbum.Title.Contains("Best")
            //            select anAlbum;

            // Filtering using Where
            // EF Syntax
            var album = _context.Album.Include(a => a.Artist).Include(a => a.Genre).Where(a => a.Title.Contains("Best"));

            // Order by EF Syntax
            //var album = _context.Album.Include(a => a.Artist).Include(a => a.Genre).
            //    OrderBy(c => c.Artist.Name + c.Title);

            //var album = _context.Album.Include(a => a.Artist).Include(a => a.Genre).
            //    OrderBy(c => c.Artist.Name).ThenByDescending(d => d.Title);

            // Order by LINQ Syntax
            //var album = from analbum in _context.Album.Include(a => a.Artist).Include(a => a.Genre)
            //            orderby analbum.Artist.Name descending, analbum.Title ascending
            //            select analbum;

          //  var album = _context.Album.Include(a => a.Artist).Include(a => a.Genre).Skip(10).Take(10);
                         
            return View(album);
        }

        public IActionResult PriceSurcharged()
        {
            var album = from anAlbum in _context.Album.Include(a => a.Artist)
                        select new PriceSurcharged
                        {
                            Title = anAlbum.Title,
                            Artist = anAlbum.Artist.Name,
                            Price = anAlbum.Price,
                            SurchargedPrice = anAlbum.Price * 1.13
                        };

            return View(album);
        }

        public IActionResult LinqTestGroupBy()
        {
            var artistCount = from anAlbum in _context.Album.Include(a => a.Artist)
                              group anAlbum by new
                              {
                                  anAlbum.ArtistId,
                                  anAlbum.Artist.Name
                              } into condensedAlbum
                              select new LinqTestArtistCount
                              {
                                  artist  = condensedAlbum.Key.Name,
                                  count = condensedAlbum.Count(),
                                  totalPrice = condensedAlbum.Sum(a=>a.Price),
                                  AveragePrice = condensedAlbum.Average(a=>a.Price)
                              };
            return View(artistCount.OrderByDescending(a=>a.count));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetExample()
        {
            return View();
        }

        public IActionResult GetExample2(string q)
        {
            return View("GetExample");
        }

        public IActionResult Search(string query)
        {
            var albums = _context.Album.Include(a => a.Artist)
                .Where(a => a.Title.Contains(query) || a.Artist.Name.Contains(query));
            return View(albums);
        }
    }
}