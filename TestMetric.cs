using System;
using System.Collections.Generic;


namespace MetricGen
{
    public class TestMetric
    {
        public List<string> MainFunc()
        {
            List<string> result = new List<string>();
            List<string> shortCodes = new List<string>();
            Metric someMetric = new Metric();
            string json = someMetric.GetJSON("jobs");
            List<Job> jobs = someMetric.DeserJobsOutput(json);
            foreach (Job job in jobs)
            {
                if ((job.department == "IT") & (job.state == "published"))
                {
                    string res = job.shortcode + " - " + job.title;
                    shortCodes.Add(job.shortcode);
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
            int codesLength = shortCodes.Count;
            int n = 0;
            int[] fullCount = new int[6] {0,0,0,0,0,0,};
            foreach (string code in shortCodes)
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

                if(n < codesLength)
                {
                    result[n] = result[n] + " : Applied = " + CCounter.stages[0].candCount + ", Screening = " + CCounter.stages[1].candCount + ", Tech int = " + CCounter.stages[2].candCount + ", Test day/CTO = " + CCounter.stages[3].candCount + ", Offer = " + CCounter.stages[4].candCount + ", Hired = " + CCounter.stages[5].candCount; 
                    n++;
                }
                else n=0;
                
                for(int t = 0; t < fullCount.Length; t++)
                {
                    fullCount[t]+=CCounter.stages[t].candCount;
                    CCounter.stages[t].candCount = 0;
                }
                
            }

            string countRes = String.Empty;
            for(int i = 0; i < fullCount.Length; i++)
            {
                countRes = countRes + CCounter.stages[i].stageName + " -- " + fullCount[i].ToString() + ", ";
            }
            result.Add(countRes);
            //result.Add(candNames);

            
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
