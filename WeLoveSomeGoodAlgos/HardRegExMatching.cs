using System;
namespace WeLoveSomeGoodAlgos
{
    /// <summary>
    /// https://leetcode.com/problems/regular-expression-matching/
    ///
    /// Regex evaluation where . means any character and * means 0 or more of
    /// the previous character. This contains an optimal substructure because
    /// the state validity of the next word/pattern letter can be logicallly
    /// inferred from previous states very easily
    ///
    /// Approach:
    /// I first watched a YouTube video on how to solve this to refresh myself
    /// with dynamic programming which I wasn't super great at in the beginning.
    /// I worked it out until it made sense to me on the whiteboard then closed
    /// the video and coded it all from those notes. I ended up not using that
    /// solution because it was too complex and I don't think it covered Leetcode
    /// test cases. I consulted a few other sites but didn't gain much in getting
    /// over my blocks. The naming conventions are really poor on those sites so I
    /// attempted to write a solution that made much more semantic sense.
    /// </summary>
    public class HardRegExMatching
    {
        public static bool RunSolution(string word, string patt)
        {
            if(string.IsNullOrEmpty(word) && string.IsNullOrEmpty(patt))
            {
                return true;
            }

            var state = new bool[word.Length + 1, patt.Length + 1];

            FillEmptyCase(ref state, patt);

            for (int stateWordIdx = 1; stateWordIdx < word.Length + 1; stateWordIdx++)
            {
                for (int statePattIdx = 1; statePattIdx < patt.Length + 1; statePattIdx++)
                {
                    CalculateStateAtIndex(ref state, word, patt, stateWordIdx, statePattIdx);
                }
            }

            return state[word.Length, patt.Length];
        }

        /// <summary>
        /// This evaluates each state of the regex pattern with an empty word
        /// which sets up the base logic we build off of to solve the problem.
        /// The first column is false & the default bool value so we don't need
        /// to worry about it.
        /// </summary>
        /// <param name="state">The state structure used to solve the problem</param>
        /// <param name="patt">The regex pattern we are evaluating</param>
        public static void FillEmptyCase(ref bool[,] state, string patt)
        {
            for(int statePattIdx = 0; statePattIdx < patt.Length + 1; statePattIdx++)
            {
                var pattIdx = statePattIdx > 0 ? statePattIdx - 1 : 0;

                if(statePattIdx == 0)
                {
                    state[0, statePattIdx] = true;
                }
                else if(patt[pattIdx] == '.')
                {
                    state[0, statePattIdx] = true;
                }
                else if (patt[pattIdx] == '*')
                {
                    state[0, statePattIdx] = state[0, statePattIdx - 2];
                }
                else
                {
                    state[0, statePattIdx] = false;
                }
            }
        }

        /// <summary>
        /// The state index is true in 2 cases:
        /// 1. Pattern letter = word letter or . in which case it equals previous
        ///    word/pattern letter state value
        /// 2. Pattern letter = * and current word letter is either valid in the
        ///    zero matches case or it continues the streak if it is a valid match
        /// </summary>
        /// <param name="state">The state structure used to solve the problem</param>
        /// <param name="word">The word to regex match</param>
        /// <param name="patt">The pattern to match the word against</param>
        /// <param name="stateWordIdx">The word-dimension index of the state being calculated</param>
        /// <param name="pattWordIdx">The pattern-dimension index of the state being calculated</param>
        /// <returns></returns>
        public static void CalculateStateAtIndex(ref bool[,] state, string word, string patt, int stateWordIdx, int statePattIdx)
        {
            var wordIdx = stateWordIdx - 1;
            var pattIdx = statePattIdx - 1;

            if (word[wordIdx] == patt[pattIdx] || patt[pattIdx] == '.')
            {
                state[stateWordIdx, statePattIdx] = state[stateWordIdx - 1, statePattIdx - 1];
            }
            else if(patt[pattIdx] == '*')
            {
                bool zeroOkay = state[stateWordIdx, statePattIdx - 1];
                bool extendsStreak = state[stateWordIdx - 1, statePattIdx]
                    && (patt[pattIdx -  1] == '.' || patt[pattIdx - 1] == word[wordIdx]);

                state[stateWordIdx, statePattIdx] = zeroOkay || extendsStreak;
            }
            else
            {
                state[stateWordIdx, statePattIdx] = false;
            }
        }
    }
}
