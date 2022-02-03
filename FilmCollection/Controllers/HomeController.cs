using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
       
        private FilmCollectionContext filmContext { get; set; }

        public HomeController(FilmCollectionContext filmObject)
        {
           
            filmContext = filmObject;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.categories = filmContext.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(FilmCollectionResponse fcr)   //add a movie to the collection
        {
            if (ModelState.IsValid)
            {
                filmContext.Add(fcr);
                filmContext.SaveChanges();
                //return View("Confirmation", ar);
                return RedirectToAction("ViewCollection");
            }
            else
            {
                ViewBag.categories = filmContext.categories.ToList();
                return View(fcr);
            }

        }

        
        [HttpGet]
        public IActionResult ViewCollection()   //view the collection of movies in a table
        {
            var movies = filmContext.Movies
                .Include(x => x.Categories)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)   //edit a movie in the collection
        {
            ViewBag.categories = filmContext.categories.ToList();
            var movie = filmContext.Movies.Single(x => x.MovieID == movieid);
            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(FilmCollectionResponse updates)
        {
            filmContext.Update(updates);
            filmContext.SaveChanges();
            return RedirectToAction("ViewCollection");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)            //delete a movie from the collection
        { 
            var movie = filmContext.Movies.Single(x => x.MovieID == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(FilmCollectionResponse delete)
        {
            filmContext.Movies.Remove(delete);
            filmContext.SaveChanges();
            return RedirectToAction("ViewCollection");
        }

    }
}
