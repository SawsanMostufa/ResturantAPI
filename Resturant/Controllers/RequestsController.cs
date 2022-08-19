using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resturant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsRepository requestRepository;
        private readonly ISubscriberRepository subscriberRepository;
        public RequestsController(IRequestsRepository request, ISubscriberRepository _subscriberRepository)
        {
            this.requestRepository = request;
            this.subscriberRepository = _subscriberRepository;
        }
        [HttpGet]
        public IActionResult getAll()=>Ok( this.requestRepository.GetAll());

        [HttpGet("{id:int}")]

        public IActionResult getByID(int id )
        {
            Request requestList = requestRepository.GetById(id);
            if (requestList == null)
            {
                return BadRequest("there is no Request with this id");
            }
            return Ok(requestList);
        }


        [HttpGet("SubscriberId")]
        public IActionResult getrequestBySubscriberID([FromQuery] int id)
        {
           List<Request> ReqList = requestRepository.GetRequestesBySubscriberId(id);
            if (ReqList == null)
            {
                return BadRequest("NO Matches");
            }
            return Ok(ReqList);
        }

        [HttpPost]
        public IActionResult Insert(Request request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    requestRepository.Insert(request);
                    return Ok("Request Added Successfully");
                }
                catch
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Can't add  Request");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("{id:int}")]
        public IActionResult InsertOrder(Request request,int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Subscriber subscriber = subscriberRepository.GetById(id);
                     if(subscriber != null)
                    {
                        subscriber.RemainingQuantity -= request.Quantity;
                        request.Remaining_Quantity=subscriber.RemainingQuantity;
                        request.SubscriberId = id;
                    }
                    requestRepository.Insert(request);
                    return Ok(request.Remaining_Quantity);
                }
                catch
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Can't add  Request");
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Request request)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    requestRepository.Update(id, request);

                    return StatusCode(StatusCodes.Status204NoContent, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                requestRepository.Delete(id);
                return Ok("Request Deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Can't Delete this Request");
            }


        }



       



    }
}
