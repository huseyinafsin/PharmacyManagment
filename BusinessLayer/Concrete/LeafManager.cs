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

        IleafDal _leadDal;

        public LeafManager(IleafDal ileafDal)
        {
            _leadDal = ileafDal;
        }

        public void AddLeaf(Leaf leaf)
        {
             _leadDal.Create(leaf);
        }

        public void DeleteLeaf(Leaf leaf)
        {
            _leadDal.Delete(leaf);
        }

        public Leaf GetLeaf(int id)
        {
            return _leadDal.GetById(id);
        }

        public List<Leaf> GetLeaves()
        {
            return _leadDal.GetAll();
        }

        public List<Leaf> GetLeaves(Expression<Func<Leaf, bool>> expression)
        {
            return _leadDal.GetAll(expression);
        }

        public void UpdateLeaf(Leaf leaf)
        {
            _leadDal.Update(leaf);
        }
    }
}
