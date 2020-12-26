﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _AdminService;
        public AdminController(IAdminService AdminService)
        {
            _AdminService = AdminService;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserDto dto)
        {
            User u = _AdminService.CreateUser(dto);
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
            Gym g = _AdminService.CreateGym(dto);
            if (g == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("yay", g);
            }
        }

        [HttpPost("CreateTrainingClass")]
        public IActionResult CreateTrainingClass(TrainingClassDto dto)
        {
            TrainingClass t = _AdminService.CreateTrainingClass(dto);
            if (t == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("yay", t);
            }
        }


        [HttpGet("GetUsersBookings")]
        public IActionResult GetUsersBookings(int userId)
        {
            List<Booking> b = _AdminService.GetUsersBookings(userId);
            if (b == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(b);
            }
        }

        [HttpPost("CreateTrainer")]
        public IActionResult CreateTrainer(TrainerDto dto)
        {
            Trainer t = _AdminService.CreateTrainer(dto);
            if (t == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("Tjoho", t);
            }
        }


        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int UserId)
        {
            User U = _AdminService.DeleteUser(UserId);
            if (U == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(U);
            }
        }
    }
}
