using AutoMapper;
using Shop.Data.Infastructure;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShopEcommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productCategoryService;
        private IProductService _productService;
        private IUnitOfWork _unitOfWork;

        public HomeController(IProductCategoryService productCategoryService, IProductService productService, IUnitOfWork unitOfWork)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var hotProduct = _productService.GetHotProduct();
            var hotProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(hotProduct);
            var listProductCategory = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(listProductCategory);
            var homeViewModel = new HomeViewModel();
            homeViewModel.lastesProduct = hotProductViewModel;
            homeViewModel.latesProductCategory = listProductCategoryViewModel;
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = _productCategoryService.GetAll();
            var listproductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listproductCategoryViewModel);
        }
    }
}