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
   
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService, ICommonService commonService,
            IProductService productService)
        {
           _productCategoryService = productCategoryService;
            _commonService = commonService;
            _productService = productService;
        }
      //  [ChildActionOnly]
        [OutputCache(Duration = 3600, Location =System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>,IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var latesProduct = _productService.GetLatest(3);
            var topSalesProductModel = _productService.GetHotProduct(3);

            var latesProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(latesProduct);
            var topSalesProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSalesProductModel);
            homeViewModel.LastesProducts = latesProductViewModel;
            homeViewModel.TopSalesProducts = topSalesProductViewModel;
            return View(homeViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
          //  ViewBag.Time = DateTime.Now.ToString("T");
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}