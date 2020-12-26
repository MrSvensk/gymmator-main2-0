﻿using GymBookingSystem.Models;
using GymBookingSystem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymBookingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly GymContext _context;

        public UserService(GymContext context)
        {
            _context = context;
        }

        public User CreateUser(UserDto dto)
        {
            User U = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Admin = dto.Admin
            };

            LoginCredentials lc = new LoginCredentials();
            _context.Users.Add(U);
            _context.SaveChanges();

            lc.UserId = U.UserId;
            lc.Username = dto.Username;
            lc.Password = dto.Password;

            _context.LoginCredentials.Add(lc);
            _context.SaveChanges();
            return U;
        }


        public User Login(string username, string password)
        {         
           LoginCredentials lc = _context.LoginCredentials.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
           
            if (lc != null)
                return _context.Users.Where(x => x.UserId == lc.UserId).FirstOrDefault();
           else
                return null;
        }

        public string ChangePassword(int userId, string newPassword, string oldPassword)
        {
            LoginCredentials lc = _context.LoginCredentials.Where(x => x.UserId == userId && x.Password == oldPassword).FirstOrDefault();
            
            if (lc != null)
            {
                lc.Password = newPassword;
                _context.Update(lc);
                _context.SaveChanges();
                return "Password changed successfully";
            }
            else
            {
                return "Failed to change password ";
            }
        }

        public Gym CreateGym(GymDto dto)
        {
            Gym G = new Gym()
            {
                Name = dto.Name,
                StreetAdress = dto.StreetAdress,
                PostalCode = dto.PostalCode,
                City = dto.City,
                OperationalHours = dto.OperationalHours,
                MaxPeople = dto.MaxPeople,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Gyms.Add(G);
            _context.SaveChanges();

            return G;
        
        }


        public TrainingClass CreateTrainingClass(TrainingClassDto dto)
        {
            TrainingClass tc = new TrainingClass()
            {
                    //TrainingClassId = dto.TrainingClassId,
                    GymId = dto.GymId,
                    Name = dto.Name,
                    TrainerId = dto.TrainerId,
                    MaxPeople = dto.MaxPeople,
                    Description = dto.Description,
                    Start = dto.Start,
                    End = dto.End
            };

            _context.TrainingClasses.Add(tc);
            _context.SaveChanges();
            return tc;
        }


        public TrainingClass GetTrainingClass(int Id)
        {
            var t = _context.TrainingClasses.Where(x => x.TrainingClassId == Id).FirstOrDefault();
            
            if (t!=null)
            {
                return t;
            }

            else
            {
                return null;
            }
        }


        public List<TrainingClass> GetTrainingClasses()
        {
            List < TrainingClass > t = _context.TrainingClasses.ToList();

            if (t != null)
            {
                return t;
            }

            else
            {
                return null;
            }

        }

        public Gym GetGym(int Id)
        {
            var g = _context.Gyms.Where(x => x.GymId == Id).FirstOrDefault();

            if (g != null)
            {
                return g;
            }

            else
            {
                return null;
            }
        }

        public List<Gym> GetGyms()
        {
            List<Gym> g = _context.Gyms.ToList();

            if (g != null)
            {
                return g;
            }

            else
            {
                return null;
            }

        }

        public List<TrainingClass> GetTrainingClassesAtGym(int GymId)
        {
            List<TrainingClass> t = _context.TrainingClasses.Where(x => x.GymId == GymId).ToList();

            if (t != null)
            {
                return t;
            }

            else
            {
                return null;
            }

        }

        public Booking CreateBooking(BookingDto dto)
        {
            Booking b = new Booking()
            {
                GymId = dto.GymId,
                UserId = dto.UserId,
                TrainerId = dto.TrainerId,
                Timestamp = dto.Timestamp,
                Date = dto.Date,
                TrainingClassId = dto.TrainingClassId
            };

            _context.Bookings.Add(b);
            _context.SaveChanges();
            return b;
        }

        public Trainer CreateTrainer(TrainerDto dto)
        {
            Trainer t = new Trainer()
            {

                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
            _context.Trainers.Add(t);
            _context.SaveChanges();
            return t;

        }



        //public User DeleteUser(int UserId)
        //{
        //    User U = _context.Users.Where(x => x.UserId == UserId).FirstOrDefault();
        //    _context.Users.Remove(U);
        //    _context.SaveChanges();

        //    return U;
        //}

        //public string ChangeClass(int trainingclassid, string changegymid, string changetrainerid, string changemaxpeople, string changedescription, string changedatetime_start, string changedatetime_end)
        //{
        //    TrainingClass tc = _context.TrainingClasses.Where(x => x.TrainingClassId == trainingclassid && x.GymId == changegymid == && x.TrainerId == changetrainerid == && x.Maxpeople
        //            == changemaxpeople && x.Description == changedescription && x.DateTime_Start == changedatetime_start && x.DateTime_End == changedatetime_end).FirstOrDefault();

        //    if (tc != null)
        //    {
        //        //tc.TrainingClassId = newTrainingClassId;
        //        tc.GymId = changeGymId;
        //        tc.TrainerId = changeTrainerId;
        //        tc.Maxpeople = changeMaxPeople;
        //        tc.Description = changeDescription;
        //        tc.DateTime_Start = changeDateTime_Start;
        //        tc.DateTime_End = changeDateTime_End;
        //        //lc.Password = newPassword;
        //        _context.Update(tc);
        //        _context.SaveChanges();
        //        return "Class changed successfully";
        //    }
        //    else
        //    {
        //        return "Failed to change class ";
        //    }
        //}




        /*public TrainingClass CreateTrainingClass(TrainingClass dto)
        {
            TrainingClass TC = new TrainingClass()
            {
            TrainingClassId = dto.TrainingClassId,
            GymId = dto.GymId,
            TrainerId = dto.TrainerId,
            Maxpeople = dto.MaxPeople,
            Description = dto.Description,
            DateTime Start = dto.DateTime Start,
            DateTime End = dto.DateTime End
            };

            _context.Gyms.Add(TC);
            _context.SaveChanges();

            return TC;*/
    }
}

