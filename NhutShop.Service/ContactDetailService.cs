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
    public interface IContactDetailService
    {
        ContactDetail GetDefaultContact();

    }
  public  class ContactDetailService: IContactDetailService
    {
        IContactDetailRepository _contactdetailrepository;
        IUnitOfWork _unitofWork;

        public ContactDetailService(IContactDetailRepository contactdetailrepository, IUnitOfWork unitofWork)
        {
            this._contactdetailrepository = contactdetailrepository;
            this._unitofWork = unitofWork;
        }
        public ContactDetail GetDefaultContact()
        {
            return _contactdetailrepository.GetSingleByCondition(x => x.Status);
        }
    }
}
