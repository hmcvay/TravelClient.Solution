using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelClient
{
  public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews();
      return View(allReviews);
    }

    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    public IActionResult Create()
    {
      ViewBag.DestinationId = new SelectList(Destination.GetDestinations(), "DestinationId", "City");
      return View();
    }

    [HttpPost]
    public IActionResult Create(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }

  }
  
}



