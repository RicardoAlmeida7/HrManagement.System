using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HrManagement.WebApplication.Utils
{
    public class PageHandler
    {
        private static string RenderRazorPageToString(PageModel page, string viewName, object? model = null)
        {
            page.ViewData.Model = model;
            page.PageContext.ViewData.Model = model;
            
            using var sw = new StringWriter();
            //IViewEngine? viewEngine = page.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            var viewEngine = page.HttpContext.RequestServices.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
            var viewResult = viewEngine.FindPage(page.PageContext, viewName);
            
            PageContext viewContext = new(page.PageContext);
            viewContext.ViewData.Model = model;
            viewResult.Page.ExecuteAsync().Wait();
            return sw.GetStringBuilder().ToString();
        }

        //public static string RenderRazorViewToString(PageModel pageModel, string viewName, object model = null)
        //{
        //    pageModel.ViewData.Model = model;
        //    using (var sw = new StringWriter())
        //    {
        //        var viewEngine = pageModel.HttpContext.RequestServices.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
        //        var viewResult = viewEngine.FindPage(pageModel, viewName);
        //        var viewContext = new PageContext(pageModel.HttpContext, pageModel.ViewData, pageModel.Metadata, pageModel.TempData, sw, new HtmlHelperOptions());
        //        var task = viewResult.Page.ExecuteAsync(viewContext);
        //        task.Wait();
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}

        public static string ValidRenderRazorPageToString(PageModel page, string viewName, object? model = null)
        {
            return JsonSerializer.Serialize(new { isValid = true, html = RenderRazorPageToString(page, viewName, model) });
        }

        public static string InvalidRenderRazorPageToString(PageModel page, string viewName, object? model = null)
        {
            return JsonSerializer.Serialize(new { isValid = false, html = RenderRazorPageToString(page, viewName, model) });
        }
    }
}
