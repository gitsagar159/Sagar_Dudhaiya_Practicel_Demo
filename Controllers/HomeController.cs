using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sagar_Dudhaiya_Practicel_Demo.Models;
using Sagar_Dudhaiya_Practicel_Demo.ViewModels;

namespace Sagar_Dudhaiya_Practicel_Demo.Controllers
{
    public class HomeController : Controller
    {
        clsUser objUser = new clsUser();
        public ActionResult Index()
        {
            List<clsUserViewModel> lstUsers = new List<clsUserViewModel>();
            lstUsers = objUser.GetAllUserDetails();

            ViewBag.lstState = objUser.GetAllState();
            ViewBag.lstCity = objUser.GetAllCity();

            return View(lstUsers);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            clsUserViewModel objUserEntity = new clsUserViewModel();

            ViewBag.lstState = this.FillStateDropdwon();
            ViewBag.lstCity = this.FillCityDropdwon();

            return View(objUserEntity);
        }

        [HttpPost]
        public ActionResult Registration(clsUserViewModel objUserEntity, HttpPostedFileBase file)
        {
            string path = "";

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images"), pic);
                file.SaveAs(path);

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }

            objUserEntity.profilepic = path;

            objUser.InsertUser(objUserEntity);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditUser(string id)
        {
            clsUserViewModel objUserEntity = new clsUserViewModel();

            objUserEntity = objUser.GetUserDetailsById(id);

            int intStateId = 0, intCityId = 0;
            int.TryParse(objUserEntity.state, out intStateId);
            int.TryParse(objUserEntity.city, out intCityId);

            ViewBag.lstState = this.FillStateDropdwon(intStateId);
            ViewBag.lstCity = this.FillCityDropdwon(intCityId);

            return View(objUserEntity);
        }

        [HttpPost]
        public ActionResult EditUser(clsUserViewModel objUserEntity, HttpPostedFileBase file)
        {

            string path = "";

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images"), pic);
                file.SaveAs(path);

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }

            objUserEntity.profilepic = path;

            objUser.UpdateUserDetailById(objUserEntity);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteUser(string id)
        {
            objUser.DeleteUser(id);
            return RedirectToAction("Index", "Home");
        }

        public List<SelectListItem> FillStateDropdwon(int intStateId = 0)
        {
            List<SelectListItem> lstState = new List<SelectListItem>();

            List<clsState> objlstSate = new List<clsState>();

            objlstSate = objUser.GetAllState();

            foreach (clsState item in objlstSate)
            {
                lstState.Add(new SelectListItem { Text = item.statename, Value = item.stateid.ToString(), Selected = item.stateid == intStateId ? true : false });
            }

            return lstState;

        }


        public List<SelectListItem> FillCityDropdwon(int intCityId = 0)
        {
            List<SelectListItem> lstCity = new List<SelectListItem>();

            List<clsCity> objlstSate = new List<clsCity>();

            objlstSate = objUser.GetAllCity();

            foreach (clsCity item in objlstSate)
            {
                lstCity.Add(new SelectListItem { Text = item.cityname, Value = item.cityid.ToString(), Selected = item.cityid == intCityId ? true : false });
            }

            return lstCity;

        }


    }
}