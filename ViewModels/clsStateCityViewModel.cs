using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sagar_Dudhaiya_Practicel_Demo.ViewModels
{
    public class clsStateCityViewModel
    {
    }

    public class clsState
    {
        public int stateid { get; set; }
        public string statename { get; set; }
    }

    public class clsCity
    {
        public int cityid { get; set; }
        public string cityname { get; set; }
        public int stateid { get; set; }
    }
}