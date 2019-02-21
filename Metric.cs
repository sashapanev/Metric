using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

//Newtonsoft
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MetricGen;


public class Metric
{
    private string rootURL = @"https://dodopizza.workable.com/spi/v3/";
    string token = "6d0e8302c977f0bb7f53153c053d3c2b2f15848b8a838ef9b0af76e3e21b3400";
    

    public string GetJSON(string url){
        string json = string.Empty;
        url = rootURL + url;
        //url = @"https://dodopizza.workable.com/spi/v3/jobs?shortcode=346A6F1A1A&stage=offer";
        Console.WriteLine(url);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("Authorization", "Bearer " + token);
        //request.AutomaticDecompression = DecompressionMethods.GZip;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
             json = reader.ReadToEnd();
        }
        return json;
    }

    public string GetJSONwithParams(string url, string param){
      string res = String.Empty;
      url = rootURL + url;
      if (param != String.Empty){
        url = url + "?" + param + "&limit=5000";
      }

      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("Authorization", "Bearer " + token);
        //request.AutomaticDecompression = DecompressionMethods.GZip;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
             res = reader.ReadToEnd();
        }

      return res;
    }

    /*public List<Candidate> DeserCandidatesOutput(string json){
        dynamic res = JsonConvert.DeserializeObject(json);
        List<Candidate> candidatesList = new List<Candidate>();
        
        //Console.WriteLine("My name is " + candidate.Candidates[0].name);
        foreach (dynamic cand in res.candidates){
            Candidate tempCand = new Candidate();
            candidatesList.Add(tempCand);   
        }
       return candidatesList; 
    }*/

    public List<Job> DeserJobsOutput(string json)
    {
        dynamic rootjbs = JsonConvert.DeserializeObject<RootJob>(json);
        Console.WriteLine(rootjbs.jobs[0]);
        return rootjbs.jobs;
    }

    public List<Candidate> DeserCandidatesOutput(string json)
    {
        dynamic rootcnds = JsonConvert.DeserializeObject<RootCandidate>(json);
        //Console.WriteLine(rootcnds.candidates[0]);
        return rootcnds.candidates;
    }
}
    

















    


/*
{
  'candidates': [
    {
      'id': 'ce4da98',
      'name': 'Lakita Marrero',
      'firstname': 'Lakita',
      'lastname': 'Marrero',
      'headline': 'Operations Manager',
      'account': {
        'subdomain': 'groove-tech',
        'name': 'Groove Tech'
      },
      'job': {
        'shortcode': 'GROOV005',
        'title': 'Office Manager'
      },
      'stage': 'Interview',
      'disqualified': true,
      'disqualification_reason': null,
      'sourced': false,
      'profile_url': 'https://groove-tech.workable.com/backend/jobs/376844767/candidates/216323526',
      'email': 'lakita_marrero@gmail.com',
      'domain': 'twitter.com',
      'created_at': '2015-06-26T00:00:00Z',
      'updated_at': '2015-07-08T14:46:48Z'
    },
    {
      'id': '108d1748',
      'name': 'Cindy Sawyers',
      'firstname': 'Cindy',
      'lastname': 'Sawyers',
      'headline': 'Talented Operations Executive',
      'account': {
        'subdomain': 'groove-tech',
        'name': 'Groove Tech'
      },
      'job': {
        'shortcode': 'GROOV005',
        'title': 'Office Manager'
      },
      'stage': 'Applied',
      'disqualified': false,
      'disqualification_reason': null,
      'sourced': false,
      'profile_url': 'https://groove-tech.workable.com/backend/jobs/376844767/candidates/277680758',
      'email': 'cindy_sawyers@gmail.com',
      'domain': 'indeed.com',
      'created_at': '2015-07-08T00:00:00Z',
      'updated_at': '2015-07-08T14:46:48Z'
    }
  ],
  'paging': {
    'next': 'https://www.workable.com/spi/v3/accounts/groove-tech/candidates?limit=3&since_id=2789d6dg'
  }
}


 */