//51.Best Average Score
//Question Resources
//Question Description
//Given a 2-D String array of student-marks find the student with the highest average and output his average score. If the average is in decimals, floor it down to the nearest integer.
 
 
 
 
//Example 1:
 
//Input: { { "Bobby", "87"}, { "Charles", "100"}, { "Eric", "64"}, { "Charles", "81"} }
//Output: 90
//Explanation: Since Charles' average score is 90, which is higher than others



//Please use the method signature below to complete this question:
 
//public static int bestAverageGrade(String[][] scores)
//{
//    // your code here...
//}
//Follow - up:
//Questions: What is the time complexity? What is the space complexity? Can you solve it in O(n)  time ? (I used an integer array to store the average and sorted it using Arrays.sort().But then, I refined my code to store only the maximum average, when I calculated the average score).
 
//Follow up test cases:
//Test case 2: each person can have more than 1 grade
//Test case 3: grades can be zero or negative numbers
//Test case 4: it is possible that the average cannot be fully divided. In that case, you should consider the floor of the calculated average score



namespace BestAverageGrade
{
    public class Program
    {
        public static int bestAverageGrade(String[][] scores)
        {
            // Create a dictionary to store the students and their marks
            Dictionary<string, List<int>> studentsMarks = new Dictionary<string, List<int>>();

            // Iterate through each student and their marks
            for (int i = 0; i < scores.Length; i++)
            {
                // Get the student's name and mark
                string student = scores[i][0];
                int mark = int.Parse(scores[i][1]);

                // If we haven't seen this student before, add them to the dictionary
                if (!studentsMarks.ContainsKey(student))
                {
                    studentsMarks[student] = new List<int>();
                }

                // Add the mark to the student's list of marks
                studentsMarks[student].Add(mark);
            }

            // Find the student with the highest average score
            int highestAverage = FindHighestAverage(studentsMarks);

            return highestAverage;
        }

        // A helper function to find the student with the highest average score
        static int FindHighestAverage(Dictionary<string, List<int>> studentsMarks)
        {
            int highestAverage = 0;

            // Iterate through each student and their marks
            foreach (KeyValuePair<string, List<int>> studentMarks in studentsMarks)
            {
                // Calculate the average for this student
                int average = (int)Math.Floor(studentMarks.Value.Average());

                // If this average is higher than the current highest, update the highest average
                if (average > highestAverage)
                {
                    highestAverage = average;
                }
            }

            return highestAverage;
        }

        static void Main(string[] args)
        {
            // Test case 1: each person has only 1 grade
            String[][] scores1 = {
        new String[] { "Bobby", "87" },
        new String[] { "Charles", "100" },
        new String[] { "Eric", "64" },
        new String[] { "Charles", "81" }
    };

            int highestAverage1 = bestAverageGrade(scores1);
            Console.WriteLine($"Test case 1: The student with the highest average score has an average of {highestAverage1}.");

            // Test case 2: each person can have more than 1 grade
            String[][] scores2 = {
        new String[] { "Bobby", "87" },
        new String[] { "Charles", "100" },
        new String[] { "Eric", "64" },
        new String[] { "Charles", "81" },
        new String[] { "Bobby", "70" },
        new String[] { "Eric", "85" }
    };

            int highestAverage2 = bestAverageGrade(scores2);
            Console.WriteLine($"Test case 2: The student with the highest average score has an average of {highestAverage2}.");

            // Test case 3: grades can be zero or negative numbers
            String[][] scores3 = {
        new String[] { "Bobby", "-5" },
        new String[] { "Charles", "100" },
        new String[] { "Eric", "64" },
        new String[] { "Charles", "81" },
        new String[] { "Bobby", "70" },
        new String[] { "Eric", "85" },
        new String[] { "Charles", "0" }
    };

            int highestAverage3 = bestAverageGrade(scores3);
            Console.WriteLine($"Test case 3: The student with the highest average score has an average of {highestAverage3}.");

            // Test case 4: it is possible that the average cannot be fully divided. In that case, you should consider the floor of the calculated average score
            String[][] scores4 = {
        new String[] { "Bobby", "87" },
        new String[] { "Charles", "100" },
        new String[] { "Eric", "64" },
        new String[] { "Charles", "81" },
        new String[] { "Bobby", "70" },
        new String[] { "Eric", "85" },
        new String[] { "Charles", "81" },
        new String[] { "Bobby", "70" },
        new String[] { "Eric", "85" }
    };

            int highestAverage4 = bestAverageGrade(scores4);
            Console.WriteLine($"Test case 4: The student with the highest average score has an average of {highestAverage4}.");
        }

    }
}

//The time complexity of the function I provided is O(n)
//    The space complexity is also O(n)