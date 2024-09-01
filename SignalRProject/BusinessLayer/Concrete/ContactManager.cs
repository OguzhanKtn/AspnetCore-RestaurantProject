using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _ContactDal;

        public ContactManager(IContactDal ContactDal)
        {
            _ContactDal = ContactDal;
        }

        public void TAdd(Contact entity)
        {
            _ContactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _ContactDal.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return _ContactDal.GetAll();
        }

        public Contact TGetById(int id)
        {
            return _ContactDal.GetById(id);
        }

        public void TUpdate(Contact entity)
        {
            _ContactDal.Update(entity);
        }
    }
}
