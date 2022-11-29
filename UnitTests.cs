namespace TestProject
{
    using NuGet.Frameworks;
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
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.ScoreChance());
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
        [InlineData(2, 2, 2, 2, 2, 0)]
        public void GivenFullHouse_WhenFiveDice_ThenGetSumOfFullHouse(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.FullHouse());
        }

        [Theory]
        [InlineData(6, 2, 3, 4, 5, 20)]
        [InlineData(2, 3, 4, 5, 6, 20)]
        [InlineData(1, 2, 2, 4, 5, 0)]
        [InlineData(1, 2, 3, 4, 5, 0)]
        public void GivenLargeStraight_WhenFiveDice_ThenScoreTwentyIfLargeStraight(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            var diceCalculator = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, diceCalculator.LargeStraight());
        }

        [Theory]
        [InlineData(3, 4, 3, 5, 6, 6)]
        [InlineData(5, 3, 3, 3, 5, 10)]
        [InlineData(5, 3, 6, 6, 5, 12)]
        public void OnePair(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            DiceCalculator dc = new DiceCalculator(d1, d2, d3, d4, d5);
            Assert.Equal(expected, dc.ScoreOnePair());
        }

        [Theory]
        [InlineData(4, 4, 4, 5, 5, 0)]
        [InlineData(4, 4, 6, 5, 5, 6)]
        [InlineData(4, 6, 6, 6, 5, 18)]
        public void SixesFact(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, new DiceCalculator(d1, d2, d3, d4, d5).ScoreSixes());
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5, 15)]
        [InlineData(2, 3, 4, 5, 1, 15)]
        [InlineData(1, 2, 2, 4, 5, 0)]
        [InlineData(2, 3, 4, 5, 6, 0)]
        public void SmallStraight(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, new DiceCalculator(d1, d2, d3, d4, d5).SmallStraight());
        }

        [Theory]
        [InlineData(4, 4, 4, 4, 5, 12)]
        [InlineData(4, 4, 5, 5, 5, 15)]
        [InlineData(1, 1, 6, 6, 5, 0)]
        public void ThreeOfAKind(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, new DiceCalculator(d1, d2, d3, d4, d5).ScoreThreeOfAKind());
        }

        [Theory]
        [InlineData(4, 4, 4, 4, 5, 16)]
        [InlineData(4, 4, 5, 5, 5, 0)]
        [InlineData(1, 1, 1, 1, 5, 4)]
        public void GivenFourOfAKind_WhenFiveDice_ThenGetFourTimesFaceValue(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, new DiceCalculator(d1, d2, d3, d4, d5).ScoreFourOfAKind());
        }


        [Theory]
        [InlineData(4, 4, 4, 5, 5, 18)]
        [InlineData(2, 2, 6, 1, 1, 6)]
        [InlineData(4, 6, 6, 6, 5, 0)]
        public void TwoPair(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, new DiceCalculator(d1, d2, d3, d4, d5).ScoreTwoPair());

        }

        [Theory]
        [InlineData(4, 4, 4, 5, 5, 0)]
        [InlineData(4, 4, 4, 4, 4, 50)]
        [InlineData(1, 1, 1, 1, 1, 50)]
        public void Yatzy_scores_50(int d1, int d2, int d3, int d4, int d5, int expected)
        {
            Assert.Equal(expected, new DiceCalculator(d1, d2, d3, d4, d5).ScoreYatzy(d1, d2, d3, d4, d5));
        }
    }
}