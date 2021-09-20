using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LeafManager : ILeafService
    {

        EFLeafRepository eFLeafRepository;

        public LeafManager()
        {
            eFLeafRepository = new EFLeafRepository();
        }

        public void AddLeaf(Leaf leaf)
        {
            _ = eFLeafRepository.Create(leaf);
        }

        public void DeleteLeaf(Leaf leaf)
        {
            _ = eFLeafRepository.Delete(leaf);
        }

        public Leaf GetLeaf(int id)
        {
            return eFLeafRepository.GetById(id).Result;
        }

        public async Task<IQueryable<Leaf>> GetLeaves()
        {
            return await eFLeafRepository.GetAll();
        }

        public List<Leaf> GetLeaves(Expression<Func<Leaf, bool>> expression)
        {
            return eFLeafRepository.GetAll(expression).ToList();
        }

        public void UpdateLeaf(Leaf leaf)
        {
            _ = eFLeafRepository.Update(leaf);
        }
    }
}
