using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sagar_Dudhaiya_Practicel_Demo.ViewModels;

namespace Sagar_Dudhaiya_Practicel_Demo.Models
{
    public class clsUser
    {
        public List<clsState> GetAllState()
        {
            List<clsState> lstSate = new List<clsState>();

            string file = HttpContext.Current.Server.MapPath("~/Content/state.json");

            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                lstSate = JsonConvert.DeserializeObject<List<clsState>>(json) ?? new List<clsState>();
            }

            return lstSate;
        }


        public List<clsCity> GetAllCity()
        {
            List<clsCity> lstCity = new List<clsCity>();

            string file = HttpContext.Current.Server.MapPath("~/Content/city.json");

            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                lstCity = JsonConvert.DeserializeObject<List<clsCity>>(json) ?? new List<clsCity>();
            }

            return lstCity;
        }

        public List<clsUserViewModel> GetAllUserDetails()
        {
            List<clsUserViewModel> lstUsers = new List<clsUserViewModel>();

            string file = HttpContext.Current.Server.MapPath("~/Content/users.json");

            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                lstUsers = JsonConvert.DeserializeObject<List<clsUserViewModel>>(json) ?? new List<clsUserViewModel>();
            }

            lstUsers = lstUsers != null ? lstUsers.OrderBy(x => x.name).ToList() : new List<clsUserViewModel>();

            return lstUsers;
        }

        public void InsertUser(clsUserViewModel objUserEntity)
        {
            Guid newId = Guid.NewGuid();

            objUserEntity.userid = newId.ToString();

            List<clsUserViewModel> lstUsers = new List<clsUserViewModel>();

            string file = HttpContext.Current.Server.MapPath("~/Content/users.json");

            var json = System.IO.File.ReadAllText(file);
            
            lstUsers = JsonConvert.DeserializeObject<List<clsUserViewModel>>(json) ?? new List<clsUserViewModel>();

            lstUsers.Add(objUserEntity);

            json = JsonConvert.SerializeObject(lstUsers, Formatting.Indented);
            System.IO.File.WriteAllText(file, json);

        }

        public void DeleteUser(string strUserId)
        {
            List<clsUserViewModel> lstUsers = new List<clsUserViewModel>();

            string file = HttpContext.Current.Server.MapPath("~/Content/users.json");
            var json = System.IO.File.ReadAllText(file);

            lstUsers = JsonConvert.DeserializeObject<List<clsUserViewModel>>(json) ?? new List<clsUserViewModel>();

            lstUsers.RemoveAt(lstUsers.FindIndex(m => m.userid == strUserId));

            json = JsonConvert.SerializeObject(lstUsers, Formatting.Indented);
            System.IO.File.WriteAllText(file, json);
        }

        public clsUserViewModel GetUserDetailsById(string strUserId)
        {
            List<clsUserViewModel> lstUsers = new List<clsUserViewModel>();
            clsUserViewModel objUerEntity = new clsUserViewModel();

            string file = HttpContext.Current.Server.MapPath("~/Content/users.json");

            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                lstUsers = JsonConvert.DeserializeObject<List<clsUserViewModel>>(json) ?? new List<clsUserViewModel>();
            }

            objUerEntity = lstUsers.Where(u => u.userid == strUserId).FirstOrDefault();

            return objUerEntity;
        }

        public void UpdateUserDetailById(clsUserViewModel objUserEntity)
        {
            string strUserId = objUserEntity.userid;

            List<clsUserViewModel> lstUsers = new List<clsUserViewModel>();
            //clsUserViewModel objUserData = new clsUserViewModel();

            string file = HttpContext.Current.Server.MapPath("~/Content/users.json");
            var json = System.IO.File.ReadAllText(file);

            lstUsers = JsonConvert.DeserializeObject<List<clsUserViewModel>>(json) ?? new List<clsUserViewModel>();

            lstUsers.RemoveAt(lstUsers.FindIndex(m => m.userid == strUserId));

            lstUsers.Add(objUserEntity);

            json = JsonConvert.SerializeObject(lstUsers, Formatting.Indented);
            System.IO.File.WriteAllText(file, json);
        }


    }
}