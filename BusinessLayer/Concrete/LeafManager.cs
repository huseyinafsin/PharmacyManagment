using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Constant;
using Core.Entities;
using Core.Utilities.Result;

namespace BusinessLayer.Concrete
{
    public class LeafManager : ILeafService
    {

        private readonly ILeafDal _leadDal;

        public LeafManager(ILeafDal ileafDal)
        {
            _leadDal = ileafDal;
        }

        public IResult AddLeaf(Leaf leaf)
        {
             _leadDal.Add(leaf);
             return new SuccessResult(Messages.LeafAdded);
        }

        public IResult DeleteLeaf(Leaf leaf)
        {
            _leadDal.Delete(leaf);
            return new SuccessResult(Messages.LeafDeleted);
        }

        public IDataResult<Leaf> GetLeaf(int id)
        {
            return new SuccessDataResult<Leaf>( _leadDal.Get(x => x.LeafId == id),Messages.LeafFetched);
        }


        public IDataResult<List<Leaf>> GetLeaves(Expression<Func<Leaf, bool>> expression)
        {
            return new SuccessDataResult<List<Leaf>>( _leadDal.GetAll(expression),Messages.LeafListed);
        }


        public IResult UpdateLeaf(Leaf leaf)
        {
            _leadDal.Update(leaf);
            return new SuccessResult(Messages.LeafUpdated);
        }
    }
}
