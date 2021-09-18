using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILeafService
    {
        void AddLeaf(Leaf leaf);
        void DeleteLeaf(Leaf leaf);
        void UpdateLeaf(Leaf leaf);
        List<Leaf> GetLeaves();
        Leaf GetLeaf(int id);
    }
}
