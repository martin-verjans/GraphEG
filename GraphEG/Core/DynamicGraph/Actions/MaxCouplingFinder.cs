using GraphEG.Core.Graph;
using GraphEG.Core.StaticGraph;
using System.Collections.Generic;
using System.Linq;

namespace GraphEG.Core.DynamicGraph.Actions
{
    public class MaxCouplingFinder
    {
        //Found this algo on https://www.geeksforgeeks.org/dsa/maximum-bipartite-matching/
        // M is number of applicants 
        // and N is number of jobs
        private readonly int PlayerCount; //M
        private readonly int RoleCount; //N
        private bool[,] bGraph;

        public MaxCouplingFinder(IPlayer[] players, Role[] roles, IEnumerable<IEdge<INode>> edges)
        {
            PlayerCount = players.Count();
            RoleCount = roles.Count();

            bGraph = new bool[PlayerCount, RoleCount];

            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < roles.Length; j++)
                {
                    bGraph[i, j] = edges.Any(edge => edge.Origin.Equals(players[i]) && edge.Destination.Equals(roles[j]));
                }
            }

        }

        // A DFS based recursive function 
        // that returns true if a matching 
        // for vertex u is possible
        private bool bpm(bool[,] bpGraph, int u,
                 bool[] seen, int[] matchR)
        {
            // Try every job one by one
            for (int v = 0; v < RoleCount; v++)
            {
                // If applicant u is interested 
                // in job v and v is not visited
                if (bpGraph[u, v] && !seen[v])
                {
                    // Mark v as visited
                    seen[v] = true;

                    // If job 'v' is not assigned to
                    // an applicant OR previously assigned 
                    // applicant for job v (which is matchR[v])
                    // has an alternate job available.
                    // Since v is marked as visited in the above 
                    // line, matchR[v] in the following recursive 
                    // call will not get job 'v' again
                    if (matchR[v] < 0 || bpm(bpGraph, matchR[v],
                                             seen, matchR))
                    {
                        matchR[v] = u;
                        return true;
                    }
                }
            }
            return false;
        }

        // Returns maximum number of 
        // matching from M to N
        private int maxBPM()
        {
            // An array to keep track of the 
            // applicants assigned to jobs. 
            // The value of matchR[i] is the 
            // applicant number assigned to job i, 
            // the value -1 indicates nobody is assigned.
            int[] matchR = new int[RoleCount];

            // Initially all jobs are available
            for (int i = 0; i < RoleCount; ++i)
                matchR[i] = -1;

            // Count of jobs assigned to applicants
            int result = 0;
            for (int u = 0; u < PlayerCount; u++)
            {
                // Mark all jobs as not
                // seen for next applicant.
                bool[] seen = new bool[RoleCount];
                for (int i = 0; i < RoleCount; ++i)
                    seen[i] = false;

                // Find if the applicant 
                // 'u' can get a job
                if (bpm(bGraph, u, seen, matchR))
                    result++;
            }
            return result;
        }

        // Driver Code
        public int FindMaxCoupling()
        {
            int maxCoupling = maxBPM();
            return maxCoupling;
        }
    }
}
