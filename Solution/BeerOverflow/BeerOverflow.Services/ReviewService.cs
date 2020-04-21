﻿using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class ReviewService : IReviewService
    {
        private readonly BeerOverflowContext _beerOverflowContext;
        public ReviewService(BeerOverflowContext beerOverflowContext)
        {
            this._beerOverflowContext = beerOverflowContext;
        }

        public ReviewDTO AddReview(string userName, string beerName, int rating, string rMessage)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.Username == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }
            var beer = _beerOverflowContext.Beers
                .Where(b => b.DateUnlisted == null)
                .FirstOrDefault(b => b.BeerName == beerName);

            if (beer == null)
            {
                throw new ArgumentNullException("Beer is null!");
            }


            if(rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException("Rating is out of range!");
            }


            var userReview = new Review
            {
                UserId = user.Id,
                BeerId = beer.Id,
                Rating = rating,
                RMessage = rMessage,
                ReviewedOn = DateTime.UtcNow               
            };
            try
            {
                _beerOverflowContext.Reviews.Add(userReview);
                _beerOverflowContext.SaveChanges();
            }
            catch(Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }
            var userReviewDTO = new ReviewDTO
            {
                UserId = userReview.UserId,
                BeerId = userReview.BeerId,
                User = userReview.User.Username,
                Beer = userReview.Beer.BeerName,
                Rating = userReview.Rating,
                RMessage = userReview.RMessage,
                ReviewedOn = userReview.ReviewedOn
            };

            return userReviewDTO;
        }
    }
}