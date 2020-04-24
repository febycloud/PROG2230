using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusService.Models;

namespace BusService.Controllers
{
    public class RouteStopsController : Controller
    {
        private readonly BusServiceContext _context;

        public RouteStopsController(BusServiceContext context)
        {
            _context = context;
        }

        // GET: RouteStops
        public async Task<IActionResult> Index(string BusRCode)
        {
            if (BusRCode != null)
            {
                Response.Cookies.Append("BusRouteCode", BusRCode);
            }
            else if (Request.Query["BusRCode"].Any())
            {
                Response.Cookies.Append("BusRouteCode", Request.Query["BusRCode"]);
                BusRCode = Request.Query["BusRCode"];
            }
            else if (Request.Cookies["BusRouteCode"] != null)
            {
                BusRCode = Request.Cookies["BusRouteCode"].ToString();
            }
            else
            {
                TempData["message"] = "please enter a route";
                return RedirectToAction("Index","BusRoutes");
            }
            var busServiceContext = _context.RouteStop.Include(r => r.BusRouteCodeNavigation)
                .Include(r => r.BusStopNumberNavigation)
                .Where(a=>a.BusRouteCodeNavigation.BusRouteCode==BusRCode)
                .OrderBy(a=>a.OffsetMinutes);

            var busRoute = _context.BusRoute.Where(a => a.BusRouteCode == BusRCode).FirstOrDefault();
            ViewData["RouteCode"] = busRoute.BusRouteCode;
            ViewData["RouteName"] = busRoute.RouteName;
            return View(await busServiceContext.ToListAsync());
        }

        // GET: RouteStops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeStop = await _context.RouteStop
                .Include(r => r.BusRouteCodeNavigation)
                .Include(r => r.BusStopNumberNavigation)
                .FirstOrDefaultAsync(m => m.RouteStopId == id);
            if (routeStop == null)
            {
                return NotFound();
            }

            return View(routeStop);
        }

        // GET: RouteStops/Create
        public IActionResult Create()
        {
            string busRcode = string.Empty;
            if(Request.Cookies["BusRouteCode"] != null)
            {
                busRcode = Request.Cookies["BusRouteCode"].ToString();
            }
            var busRoute = _context.BusRoute.Where(a => a.BusRouteCode == busRcode).FirstOrDefault();
            ViewData["RouteCode"] = busRoute.BusRouteCode;
            ViewData["RouteName"] = busRoute.RouteName;
            ViewData["BusRouteCode"] = new SelectList(_context.BusRoute, "BusRouteCode", "BusRouteCode");
            ViewData["BusStopNumber"] = new SelectList(_context.BusStop, "BusStopNumber", "Location");
            return View();
        }

        // POST: RouteStops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteStopId,BusRouteCode,BusStopNumber,OffsetMinutes")] RouteStop routeStop)
        {

            if (routeStop.OffsetMinutes < 0)
            {
                ModelState.AddModelError("","Offset min can not under 0");
            }
          else if (routeStop.OffsetMinutes == 0)
            {
                var isZero = _context.RouteStop.Where(a => a.OffsetMinutes == 0);
                if (isZero.Any())
                {
                    ModelState.AddModelError("", "offset 0min is already exist");
                }             
            }
                var isDouble = _context.RouteStop.Where(a => a.OffsetMinutes == routeStop.OffsetMinutes && a.BusRouteCode == routeStop.BusRouteCode);
                if (isDouble.Any())
                {
                    ModelState.AddModelError("", "is doubled");
                }
            int count = _context.RouteStop.Where(a => a.OffsetMinutes == routeStop.OffsetMinutes).Count();
            if (count > 3)
            {
                ModelState.AddModelError("", "cant over 3 times");
            }
            //string BusRCode = string.Empty;
            //if (Request.Cookies["BusRouteCode"] != null)
            //{
            //    BusRCode = Request.Cookies["BusRouteCode"].ToString();
            //}

            if (ModelState.IsValid)
            {
                _context.Add(routeStop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BusRouteCode"] = new SelectList(_context.BusRoute, "BusRouteCode", "BusRouteCode", routeStop.BusRouteCode);
            ViewData["BusStopNumber"] = new SelectList(_context.BusStop, "BusStopNumber", "Location", routeStop.BusStopNumber);
            return View(routeStop);
        }

        // GET: RouteStops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeStop = await _context.RouteStop.FindAsync(id);
            if (routeStop == null)
            {
                return NotFound();
            }
            ViewData["BusRouteCode"] = new SelectList(_context.BusRoute, "BusRouteCode", "BusRouteCode", routeStop.BusRouteCode);
            ViewData["BusStopNumber"] = new SelectList(_context.BusStop, "BusStopNumber", "BusStopNumber", routeStop.BusStopNumber);
            return View(routeStop);
        }

        // POST: RouteStops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouteStopId,BusRouteCode,BusStopNumber,OffsetMinutes")] RouteStop routeStop)
        {
            if (id != routeStop.RouteStopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routeStop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteStopExists(routeStop.RouteStopId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusRouteCode"] = new SelectList(_context.BusRoute, "BusRouteCode", "BusRouteCode", routeStop.BusRouteCode);
            ViewData["BusStopNumber"] = new SelectList(_context.BusStop, "BusStopNumber", "BusStopNumber", routeStop.BusStopNumber);
            return View(routeStop);
        }

        // GET: RouteStops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeStop = await _context.RouteStop
                .Include(r => r.BusRouteCodeNavigation)
                .Include(r => r.BusStopNumberNavigation)
                .FirstOrDefaultAsync(m => m.RouteStopId == id);
            if (routeStop == null)
            {
                return NotFound();
            }

            return View(routeStop);
        }

        // POST: RouteStops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routeStop = await _context.RouteStop.FindAsync(id);
            _context.RouteStop.Remove(routeStop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteStopExists(int id)
        {
            return _context.RouteStop.Any(e => e.RouteStopId == id);
        }
    }
}
