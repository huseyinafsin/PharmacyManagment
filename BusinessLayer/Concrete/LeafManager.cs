using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Leaf> GetLeaves()
        {
            return eFLeafRepository.GetAll().ToList();
        }

        public void UpdateLeaf(Leaf leaf)
        {
            _ = eFLeafRepository.Update(leaf);
        }
    }
}
