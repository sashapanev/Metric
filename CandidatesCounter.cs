using System;
using System.Collections.Generic;

namespace MetricGen
{
    public class CandidatesCounter
    {
        public class Stage
        {
            public string stageName;
            public int candCount = 0;
        }
        
        public string shortcode;
        public string name;
        public List<Stage> stages;
        public string[] stageNames = new string[] {"Applied","Screening","Tech interview","Test-drive/CTO","Offer","Hired"};


    }
}