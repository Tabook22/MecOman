﻿using LissanDhofar_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LissanDhofar_V1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
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
        public ActionResult newsList()
        {
            return PartialView("_articleList");
        }
        //testing angularjs call
        [HttpGet]
        public JsonResult getMessage()
        {
            string msg = "بسم الله الرحمن الرحيم";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        //this will show the result of all links in the index page
        //[ChildActionOnly]
        //public ActionResult sDetails()
        //{

        //    return PartialView();
        //}
        //get users
        public JsonResult getPosts()
        {
            // string newsLst = string.Empty;
            List<Post> lstPosts = new List<Post>();
            Post pst = new Post();
            pst.post_title = "جلالة السلطان يتلقى برقية شكر من الرئيس الباكستاني";
            lstPosts.Add(pst);
            pst.post_title = "لسيد فهد يشيد بدور «الغرفة الإسلامية» في تنمية الروابط الاقتصادية";
            lstPosts.Add(pst);
            pst.post_title = "النفـط يواصـل مكاســبه لليوم الـ «5» والعماني فوق 55 دولارا";
            lstPosts.Add(pst);
            //Json Stringfy the newsLst
            //newsLst = new JavaScriptSerializer().Serialize(lstPosts);
            return Json(lstPosts, JsonRequestBehavior.AllowGet);


        }

        //conferences Videos-----------------------------------------------------------------
        //get all videso
        public JsonResult getVideos()
        {
            using(DhofarDb db=new DhofarDb())
            {
                List<ConfVideo> vLsts = db.ConfVideos.Where(x => x.vStatus == "1").ToList(); ;
                return Json(vLsts, JsonRequestBehavior.AllowGet);
            }
           
        }

        //add videos
        public JsonResult addVideos(ConfVideo video)
        {
            string msg = string.Empty;
            if (video != null)
            {
                using (DhofarDb db = new DhofarDb())
                {
                    video.vDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                    db.ConfVideos.Add(video);
                    db.SaveChanges();
                    msg = "تمت إضافة الفيديو بنجاح";
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
            }

            msg = "حدثت مشكلة أثناء إضافة الفيديو";
                return Json(msg, JsonRequestBehavior.AllowGet);
        }

        //Get partial view slider
        public ActionResult slider()
        {
            return PartialView();
        }

        //Site Navigation
        public ActionResult siteNav()
        {
            return PartialView();
        }

        //Site Footer
        public ActionResult siteFooter()
        {
            return PartialView();
        }
    }
}