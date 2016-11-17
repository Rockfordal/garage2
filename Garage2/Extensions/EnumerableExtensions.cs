using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Extensions
{
    public static class EnumerableExtensions
    {

        public static IEnumerable<System.Web.WebPages.Html.SelectListItem> ToSelectListItems(
              this IEnumerable<Garage2.Entities.Slot> slots, int selectedId)
        {
            return
                slots
                      //.OrderBy(slot => slot.PID)
                      .Select(slot =>
                          new System.Web.WebPages.Html.SelectListItem
                          {
                              Selected = (slot.Id == selectedId),
                              Text = slot.PID,
                              Value = slot.Id.ToString()
                          });
        }

    }
}