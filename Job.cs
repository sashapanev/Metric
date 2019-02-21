using System;
using System.Collections.Generic;

namespace MetricGen
{
    public class Location
{
    public string country { get; set; }
    public string country_code { get; set; }
    public string region { get; set; }
    public string region_code { get; set; }
    public string city { get; set; }
    public object zip_code { get; set; }
    public bool telecommuting { get; set; }
}

public class Job
{
    public string id { get; set; }
    public string title { get; set; }
    public string full_title { get; set; }
    public string shortcode { get; set; }
    public object code { get; set; }
    public string state { get; set; }
    public string department { get; set; }
    public string url { get; set; }
    public string application_url { get; set; }
    public string shortlink { get; set; }
    public Location location { get; set; }
    public DateTime created_at { get; set; }
}

public class RootJob
{
    public List<Job> jobs { get; set; }
}

}