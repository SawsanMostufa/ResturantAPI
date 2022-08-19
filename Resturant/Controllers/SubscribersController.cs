using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Repository;
using System;
using System.Collections.Generic;

namespace Resturant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {

        ISubscriberRepository subscriberRepository;
        public SubscribersController(ISubscriberRepository subscriber)
        {
            subscriberRepository = subscriber;

        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<Subscriber> subscriberList = subscriberRepository.GetAll();

            if (subscriberList == null)
            {
                return BadRequest("Empty Subscriber List");
            }
            return Ok(subscriberList);
        }
        [HttpGet("{id:int}")]

        public IActionResult getBySubscriberByID(int id)
        {
            Subscriber subscriberList = subscriberRepository.GetById(id);
            if (subscriberList == null)
            {
                return BadRequest("there is no Category with this id");
            }
            return Ok(subscriberList);
        }

        [HttpPost]
        public IActionResult Insert(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    subscriber.RemainingQuantity = subscriber.NumberOfMail;
                    subscriberRepository.Insert(subscriber);
                    return Ok("Subscriber Added Successfully");
                }
                catch //(Exception ex)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Can't add  Subscriber");
                    // return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Subscriber subscriber)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    subscriberRepository.Update(id, subscriber);

                    return StatusCode(StatusCodes.Status204NoContent, "Data are Saved");
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
                subscriberRepository.Delete(id);
                return Ok("Subscriber Deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Can't Delete this Subscriber");
            }
        }

        [HttpGet("Ay7aga/{phone}")]
        public IActionResult GetSubscriberByPhoneNumber(string phone)
        {
            Subscriber subscriber;
            try
            {

                subscriber= subscriberRepository.getSubscriberByPhoneNumber(phone);
              
                    return Ok(subscriber);
                
                
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Can't return a subscriber this ");
            }


        }
    }
}