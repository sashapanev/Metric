using System;
using System.Collections.Generic;


namespace MetricGen
{
    public class TestMetric
    {
        public List<string> MainFunc()
        {
            List<string> result = new List<string>();
            List<string> shorCodes = new List<string>();
            Metric someMetric = new Metric();
            string json = someMetric.GetJSON("jobs");
            List<Job> jobs = someMetric.DeserJobsOutput(json);
            foreach (Job job in jobs)
            {
                if ((job.department == "IT") & (job.state == "published"))
                {
                    string res = job.shortcode + " - " + job.title;
                    shorCodes.Add(job.shortcode);
                    //Console.WriteLine(res);
                    result.Add(res);
                }
            }

            string candNames = String.Empty;
            CandidatesCounter CCounter = new CandidatesCounter();
            CCounter.stages = new List<CandidatesCounter.Stage>();
            for(int i = 0; i < 6; i++)
            {
                CandidatesCounter.Stage st = new CandidatesCounter.Stage();
                st.stageName = CCounter.stageNames[i];
                st.candCount = 0;
                CCounter.stages.Add(st);
            }

            foreach (string code in shorCodes)
            {
                string sc = "shortcode=" + code;
                string cands = someMetric.GetJSONwithParams("candidates", sc);
                List<Candidate> cand = someMetric.DeserCandidatesOutput(cands);
                
                foreach(Candidate cd in cand)
                {
                    if (cd.stage == "Applied" & cd.disqualified == false)
                    {
                        CCounter.stages[0].candCount++;
                        candNames = candNames + cd.name + " ";
                    }
                    else if (cd.stage == "Screening" & cd.disqualified == false)
                    {
                        CCounter.stages[1].candCount++;
                        //candNames = candNames + cd.name + " ";
                    }
                    else if (cd.stage == "Tech interview" & cd.disqualified == false)
                    {
                        CCounter.stages[2].candCount++;
                        //candNames = candNames + cd.name + " ";
                    }
                    else if (cd.stage == "Test day" & cd.disqualified == false)
                    {
                        CCounter.stages[3].candCount++;
                       // candNames = candNames + cd.name + " ";
                    }
                    else if (cd.stage == "CEO/CTO" & cd.disqualified == false)
                    {
                        CCounter.stages[3].candCount++;
                       // candNames = candNames + cd.name + " ";
                    }
                    else if (cd.stage == "Offer" & cd.disqualified == false)
                    {
                        CCounter.stages[4].candCount++;
                        //candNames = candNames + cd.name + " ";
                    }
                    else if (cd.stage == "Hired" & cd.disqualified == false)
                    {
                        CCounter.stages[5].candCount++;
                        //candNames = candNames + cd.name + " ";
                    }
                }
            }

            string countRes = String.Empty;
            for(int i = 0; i < 6; i++)
            {
                countRes = countRes + CCounter.stages[i].candCount + " - ";
            }
            result.Add(countRes);
            result.Add(candNames);

            
            return result;
        }

        private void SomeFunc()
        {
            Console.WriteLine("Hi! Now I will collect some data about Candidates for you");
            Metric someMetric = new Metric();
            string json = someMetric.GetJSON("");
            List<Candidate> candidtaes = someMetric.DeserCandidatesOutput(json);
            Console.WriteLine("The Count of Candidates on this stage = " + candidtaes.Count);
        }
    }
}
