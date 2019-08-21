using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OutXApp.Core.Models;

namespace OutXApp.Core.Helpers
{
    public static class ClinicMgtHelpers
    {
        public static IEnumerable<SelectListItem> GenderToSelectList()
        {
            var genderItems = EnumHelpers.ToSelectList(typeof(Gender)).ToList();
            genderItems.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return genderItems;
        }

    }
}