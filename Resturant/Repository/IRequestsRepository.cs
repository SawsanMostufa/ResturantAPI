using Resturant.Models;
using System.Collections.Generic;

namespace Resturant.Repository
{
    public interface IRequestsRepository
    {

         int Delete(int id);
        List<Request> GetAll();
        Request GetById(int id);
        List<Request> GetRequestesBySubscriberId(int id);
        int Insert(Request request);
        int Update(int id, Request request);
    
    }
}
