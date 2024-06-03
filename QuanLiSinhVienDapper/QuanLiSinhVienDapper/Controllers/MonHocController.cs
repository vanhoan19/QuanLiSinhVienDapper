using QuanLiSinhVienDapper.Models;
using QuanLiSinhVienDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiSinhVienDapper.Controllers
{
    public class MonHocController : Controller
    {
        private readonly MonHocRepository monHocRepository;
        public MonHocController()
        {
            //monHocRepository = new MonHocRepository();
        }
        public MonHocController(MonHocRepository monHocRepository)
        {
            this.monHocRepository = monHocRepository;
        }


        // GET: MonHoc
        public ActionResult Index()
        {
            return View(monHocRepository.getAllMonHoc());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonHoc monHoc)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
            {
                int isnetedRows = monHocRepository.InsertMonHoc(monHoc);
                isSuccess = isnetedRows > 0;
            }
            if (!isSuccess)
            {
                ViewBag.ErrorMessage = "Mã sinh viên đã tồn tại";
                return View();
            }
            else return RedirectToAction("Index");

        }
    }
}