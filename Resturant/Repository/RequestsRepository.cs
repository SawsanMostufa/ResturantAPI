using Microsoft.EntityFrameworkCore;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Repository
{
    public class RequestsRepository :IRequestsRepository
    {
        private readonly ApplicationDbContext context;

        public RequestsRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public int Delete(int id)
        {
            Request oldreq = GetById(id);
            context.requests.Remove(oldreq);
            return context.SaveChanges();

        }

        public List<Request> GetAll()
        {
           
            return context.requests.ToList();
        }

        public Request GetById(int id)
        {
            return context.requests.SingleOrDefault(r=>r.Id==id);
        }

        public List<Request> GetRequestesBySubscriberId(int id)
        {
            return context.requests.Include(r=>r.MealTypes).Include(r=>r.Other_meals).Where(r => r.SubscriberId == id).ToList();
        }

        public int Insert(Request request)
        {
            context.requests.Add(request);
            return context.SaveChanges();

        }

        public int Update(int id, Request request)
        {

            Request oldreq = GetById(id);
            if (oldreq != null)
            {
                oldreq.Quantity = request.Quantity;
                oldreq.Remaining_Quantity = request.Remaining_Quantity;
                

                return context.SaveChanges();
            }
            return 0;
        }

       
    }


    
}

