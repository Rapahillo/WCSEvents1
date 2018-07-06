using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCSEvents1
{
    [JsonObject]
    public class Dancer
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int wscid { get; set; }
    }

    public class Division
    {
        public int id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
    }

    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string url { get; set; }
        public string date { get; set; }
    }

    public class Competition
    {
        public string role { get; set; }
        public int points { get; set; }
        public Event @event { get; set; }
        public string result { get; set; }
    }

    public class WestCoastSwing
    {
        public Division division { get; set; }
        public int total_points { get; set; }
        public List<Competition> competitions { get; set; }
    }

    public class Placements
    {
        public List<WestCoastSwing> West_Coast_Swing { get; set; }
    }

    public class WsdcDatabaseDancer
    {
        public string type { get; set; }
        public Dancer dancer { get; set; }
        public Placements placements { get; set; }
    }
    //public class WsdcDatabaseDancer
    //{
    //    public string type { get; set; }
    //    public Dancer dancer { get; set; }
    //    public Placements placements { get; set; }
    //}

    //public class Dancer
    //{
    //    public int id { get; set; }
    //    public string first_name { get; set; }
    //    public string last_name { get; set; }
    //    public int wscid { get; set; }
    //}

    //public class Placements
    //{
    //    public WestCoastSwing[] WestCoastSwing { get; set; }
    //}

    //public class WestCoastSwing
    //{
    //    public Division division { get; set; }
    //    public int total_points { get; set; }
    //    public Competition[] competitions { get; set; }
    //}

    //public class Division
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string abbreviation { get; set; }
    //}

    //public class Competition
    //{
    //    public string role { get; set; }
    //    public int points { get; set; }
    //    public Event _event { get; set; }
    //    public string result { get; set; }
    //}

    //public class Event
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string location { get; set; }
    //    public string url { get; set; }
    //    public string date { get; set; }
    //}

}

