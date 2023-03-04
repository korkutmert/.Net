using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Core;
using OzelDersYerim.Entity.Concrete;
using OzelDersYerim.Web.Areas.Admin.Models.Dtos;

namespace OzelDersYerim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BranchController : Controller
    {

        private readonly IBranchService _branchManager;

        public BranchController(IBranchService branchManager)
        {
            _branchManager = branchManager;
        }

        public async Task <IActionResult> Index()
        {
            var branch = await _branchManager.GetAllAsync();
            List<BranchDto> branchDtos = new List<BranchDto>();
            foreach (var item in branch)
            {
                branchDtos.Add(new BranchDto {
                    Id = item.Id,
                 BranchName =item.BranchName,
                 Url=item.Url,
                 ImageUrl=item.ImageUrl
                });
            }
            return View(branchDtos);
        }

        
        public IActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
          public async Task<IActionResult> CreateBranch(BranchDto branchAddDto)
        {
            if (ModelState.IsValid)
            {
                var url=Jobs.InitUrl(branchAddDto.BranchName);
                var branch=new Branch
                {
                 BranchName=branchAddDto.BranchName,
                 Description=branchAddDto.Description,
                 Url=url
                };
                await _branchManager.CreateAsync(branch);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var branch= await _branchManager.GetByIdAsync(id);
            if (branch==null){return NotFound();}
            var branchUpdateDto = new BranchDto
            {
                Id=branch.Id,
                Description=branch.Description,
                Url=branch.Url
            };
            return View(branchUpdateDto);
              
        }


        [HttpPost]
        public async Task<IActionResult> Edit(BranchDto branchUpdateDto)
        {
           
              if (ModelState.IsValid)
              {
                var url=Jobs.InitUrl(branchUpdateDto.BranchName);
                var branch=await _branchManager.GetByIdAsync(branchUpdateDto.Id);
                if(branch==null) {return NotFound();}
                branch.BranchName=branchUpdateDto.BranchName;
                branch.Description=branchUpdateDto.Description;
                branch.Url=url;
                _branchManager.Update(branch);
                return RedirectToAction("Index");
              }
              return View(branchUpdateDto);
        }

       
    }
}