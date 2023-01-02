// See https://aka.ms/new-console-template for more information
int[] scores = { 60, 88, 90, 100, 75, 82, 96 };
IEnumerable<int> scoreQuerySyntax = from score in scores
                                    where score > 80
                                    select score;

IEnumerable<int> scoreMethodSyntax = scores.Where(score => score > 80);

//foreach (int score in scoreMethodSyntax)
//{
//    Console.WriteLine(score);
//}

List<string> nameList = new List<string>() { "Lily", "Alan", "Vivian", "David" };
//Select
var selectExample = nameList.Select(name => name);

//Select Many
var selectManyExample = nameList.SelectMany(name => name);

Console.WriteLine("Select Result: ");
foreach (var name in selectExample)
{
    Console.Write(name + " ");
}
Console.WriteLine();

