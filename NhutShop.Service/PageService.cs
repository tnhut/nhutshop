using NhutShop.Data.Infrastructure;
using NhutShop.Data.Repositories;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Service
{
    public interface IPageService
    {
        Page GetByAlias(string alias);
    }
    class PageService : IPageService
    {
        IPageRepository _pagerepository;
        IUnitOfWork _unitOfWork;
        public PageService(IPageRepository pagerepository, IUnitOfWork unitOfWork)
        {
            this._pagerepository = pagerepository;
            this._unitOfWork = unitOfWork;
        }
        public Page GetByAlias(string alias)
        {
            return _pagerepository.GetSingleByCondition(x=>x.Alias==alias);
        }
    }
}
