//Question Name
//415. Minimum Changes to Make Two Strings Anagram
//Question Resources
//Question Description
//Given two strings str1 and str2, find the minimum number of changes necessary to make str1 and str2 anagram without deleting any characters.



//Anagram means that the string have the same set of characters, the order does not matter.

//Example:

//Input:
//str1 = "aba"
//str2 = "bab"
//Output: 1
//Explanation: The 'b' in str2 can be changed to 'a'. This then results in "aab" which is an anagram of "aba".



//Example:

//Input:
//str1 = "aba"
//str2 = "baa"
//Output: 0
//Explanation: Both strings are already anagrams of each other.



//Requirement: You need to come up with an algorithm with O(N) time complexity to get full mark.



//Please use the below method signature to complete this question:

//int findMinimumChanges(String str1, String str2)

namespace BFWK2Mock
{
    public class findMinChanges
    {
        public static int findMinimumChanges(String str1, String str2) { 
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int result = str2.Length;

            foreach(var item in str1)
                dict[item] = dict.ContainsKey(item) ? ++dict[item] : 1;
            foreach(var item in str2)
                if(dict.ContainsKey(item)&& dict[item] != 0)
                {
                    dict[item]-=1;
                    result--;
                }
            return result;
        }
        public static void Main(string[] args)
        {
            //string str1 = "aba";
            //string str2 = "bab";

            string str1 = "aba";
            string str2 = "baa";
            Console.WriteLine(findMinimumChanges(str1,str2));
        }
    }
}