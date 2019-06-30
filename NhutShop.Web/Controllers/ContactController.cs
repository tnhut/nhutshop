using AutoMapper;
using NhutShop.Model.Models;
using NhutShop.Service;
using NhutShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhutShop.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        IContactDetailService _contactDetailService;
         public ContactController(IContactDetailService contactDetailService)
        {
            this._contactDetailService = contactDetailService;
        }
        public ActionResult Index()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return View(contactViewModel);
        }
    }
}