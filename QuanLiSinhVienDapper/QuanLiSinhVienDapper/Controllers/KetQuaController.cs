using QuanLiSinhVienDapper.Models;
using QuanLiSinhVienDapper.Repository;
using QuanLiSinhVienDapper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiSinhVienDapper.Controllers
{
    public class KetQuaController : Controller
    {
        private readonly StudentRepository studentRepository;
        private readonly KetQuaRepository ketQuaRepository;
        private readonly MonHocRepository monHocRepository;
        public KetQuaController()
        {
            //studentRepository = new StudentRepository();
            //ketQuaRepository = new KetQuaRepository();
            //monHocRepository = new MonHocRepository();
        }
        public KetQuaController(StudentRepository studentRepository, KetQuaRepository ketQuaRepository, MonHocRepository monHocRepository)
        {
            this.studentRepository = studentRepository;
            this.ketQuaRepository = ketQuaRepository;
            this.monHocRepository = monHocRepository;
        }

        // GET: KetQua
        public ActionResult UpdateKetQua(string MaMH)
        {
            IEnumerable<KetQua> lstKetQuaDangHoc;
            ViewBag.MaMH = MaMH;
            if (MaMH == null || MaMH == "All")
            {
                lstKetQuaDangHoc = ketQuaRepository.getAllKetQuaDangHoc();
            }
            else
            {
                lstKetQuaDangHoc = ketQuaRepository.getAllKetQuaDangHocByMaMH(MaMH);
            }
            ViewBag.MonHoc = selectMonHocs();
            return View(lstKetQuaDangHoc.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(List<KetQua> lstKetQua)
        {
            if (ModelState.IsValid)
            {
                if (lstKetQua != null)
                {
                    foreach (var ketQua in lstKetQua)
                    {
                        if (ketQua.DQT != null && ketQua.DTP != null)
                        {
                            var monHoc = monHocRepository.getMonHocByID(ketQua.MaMH);
                            ketQua.DiemTong = (monHoc.TiLeDQT * ketQua.DQT + monHoc.TiLeDTP * ketQua.DTP) / (monHoc.TiLeDQT + monHoc.TiLeDTP);
                            if (ketQua.DiemTong >= 4) ketQua.TrangThai = "Qua môn";
                            else ketQua.TrangThai = "Trượt";
                        }
                        ketQuaRepository.UpdateKetQua(ketQua);
                    }
                }
            }
            return RedirectToAction("UpdateKetQua");
        }

        private List<SelectListItem> selectMonHocs()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var lstMonHoc = monHocRepository.getAllMonHoc();
            foreach (var monHoc in lstMonHoc)
            {
                items.Add(new SelectListItem
                {
                    Text = monHoc.TenMon,
                    Value = monHoc.MaMH
                });
            }
            return items;
        }
    }
}