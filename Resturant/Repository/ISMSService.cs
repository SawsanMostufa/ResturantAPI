using Twilio.Rest.Api.V2010.Account;

namespace Resturant.Repository
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body);
    }
}