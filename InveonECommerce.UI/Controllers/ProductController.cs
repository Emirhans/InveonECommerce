using InveonECommerce.Bussines.Abstract;
using InveonECommerce.DataAccess;
using InveonECommerce.Entities;
using InveonECommerce.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InveonECommerce.UI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        // GET: Product
        //Admin Sayfası
        [Authorize(Roles = "Admin")]
        public ActionResult AdminView()
        {
            ViewBag.products = _repo.GetProducts().ToList();
            return View();
        }

        //User UI
        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            ViewBag.products = _repo.GetProducts().ToList();
            return View();
        }


        //resim değişkeni
        static string pic;
        //resim ekleme fonks.
        public ActionResult AddImage(HttpPostedFileBase ImageUrl)
        {
            pic = Path.GetFileName(ImageUrl.FileName);
            string path = Path.Combine(
            Server.MapPath("~/Content/img"), pic);
            ImageUrl.SaveAs(path);
            return RedirectToAction("AdminView", "Product");
        }

        //Ürün Ekleme
        [HttpPost]
        public JsonResult AddProduct(ProductModel model)
        {
            string res = "0";
            try
            {
                //Gelen ID varsa güncelleme işlemini başlat
                if (model.ProductID > 0)
                {
                    _repo.Update(model);     
                }
                else //Yoksa Ekle
                {
                    model.ImageUrl = pic;
                    _repo.Insert(model);
                }
            }
            catch (Exception ex)
            {
                res = ex.InnerException != null ?
                    ex.InnerException.Message :
                    (string.IsNullOrEmpty(ex.Message)
                    ? " Bir hata meydana geldi."
                    : ex.Message);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //Ürün ID'ye göre ürün getir
        public JsonResult GetProduct(int id)
        {
            var data = new ProductModel();
            try
            {
                data = _repo.GetProduct(id);
            }
            catch
            {

            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //ID'ye göre ürün sil
        public JsonResult DeleteProduct(int id)
        {
            var res = "0";
            try
            {
                _repo.Delete(id);
            }
            catch (Exception ex)
            {
                res = ex.InnerException != null ?
                    ex.InnerException.Message :
                    (string.IsNullOrEmpty(ex.Message)
                    ? " Bir hata meydana geldi."
                    : ex.Message);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}