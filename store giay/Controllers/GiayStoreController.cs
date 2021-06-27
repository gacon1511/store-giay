﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using store_giay.Models;

namespace store_giay.Controllers
{
    public class GiayStoreController : Controller
    {
        // GET: GiayStore

        dbStoregiayDataContext data = new dbStoregiayDataContext();

        private List<Sanpham> Laygiaymoi(int count)
        {
            return data.Sanphams.OrderByDescending(a => a.ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var giaymoi = Laygiaymoi(5);
            return View(giaymoi);
        }
        public ActionResult Loaisanpham()
        {
            var loaisanpham = from lsp in data.Loaisanphams select lsp;
            return PartialView(loaisanpham);
        }
        public ActionResult Nhanhieu()
        {
            var nhanhieu = from nh in data.Nhanhieus select nh;
            return PartialView(nhanhieu);
        }
    }
}