namespace TestProject
{
    using NuGet.Frameworks;
    using Yatzy;
    using YatzyProject;

    public class YatzyTest
    {

        public YatzyTest()
        {

        }
        [Theory]
        [InlineData(2, 3, 4, 5, 1, 15)]
        [InlineData(3, 3, 4, 5, 1, 16)]
        public void GivenScoreChance_WhenFiveDice_ThenGetSum(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, Yatzy.ScoreChance(d1, d2, d3, d4, d5));
        }

        [Theory]
        [InlineData(1, 4, 1, 5, 5, 2)]
        [InlineData(4, 4, 4, 5, 5, 0)]
        [InlineData(1, 1, 1, 1, 1, 5)]
        public void GivenScoreOnes_WhenFiveDice_ThenGetSumOfOnes(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.ScoreOnes());
        }

        //[Fact]
        //public void CheckTwos()
        //{
        //    Assert.Equal(4, new Yatzy(new List<Die> { new(1), new(2), new(1), new(2), new(5) }).ScoreTwos()); 
        //    Assert.Equal(10, new Yatzy(new List<Die> { new(2), new(2), new(2), new(2), new(2) }).ScoreTwos());
        //}

        //[Fact]
        //public void CheckThrees()
        //{
        //    Assert.Equal(6, Yatzy.ScoreThrees(1, 2, 3, 2, 3));
        //    Assert.Equal(12, Yatzy.ScoreThrees(2, 3, 3, 3, 3));
        //}

        //[Fact]
        //public void CheckFives()
        //{
        //    Assert.Equal(10, new Yatzy(new List<Die> { new (4), new (4), new (4), new (5), new(5) }).Fives());
        //    Assert.Equal(20, new Yatzy(new List<Die> { new(4), new(5), new(5), new(5), new(5) }).Fives());
        //}

        //[Fact]
        //public void CheckFourOfAKind()
        //{
        //    Assert.Equal(12, Yatzy.ScoreFourOfAKind(3, 3, 3, 3, 5));
        //    Assert.Equal(20, Yatzy.ScoreFourOfAKind(5, 5, 5, 4, 5));
        //    Assert.Equal(12, Yatzy.ScoreFourOfAKind(3, 3, 3, 3, 3));
        //}

        //[Fact]
        //public void CheckFours()
        //{
        //    Assert.Equal(8, new Yatzy(new List<Die> { new(4), new(4), new(5), new(5), new(5) }).Fours());
        //    Assert.Equal(12, new Yatzy(new List<Die> { new(4), new(4), new(4), new(5), new(5) }).Fours());
        //    Assert.Equal(4, new Yatzy(new List<Die> { new(4), new(5), new(5), new(5), new(5) }).Fours());
        //}

        //[Fact]
        //public void fullHouse()
        //{
        //    Assert.Equal(18, Yatzy.FullHouse(6, 2, 2, 2, 6));
        //    Assert.Equal(0, Yatzy.FullHouse(2, 3, 4, 5, 6));
        //}

        //[Fact]
        //public void largeStraight()
        //{
        //    Assert.Equal(20, Yatzy.LargeStraight(6, 2, 3, 4, 5));
        //    Assert.Equal(20, Yatzy.LargeStraight(2, 3, 4, 5, 6));
        //    Assert.Equal(0, Yatzy.LargeStraight(1, 2, 2, 4, 5));
        //}

        //[Fact]
        //public void one_pair()
        //{
        //    Assert.Equal(6, Yatzy.ScorePair(3, 4, 3, 5, 6));
        //    Assert.Equal(10, Yatzy.ScorePair(5, 3, 3, 3, 5));
        //    Assert.Equal(12, Yatzy.ScorePair(5, 3, 6, 6, 5));
        //}

        //[Fact]
        //public void sixes_Fact()
        //{
        //    Assert.Equal(0, new Yatzy(new List<Die> { new(4), new(4), new(4), new(5), new(5) }).sixes());
        //    Assert.Equal(6, new Yatzy(new List<Die> { new(4), new(4), new(6), new(5), new(5) }).sixes());
        //    Assert.Equal(18, new Yatzy(new List<Die> { new(4), new(6), new(6), new(6), new(5) }).sixes());
        //}

        //[Fact]
        //public void smallStraight()
        //{
        //    Assert.Equal(15, Yatzy.SmallStraight(1, 2, 3, 4, 5));
        //    Assert.Equal(15, Yatzy.SmallStraight(2, 3, 4, 5, 1));
        //    Assert.Equal(0, Yatzy.SmallStraight(1, 2, 2, 4, 5));
        //}

        //[Fact]
        //public void three_of_a_kind()
        //{
        //    Assert.Equal(9, Yatzy.ThreeOfAKind(3, 3, 3, 4, 5));
        //    Assert.Equal(15, Yatzy.ThreeOfAKind(5, 3, 5, 4, 5));
        //    Assert.Equal(9, Yatzy.ThreeOfAKind(3, 3, 3, 3, 5));
        //}

        //[Fact]
        //public void two_Pair()
        //{
        //    Assert.Equal(16, Yatzy.TwoPair(3, 3, 5, 4, 5));
        //    Assert.Equal(16, Yatzy.TwoPair(3, 3, 5, 5, 5));
        //}

        //[Fact]
        //public void Yatzy_scores_50()
        //{
        //    var expected = 50;
        //    var actual = Yatzy.ScoreYatzy(4, 4, 4, 4, 4);
        //    Assert.Equal(expected, actual);
        //    Assert.Equal(50, Yatzy.ScoreYatzy(6, 6, 6, 6, 6));
        //    Assert.Equal(0, Yatzy.ScoreYatzy(6, 6, 6, 6, 3));
        //}
    }
}