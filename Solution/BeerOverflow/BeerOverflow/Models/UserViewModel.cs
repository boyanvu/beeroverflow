﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }
        public UserViewModel(int id, string username, string firstName, string lastName, string email)
        {
            this.Id = id;
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public UserViewModel(int id, string username, string firstName, string lastName, string email, DateTime createdOn)
        {
            this.Id = id;
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.CreatedOn = createdOn;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }


    }
}
