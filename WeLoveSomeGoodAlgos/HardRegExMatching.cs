using System;
namespace WeLoveSomeGoodAlgos
{
    /// <summary>
    /// https://leetcode.com/problems/regular-expression-matching/
    /// </summary>
    public class HardRegExMatching
    {
        private const int WORD_DIM = 0;
        private const int PATT_DIM = 1;

        public static bool RunSolution(string word, string patt)
        {
            if(string.IsNullOrEmpty(word) && string.IsNullOrEmpty(patt))
            {
                return true;
            }

            var state = new bool[word.Length + 1, patt.Length + 1];

            var hasAnyWildCardStart = patt.Length >= 2 && patt[0] == '.' && patt[1] == '*';

            FillEmptyCase(ref state, hasAnyWildCardStart);

            return CalculateStateAndSolution(ref state, word, patt);
        }

        /// <summary>
        /// Will set empty word/pattern case with true and false for everything else
        /// unless the pattern begins with .* in which case empty will satisfy the
        /// regex pattern, any other pattern characters will fail on empty word though
        /// </summary>
        /// <param name="state">The state structure used to solve the problem</param>
        /// <param name="hasAnyWildCardStart">If the first two pattern characters are .*</param>
        public static void FillEmptyCase(ref bool[,] state, bool hasAnyWildCardStart)
        {
            for(int wordIdx = 0; wordIdx < state.GetLength(WORD_DIM); wordIdx++)
            {
                for(int pattIdx = 0; pattIdx < state.GetLength(PATT_DIM); pattIdx++)
                {
                    if(wordIdx == 0 && pattIdx == 0)
                    {
                        state[wordIdx, pattIdx] = true;
                    }
                    else if(hasAnyWildCardStart && wordIdx == 0 && pattIdx < 3)
                    {
                        state[wordIdx, pattIdx] = true;
                    }
                    else
                    {
                        state[wordIdx, pattIdx] = false;
                    }
                }
            }
        }

        /// <summary>
        /// Goes through array traversing by word then pattern with 3 cases:
        /// 1. They match, in which case it's true
        /// 2. Pattern is wildcard, which means if match has been good until
        ///    this condition, we can do 0 case and true. Otherwise if the letter
        ///    matches the wildcard's matcher, just see if we've been successful
        ///    up until that point. If not false.
        /// 3. It is neither and false
        /// </summary>
        /// <param name="state">The state structure used to solve the problem</param>
        /// <param name="word">The word to regex match</param>
        /// <param name="patt">The pattern to match the word against</param>
        /// <returns></returns>
        public static bool CalculateStateAndSolution(ref bool[,] state, string word, string patt)
        {
            for(int wordIdx = 1; wordIdx < state.GetLength(WORD_DIM); wordIdx++)
            {
                for (int pattIdx = 1; pattIdx < state.GetLength(PATT_DIM); pattIdx++)
                {
                    if (word[wordIdx - 1] == patt[pattIdx - 1]) //TODO think of naming convention for this to be more clear
                    {
                        state[wordIdx, pattIdx] = state[wordIdx - 1, pattIdx - 1];
                    }
                    else if(patt[pattIdx - 1] == '*')
                    {
                        CalculateWildCardSituation(ref state, wordIdx, pattIdx);
                    }
                    else
                    {
                        state[wordIdx, pattIdx] = false;
                    }
                }
            }

            return state[word.Length, patt.Length];
        }

        public static void CalculateWildCardSituation(ref bool[,] state, int wordIdx, int pattIdx)
        {
            if(state[wordIdx - 2, pattIdx]) 
            {
                state[wordIdx, pattIdx] = true;
            }
            else if(state[wordIdx - 1, pattIdx])
            {
                state[wordIdx, pattIdx] = state[wordIdx - 1, pattIdx - 1];
            }
            else
            {
                state[wordIdx, pattIdx] = false;
            }
        }
    }
}
