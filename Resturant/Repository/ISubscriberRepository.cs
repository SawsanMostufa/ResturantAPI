using Resturant.Models;
using System.Collections.Generic;

namespace Resturant.Repository
{
    public interface ISubscriberRepository
    {

        int Delete(int id);
        List<Subscriber> GetAll();
        Subscriber GetById(int id);
        int Insert(Subscriber subscriber);
        int Update(int id, Subscriber subscriber);
        Subscriber getSubscriberByPhoneNumber(string phoneNumber);
    }
}
