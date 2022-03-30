using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Body { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }
    public int DestinationId { get; set; }
    public Destination Destination { get; set; }

    public static List<Review> GetReviews()
    {
      var apiCallTask = ApiHelper.GetAllReviews();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

      return reviewList;
    } 

    public static Review GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetReview(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Review review = JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

      return review;
    }

    public static void Post(Review review)
    {
      string jsonReview = JsonConvert.SerializeObject(review);
      var apiCallTask = ApiHelper.PostReview(jsonReview);
    }
  }
}