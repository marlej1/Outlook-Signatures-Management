﻿using System.Web;
using System.Web.Mvc;

namespace Outlook_Signatures_Management
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
