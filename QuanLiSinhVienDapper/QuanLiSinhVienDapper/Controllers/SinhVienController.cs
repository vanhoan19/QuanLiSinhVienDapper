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
    public class SinhVienController : Controller
    {
        private readonly StudentRepository studentRepository;
        private readonly KetQuaRepository ketQuaRepository;
        private readonly MonHocRepository monHocRepository;
        private const int PageSize = 10;
        public SinhVienController()
        {
            //studentRepository = new StudentRepository();
            //ketQuaRepository = new KetQuaRepository();
            //monHocRepository = new MonHocRepository();
        }

        public SinhVienController(StudentRepository studentRepository, KetQuaRepository ketQuaRepository, MonHocRepository monHocRepository)
        {
            this.studentRepository = studentRepository;
            this.ketQuaRepository = ketQuaRepository;
            this.monHocRepository = monHocRepository;
        }


        // GET: SinhVien
        public ActionResult Index(int? page, string search)
        {
            if (page == null) page = 1;
            if (search == null) search = "";
            var sinhViens = studentRepository.getAllSinhVienByMaSVorTenSV(search);
            ViewBag.PageNum = (int)Math.Ceiling(sinhViens.Count() * 1.0 / PageSize);
            ViewBag.CurrentPage = page;
            ViewBag.Search = search;

            List<SinhVien> selectedSinhViens = new List<SinhVien>();
            if (sinhViens.Count() > 0)
            {
                if (page == ViewBag.PageNum) selectedSinhViens = sinhViens.GetRange((int)((page - 1) * PageSize), (int)(sinhViens.Count() - (page - 1) * PageSize));
                else selectedSinhViens = sinhViens.GetRange((int)(page - 1) * PageSize, PageSize);
            }
            return View(selectedSinhViens);
        }

        public ActionResult Detail(string MaSV)
        {
            var sinhVien = studentRepository.getSinhVienByID(MaSV);
            var listDangKy = ketQuaRepository.getAllKetQuaByMaSV(MaSV);
            var listChuaDangKy = monHocRepository.getAllMonHocChuaDangKiByMaSV(MaSV);
            var sinhVienViewModel = new SinhVienViewModel(sinhVien, listDangKy, listChuaDangKy);
            return View(sinhVienViewModel);
        }

        public ActionResult Update(string MaSV, string MaMH)
        {
            var ketQua = new KetQua(MaSV, MaMH, null, null, null, "Đang học");
            ketQuaRepository.InsertKetQua(ketQua);
            return RedirectToAction("Detail", new { MaSV = MaSV });
        }
    }
}