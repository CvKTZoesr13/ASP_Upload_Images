using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Upload_Images.Models;
using PagedList;

namespace ASP_Upload_Images.Controllers
{
    public class HangsController : Controller
    {
        private fShop db = new fShop();

        // GET: Hangs, sortByPrice, sortByName
        // code here
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {

            // variable that get current sortOrder
            ViewBag.CurrentSort = sortOrder;
            // get list of products
            // orderVars
            ViewBag.OrderByName = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.OrderByPrice = sortOrder=="Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var hangs = db.Hang.Select(p => p);

            switch (sortOrder)
            {
                case "name_desc":
                    hangs = hangs.OrderByDescending(p => p.TenHang);
                    break;
                case "Price":
                    hangs = hangs.OrderBy(p => p.Gia);
                    break;
                case "price_desc":
                    hangs = hangs.OrderByDescending(p => p.Gia);
                    break;
                default:
                    hangs = hangs.OrderBy(p => p.MaHang);
                    break;
            }
            //search string
            if (!String.IsNullOrEmpty(searchString))
            {
                hangs = hangs.Where(p => p.TenHang.Contains(searchString));
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(hangs.ToPagedList(pageNumber, pageSize));
        }
        // end here
        // GET: Hangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hang.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // GET: Hangs/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,MaNCC,TenHang,Gia,LuongCo,MoTa,ChietKhau,HinhAnh")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                // upload and save image into server
                // code here
                hang.HinhAnh = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadFile = Server.MapPath("~/wwwroot/Images/" + FileName);
                    f.SaveAs(UploadFile);
                    hang.HinhAnh = FileName;
                }
                // end here
                db.Hang.Add(hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
            return View(hang);
        }

        // GET: Hangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hang.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
            return View(hang);
        }

        // POST: Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,MaNCC,TenHang,Gia,LuongCo,MoTa,ChietKhau,HinhAnh")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                // update and save new image into server
                // code here
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadFile = Server.MapPath("~/wwwroot/Images/" + FileName);
                    f.SaveAs(UploadFile);
                    hang.HinhAnh = FileName;
                }
                // end here
                db.Entry(hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.Nha_CC, "MaNCC", "TenNCC", hang.MaNCC);
            return View(hang);
        }

        // GET: Hangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hang.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hang hang = db.Hang.Find(id);
            db.Hang.Remove(hang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
