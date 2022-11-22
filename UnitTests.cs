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

        [Theory]
        [InlineData(1, 2, 1, 2, 5, 4)]
        [InlineData(2, 2, 2, 2, 2, 10)]
        [InlineData(1, 1, 1, 1, 1, 0)]
        public void GivenScoreTwos_WhenFiveDice_ThenGetSumOfTwos(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.ScoreTwos());
        }

        [Theory]
        [InlineData(1, 3, 1, 3, 5, 6)]
        [InlineData(3, 3, 3, 3, 3, 15)]
        [InlineData(1, 1, 1, 1, 1, 0)]
        public void GivenScoreThrees_WhenFiveDice_ThenGetSumOfThrees(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.ScoreThrees());
        }

        [Theory]
        [InlineData(1, 4, 1, 4, 5, 8)]
        [InlineData(4, 4, 4, 4, 4, 20)]
        [InlineData(1, 1, 1, 1, 1, 0)]
        public void GivenScoreFours_WhenFiveDice_ThenGetSumOfFours(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.ScoreFours());
        }

        [Theory]
        [InlineData(1, 5, 1, 5, 5, 15)]
        [InlineData(5, 5, 5, 5, 5, 25)]
        [InlineData(1, 1, 1, 1, 1, 0)]
        public void GivenScoreFives_WhenFiveDice_ThenGetSumOfFives(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.ScoreFives());
        }

        [Theory]
        [InlineData(1, 6, 1, 6, 6, 18)]
        [InlineData(6, 6, 6, 6, 6, 30)]
        [InlineData(1, 1, 1, 1, 1, 0)]
        public void GivenScoreSixes_WhenFiveDice_ThenGetSumOfSixes(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.ScoreSixes());
        }

        [Theory]
        [InlineData(6, 2, 2, 2, 6, 18)]
        [InlineData(2, 3, 4, 5, 6, 0)]
        public void GivenFullHouse_WhenFiveDice_ThenGetSumOfFullHouse(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.FullHouse(d1, d2, d3, d4, d5));
        }

        [Fact]
        public void LargeStraight()
        {
            Assert.Equal(20, Yatzy.LargeStraight(6, 2, 3, 4, 5));
            Assert.Equal(20, Yatzy.LargeStraight(2, 3, 4, 5, 6));
            Assert.Equal(0, Yatzy.LargeStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void OnePair()
        {
            Assert.Equal(6, Yatzy.ScorePair(3, 4, 3, 5, 6));
            Assert.Equal(10, Yatzy.ScorePair(5, 3, 3, 3, 5));
            Assert.Equal(12, Yatzy.ScorePair(5, 3, 6, 6, 5));
        }

        [Fact]
        public void SixesFact()
        {
            Assert.Equal(0, new DiceCalculator(4, 4, 4, 5, 5).ScoreSixes());
            Assert.Equal(6, new DiceCalculator(4, 4, 6, 5, 5).ScoreSixes());
            Assert.Equal(18, new DiceCalculator(4, 6, 6, 6, 5).ScoreSixes());
        }

        [Fact]
        public void SmallStraight()
        {
            Assert.Equal(15, Yatzy.SmallStraight(1, 2, 3, 4, 5));
            Assert.Equal(15, Yatzy.SmallStraight(2, 3, 4, 5, 1));
            Assert.Equal(0, Yatzy.SmallStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void ThreeOfAKind()
        {
            Assert.Equal(9, Yatzy.ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.Equal(15, Yatzy.ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.Equal(9, Yatzy.ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Fact]
        public void TwoPair()
        {
            Assert.Equal(16, Yatzy.TwoPair(3, 3, 5, 4, 5));
            Assert.Equal(16, Yatzy.TwoPair(3, 3, 5, 5, 5));
        }

        [Fact]
        public void Yatzy_scores_50()
        {
            var expected = 50;
            var actual = Yatzy.ScoreYatzy(4, 4, 4, 4, 4);
            Assert.Equal(expected, actual);
            Assert.Equal(50, Yatzy.ScoreYatzy(6, 6, 6, 6, 6));
            Assert.Equal(0, Yatzy.ScoreYatzy(6, 6, 6, 6, 3));
        }
    }
}