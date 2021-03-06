﻿
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Data;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using BeerOverflow.Services.DTO_s;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BeerOverflow.Data.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;


namespace BeerOverflow.Web.Controllers
{

    public class BeersController : Controller
    {
        private readonly IBeerService beerService;
        private readonly IReviewService reviewService;
        private readonly BeerOverflowContext _context;
        private readonly UserManager<User> _userManager;
        private IHostingEnvironment _env;

        public BeersController(BeerOverflowContext context, IBeerService beerService, 
            IReviewService reviewService, UserManager<User> userManager, IHostingEnvironment env)
        {
            _context = context;
            this.beerService = beerService;
            this.reviewService = reviewService;
            this._userManager = userManager;
            _env = env;
        }

        // GET: Beers      
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbvSortParm = sortOrder == "abv" ? "abv_desc" : "abv";
            ViewBag.BeerTypeSortParm = sortOrder == "beertype" ? "beertype_desc" : "beertype";
            ViewBag.CountrySortParm = sortOrder == "country" ? "country_desc" : "country";
            ViewBag.BrewerySortParm = sortOrder == "brewery" ? "brewery_desc" : "brewery";
        
            if (searchString != null)
            {         
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var role = "otherRole";
            if (User.IsInRole("Admin"))
            {
                role = "admin";
            }

            var models = beerService.GetBeers(sortOrder, currentFilter, searchString,role)
                .Select(b => new BeerViewModel(b.Id, b.BeerName, b.AlcByVol, b.Description, 
                b.BeerType, b.BeerTypeId, b.Brewery, b.BreweryId, b.DateUnlisted, b.AvgRating));

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(await models.ToPagedListAsync(pageNumber, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> IndexB(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbvSortParm = sortOrder == "abv" ? "abv_desc" : "abv";
            ViewBag.BeerTypeSortParm = sortOrder == "beertype" ? "beertype_desc" : "beertype";
            ViewBag.CountrySortParm = sortOrder == "country" ? "country_desc" : "country";
            ViewBag.BrewerySortParm = sortOrder == "brewery" ? "brewery_desc" : "brewery";

            var selectedValue = Request.Form["DropDownList"].ToString();

            var getBeers = beerService.GetAllBeers();
            if (searchString != null)
            {
                if(selectedValue == "Name")
                {
                    page = 1;
                    getBeers = getBeers.Where(b => b.BeerName == searchString);         
                }
                if (selectedValue == "Brewery")
                {
                    page = 1;
                    getBeers = getBeers.Where(b => b.Brewery == searchString);
                }
                if (selectedValue == "Style")
                {
                    page = 1;
                    getBeers = getBeers.Where(b => b.BeerType == searchString);
                }
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var role = "otherRole";
            if (User.IsInRole("Admin"))
            {
                role = "admin";
            }

            var models = getBeers
             .Select(b => new BeerViewModel(b.Id, b.BeerName, b.AlcByVol, b.Description,
             b.BeerType, b.BeerTypeId, b.Brewery, b.BreweryId, b.DateUnlisted, b.AvgRating));

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(await models.ToPagedListAsync(pageNumber, pageSize));

        }


        // GET: Beers/Details/5
        //[Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            try
            {
                var beerDTO = await beerService.GetBeerAsync(id);
                var model = new BeerViewModel(beerDTO.Id, beerDTO.BeerName, beerDTO.AlcByVol, beerDTO.Description,
                    beerDTO.BeerType, beerDTO.BeerTypeId, beerDTO.Brewery, beerDTO.BreweryId,
                    beerDTO.Reviews, beerDTO.AvgRating,beerDTO.DateUnlisted);

                var imgPath = beerDTO.ImgPath;
                var absPath = _env.WebRootPath + imgPath;
                if (!System.IO.File.Exists(absPath))
                {
                    imgPath = @"\Images\Beer\PlaceHolder.png";
                }

                ViewBag.Imagepath = imgPath;

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Beers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Type");
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("BeerName,AlcByVol,Description,BeerTypeId,BreweryId")] BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beerDto = new BeerDTO(model.BeerName, model.BeerTypeId, model.BreweryId, (double)model.AlcByVol, model.Description);
                var beer = beerService.CreateBeer(beerDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Type");
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");

            return View(model);
        }

        // GET: Beers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Type");
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View(beer);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BeerName,AlcByVol,Description,DateUnlisted,CountryId,BeerTypeId,BreweryId")] BeerViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO is it possible to be model
                    var beerName = model.BeerName;
                    var alkByVol = model.AlcByVol;
                    var descr = model.Description;
                    var beerTypeId = model.BeerTypeId;
                    var breweryId = model.BreweryId;
                    beerService.UpdateBeer(id, beerName, alkByVol, descr, beerTypeId, breweryId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Type");
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View(model);
        }

        // GET: Beers/Delete/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers
                .Include(b => b.BeerType)
                .Include(b => b.Brewery)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                beerService.DeleteBeer(id);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool BeerExists(int id)
        {
            return _context.Beers.Any(e => e.Id == id);
        }



        [Authorize(Roles = "Admin, User")]
        public IActionResult AddReview(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var beerDTO = beerService.GetBeer(id);
                var model = new BeerReviewViewModel(beerDTO.Id, beerDTO.BeerName, beerDTO.AlcByVol, beerDTO.Description,
                    beerDTO.BeerType, beerDTO.BeerTypeId, beerDTO.Brewery, beerDTO.BreweryId, beerDTO.AvgRating);
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(int id, [Bind("RMessage, Rating, BeerId, UserId")] BeerReviewViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);

                    var newReview = await this.reviewService.AddReview(user.Id, id,
                                model.Rating, model.RMessage);

                    return RedirectToAction("Details", new { id });
                }
                catch (InvalidOperationException)
                {
                    ViewBag.Message = "You have already reviewed this beer!";
                }
            }

            var beerDTO  = await beerService.GetBeerAsync(id);

            var beerModel = new BeerReviewViewModel(beerDTO.Id, beerDTO.BeerName, beerDTO.AlcByVol, beerDTO.Description,
                    beerDTO.BeerType, beerDTO.BeerTypeId, beerDTO.Brewery, beerDTO.BreweryId, beerDTO.AvgRating);

            return  View(beerModel);
        }


    }
}
