public class Math
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Max(int a, int b)
    {
        return (a > b) ? a : b;
    }

    public IEnumerable<int> GetOddNumbers(int limit)
    {
        for (var i = 0; i <= limit; i++)
            if (i % 2 != 0)
                yield return i;
    }

    [Fact]
    public void AddTest()
    {
        var math=new Math();
        int a = 1;
        int b = 2;
        int expectedSum = 3;
        int actualSum = math.Add(a, b);
        Assert.Equal(expectedSum, actualSum);
    }

    [Fact]
    public void MaxTest()
    {
        var math = new Math();
        int a = 1;
        int b = 2;
        int expectedMax = 2;
        var actualMax = math.Max(a, b);
        Assert.Equal(expectedMax, actualMax);
    }

    [Theory]
    [InlineData(0, new int[] {})]
    [InlineData(0, new int[] {1,3,5 })]
    [InlineData(0, new int[] {1,3,5,7 })]
    public void GetOddNumbersTest(int limit, int expectedOddNumber)
    {
        var math = new Math();
        IEnumerable<int> actualOddNumber = math.GetOddNumbers(limit);
        Assert.Equal(expectedOddNumber, actualOddNumber);
    }
}