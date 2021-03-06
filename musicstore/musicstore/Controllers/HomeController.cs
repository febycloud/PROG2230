﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMusicStore.Models;
using Microsoft.AspNetCore.Http;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            Response.Cookies.Append("artistID", "10");
            HttpContext.Session.SetString("artistName", "TestABC");
            HttpContext.Session.SetInt32("ID", 11);
            return View();
        }

        public IActionResult Privacy()
        {
            TempData["message"] = "fei";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult RequestStuff(string user)
        {
            //if (user != null) HttpContext.Session.SetString("user", user);
           
            var userName = "Test"; 
            ViewData["Message"] = $"Your application description page, '{userName}'";
            //Response.Cookies.Append("userName", userName); 
            List<Generic2String> headers = new List<Generic2String>(); foreach (var item in Request.Headers.Keys)
            {
            }
            headers.Add(new Generic2String("Request.Headers['Referer']", Request.Headers["Referer"])); headers.Add(new Generic2String("Request.Host", Request.Host.ToString())); foreach (var item in Request.Cookies.Keys)
            {
                headers.Add(new Generic2String($"Request.Cookies['{item}']", Request.Cookies[item]));
            }
            headers.Add(new Generic2String("Request.HttpContext.Connection.LocalIpAddress (user IP)", Request.HttpContext.Connection.LocalIpAddress.ToString()));
            headers.Add(new Generic2String("Request.HttpContext.Connection.LocalPort (user TCP port)", Request.HttpContext.Connection.LocalPort.ToString()));
            headers.Add(new Generic2String("Request.HttpContext.Connection.RemoteIpAddress (server IP)", Request.HttpContext.Connection.RemoteIpAddress.ToString()));
            headers.Add(new Generic2String("Request.HttpContext.Connection.RemotePort (server TCP port)", Request.HttpContext.Connection.RemotePort.ToString()));
            //headers.Add(new Generic2String("Request.HttpContext.Session.Id", Request.HttpContext.Session.Id.ToString())); 
            headers.Add(new Generic2String("Request.IsHttps", Request.IsHttps.ToString())); headers.Add(new Generic2String("Request.Method", Request.Method.ToString())); headers.Add(new Generic2String("Request.Path", Request.Path.ToString())); headers.Add(new Generic2String("Request.Protocol", Request.Protocol.ToString())); headers.Add(new Generic2String("Request.QueryString", Request.QueryString.ToString())); headers.Add(new Generic2String("Request.Query", Request.Query.ToString())); 
            foreach (var item in Request.Query)
            {
                headers.Add(new Generic2String($"Request.Query['{item.Key}']", item.Value));
            }
            return View(headers);
        }
        public IActionResult CreateCookie()
        {
            string ArtistID = string.Empty;
            if (Request.Cookies["artistID"] != null)
            {
                ArtistID = Request.Cookies["artist Id"].ToString();
            }
            return View();
        }
        public IActionResult ReadCookie()
        {
            string artistID = string.Empty;
            if (Request.Cookies["artistID"] != null)
            {
                artistID = Request.Cookies["artist id"].ToString();
            }

            return View();
        }

    }
}
