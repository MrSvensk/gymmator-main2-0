﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBookingSystem.Models;
using GymBookingSystem.Models.DTO;
using GymBookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _UserService; 
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserDto dto)
        {
            User u = _UserService.CreateUser(dto);
            if (u == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("yay", u);
            }
        }

        [HttpPost("CreateGym")]
        public IActionResult CreateGym(GymDto dto)
        {
            Gym g = _UserService.CreateGym(dto);
            if (g == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("yay", g);
            }
        }
        
        [HttpGet("login")]
        public IActionResult Login(string username, string password) 
        {
            User user = _UserService.Login(username, password);
            if(user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(user);
            }

        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(int userId, string newPassword, string oldPassword)
        {
            string message = _UserService.ChangePassword(userId, newPassword, oldPassword);
            if(message.Contains("successfully"))
            {
                return Ok(message);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("CreateTrainingClass")]
        public IActionResult CreateTrainingClass(TrainingClassDto dto)
        {
            TrainingClass t = _UserService.CreateTrainingClass(dto);
            if (t == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("yay", t);
            }
        }

        [HttpGet("GetTrainingClass")]
        public IActionResult GetTrainingClass(int Id)
        {
            TrainingClass t = _UserService.GetTrainingClass(Id);
            if (t == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(t);
            }
        }

        [HttpGet("GetTrainingClasses")]
        public IActionResult GetTrainingClasses()
        {
            List<TrainingClass> t = _UserService.GetTrainingClasses();
            if (t == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(t);
            }
        }

        [HttpGet("GetGym")]
        public IActionResult GetGym()
        {
            List<Gym> g = _UserService.GetGyms();
            if (g == null)
            {
                return BadRequest();
            }
            else return Ok(g);
        }

        [HttpGet("GetTrainingClassesAtGym")]
        public IActionResult GetTrainingClassesAtGym(int GymId)
        {
            List<TrainingClass> t = _UserService.GetTrainingClassesAtGym(GymId);
            if (t == null)
            {
                return BadRequest();
            }

            else
            {
                return Ok(t);
            }
        }

        //[HttpGet("DeleteUser")]
        //public IActionResult DeleteUser(int UserId)
        //{
        //    User U = _UserService.DeleteUser(UserId);
        //    if (U == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(U);
        //    }
        //}
    }
}
