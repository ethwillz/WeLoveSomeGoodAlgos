using System;

namespace WeLoveSomeGoodAlgos
{
    public static class EasyFibonnaci
    {
        /// <summary>
        /// https://www.codechef.com/problems/FIBEASY
        /// 
        /// Let D = (D0,D1,…,Dl) = fibonacci sequence until index l
        /// Create a new sequence E = (D1,D3,…,D2⌊l/2⌋) until only 1 element left
        /// This function calculates that number mod 10 where each caseNum correlates to l
        ///
        /// My original idea:
        /// 1. Calculate how many times E will be calculated before 1 number left (log base 2 of l, pretty easy)
        /// 2. Go through the fibonnaci sequence back to front, calculate if it makes it to the round or not
        /// 3. For some reason I thought this would be a list cause I didn't get the answer space so I also had a cache lmao
        ///
        /// Final approach:
        /// Realized there are groupings of l's that that all have same answer and these groupings increase exponentially
        /// wrt to number of members. So if we take the log of the fence we're interested in (+1 can't do 0) then that tells
        /// us which group number, and the group's answer's index is 1 less than 2 ^ group number
        /// <param name="fence">Last index in D aka l from above</param>
        /// <returns>Last remaining fibonacci element mod 10 after calculation of E</returns>
        /// </summary>
        public static int RunSolutionForFence(int fence)
        {
            var answerIndex = GetAnswerGroupStartIndex(fence);

            return GetFibNum(answerIndex) % 10;
        }

        // Gets index of answer group's start aka the index of the fibonacci number
        public static int GetAnswerGroupStartIndex(int fence)
        {
            var expGroupNum = (int)Math.Floor(Math.Log2(fence + 1));

            return (int)Math.Pow(2, expGroupNum) - 1;
        }

        // Closed form calculation of fibonacci number at index
        public static int GetFibNum(int index)
        {
            var phi = (1 + Math.Sqrt(5d)) / 2;

            return (int)((Math.Pow(phi, index) - Math.Pow(-phi, -index)) / Math.Sqrt(5));
        }
    }
}
