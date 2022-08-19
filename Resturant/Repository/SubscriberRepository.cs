using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Repository
{
    public class SubscriberRepository:ISubscriberRepository
    {

        ApplicationDbContext context;
        public SubscriberRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public int Delete(int id)
        {
            Subscriber oldsub = GetById(id);
            context.subscribers.Remove(oldsub);
            return context.SaveChanges();
        }

        public List<Subscriber> GetAll()
        {
            return context.subscribers.ToList();
        }

        public Subscriber GetById(int id)
        {
            return context.subscribers.SingleOrDefault(x => x.Id == id);
        }

       

        public int Insert(Subscriber subscriber)
        {
            context.subscribers.Add(subscriber);
            return context.SaveChanges();
        }

        public int Update(int id, Subscriber subscriber)
        {
            Subscriber oldsub = GetById(id);
            if (oldsub != null)
            {
                oldsub.Name = subscriber.Name;
                oldsub.PhoneNumber = subscriber.PhoneNumber;
                oldsub.EndDate=subscriber.EndDate;
                oldsub.StartDate = subscriber.StartDate;
                oldsub.NumberOfMail=subscriber.NumberOfMail;
                return context.SaveChanges();
            }
            return 0;
        }
        public Subscriber getSubscriberByPhoneNumber(string phone)
        {
            return context.subscribers.FirstOrDefault(s => s.PhoneNumber == phone);
        }

    }
}
