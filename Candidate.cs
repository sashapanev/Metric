using System;
using System.Collections.Generic;

namespace MetricGen
{
        public class Account
        {
            public string subdomain { get; set; }
            public string name { get; set; }
        }

        public class JobC
        {
            public string shortcode { get; set; }
            public string title { get; set; }
        }

        public class Candidate
        {
            public string id { get; set; }
            public string name { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string headline { get; set; }
            public Account account { get; set; }
            public JobC job { get; set; }
            public string stage { get; set; }
            public bool disqualified { get; set; }
            public object disqualification_reason { get; set; }
            public bool sourced { get; set; }
            public string profile_url { get; set; }
            public string email { get; set; }
            public string domain { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
}

public class RootCandidate
{
    public List<Candidate> candidates { get; set; }
}

}