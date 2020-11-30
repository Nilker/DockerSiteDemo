using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebCore3.Models;

namespace WebCore3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger,
                              IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            var p1 = this.HttpContext.Request.Method;

 var ip = this.Request.Headers["X-Forwarded-For"].FirstOrDefault();
    if (string.IsNullOrEmpty(ip))
    {
        ip = this.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }

            //外网ip，必须部署在外网服务器上.  Server-client如果在一个内网中,获取的还是内网地址
            ViewBag.Remote = ip+":"+this.HttpContext.Connection.RemotePort+"--->"+this.Request.Headers["Host"].FirstOrDefault();
            

            //获取本地ip地址和端口,即项目部署在哪,获取的就是哪的。
            ViewBag.Local = this.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString()+":"+this.HttpContext.Connection.LocalPort;;
            
            _logger.LogInformation("22223333");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
