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

    // [JsonIgnore]
    public virtual Destination Destination { get; set; }

    public static List<Review> GetReviews()
    {
      var apiCallTask = ApiHelper.GetAllReviews();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

      return reviewList;
    } 
  }
}