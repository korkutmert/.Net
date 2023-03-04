using OzelDersYerim.Business.Abstract;
using OzelDersYerim.Data.Abstract;
using OzelDersYerim.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersYerim.Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Branch branch)
        {
            await _unitOfWork.Branches.CreateAsync(branch);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(Branch branch)
        {
            _unitOfWork.Branches.Delete(branch);
            _unitOfWork.Save();
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            return await _unitOfWork.Branches.GetAllAsync();
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _unitOfWork.Branches.GetByIdAsync(id);
        }

        public void Update(Branch branch)
        {
            _unitOfWork.Branches.Update(branch);
            _unitOfWork.Save();
        }
    }
}
