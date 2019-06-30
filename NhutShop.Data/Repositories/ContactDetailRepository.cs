﻿using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Repositories
{
    public  interface IContactDetailRepository: IRepository<ContactDetail>
    {

    }

    public class ContactDetailRepository: RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
