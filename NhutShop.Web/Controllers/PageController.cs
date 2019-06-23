using AutoMapper;
using NhutShop.Model.Models;
using NhutShop.Service;
using NhutShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhutShop.Web.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        IPageService _pageService;
        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        public ActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            var model = Mapper.Map<Page, PageViewModel>(page);
            return View(model);
        }
    }
}