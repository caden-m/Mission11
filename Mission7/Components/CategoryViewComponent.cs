using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission7.Models;

namespace Mission7.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public CategoryViewComponent (IBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var Categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);


            return View(Categories);
        }

    }
}
