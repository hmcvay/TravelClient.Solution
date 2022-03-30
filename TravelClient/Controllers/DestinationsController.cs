using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelClient.Models;

namespace TravelClient
{
  public class DestinationsController : Controller
  {
    public IActionResult Index()
    {
      var allDestinations = Destination.GetDestinations();
      return View(allDestinations);
    }

    public IActionResult Details(int id)
    {
      var destination = Destination.GetDetails(id);
      return View(destination);
    }
  }
  
}



