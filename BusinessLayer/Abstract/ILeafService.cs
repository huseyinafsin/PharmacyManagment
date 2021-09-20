using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILeafService
    {
        void AddLeaf(Leaf leaf);
        void DeleteLeaf(Leaf leaf);
        void UpdateLeaf(Leaf leaf);
        Task<IQueryable<Leaf>> GetLeaves();
        List<Leaf> GetLeaves(Expression<Func<Leaf, bool>> expression);
        Leaf GetLeaf(int id);
    }
}
