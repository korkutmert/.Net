using Microsoft.AspNetCore.Mvc;
using OzelDersYerim.Business.Abstract;

namespace OzelDersYerim.Web.ViewComponents
{
    public class BranchesViewComponent : ViewComponent
    {
        private readonly IBranchService _branchService;

        public BranchesViewComponent(IBranchService branchService)
        {
            _branchService = branchService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["branchurl"]!=null)
            {
                ViewBag.SelectedBranch = RouteData.Values["branchurl"];
            }
            var branches = await _branchService.GetAllAsync();
            return View(branches);
        }
    }
}
