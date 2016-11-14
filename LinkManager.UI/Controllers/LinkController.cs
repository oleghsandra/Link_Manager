using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using LinkManager.Common.Entities;
using LinkManager.DAL.Abstraction.Repository;
using LinkManager.DAL.Concrete.Repository;
using LinkManager.UI.Models;

namespace LinkManager.UI.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkRepository _linkRepository;
        private readonly ILinkTypeRepository _linkTypeRepository;

        //ToDo: Add user repository, authorization and authentication
        private const int FakeUserId = 1;
        private const string FakeUserName = "Oleg";

        public LinkController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _linkRepository = new LinkRepository(connectionString);
            _linkTypeRepository = new LinkTypeRepository(connectionString);
        } 

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllLinkTypes()
        {
            return Json(_linkTypeRepository.GetAllLinkTypes(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void ChangeLinkFavoriteValue(LinkModel link)
        {
            _linkRepository.ChangeLinkFavoriteValue(link.Id, !link.IsFavorite);
        }

        [HttpPost]
        public void AddLink(LinkModel link)
        {
            link.Url = validateUrl(link.Url);
            _linkRepository.AddLink((LinkEntity)link);
        }

        [HttpPost]
        public void DeleteLink(LinkModel link)
        {
            _linkRepository.DeleteLink(link.Id);    
        }

        [HttpPost]
        public void UpdateLink(LinkModel link)
        {
            _linkRepository.UpdateLink((LinkEntity)link);
        }

        [HttpGet]
        public JsonResult GetLinks(int ownerId = 1) //ToDo: Fix it
        {
            var a = _linkRepository.GetLinks(ownerId);
            return Json(
                 a,
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCurrentUser()
        {
            //ToDo: Fix it
            return Json(
               new { Id = FakeUserId, Name = FakeUserName },
               JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<string> GetWebSiteTitle(LinkModel link)
        {
            try
            {
                string url = link.Url;
                url = validateUrl(url);

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string source = await client.DownloadStringTaskAsync(url);

                string title = Regex.Match(
                        source,
                        @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                        RegexOptions.IgnoreCase)
                    .Groups["Title"].Value;

                return title;
            }
            catch
            {
                return String.Empty;
            }
        }

        private string validateUrl(string url)
        {
            if (url.IndexOf("http", StringComparison.Ordinal) != 0)
            {
                string http = @"http://";
                http += url;
                url = http;
            }
            return url.Split('?')[0];
        }

    }
}
