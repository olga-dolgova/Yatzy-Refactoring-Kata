using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzyProject
{
    public class DiceCalculator
    {
        public List<int> DiceCollection { get; set; }
        public DiceCalculator(int dice1, int dice2, int dice3, int dice4, int dice5)
        {
            DiceCollection = new List<int> { dice1, dice2, dice3, dice4, dice5 };
        }

        public int SumOfNumbers(int number)
        {
            return DiceCollection.Where(x => x == number).Sum();
        }

        public int ScoreOnes()
        {
            return SumOfNumbers(1);
        }

        public int ScoreTwos()
        {
            return SumOfNumbers(2);
        }

        public int ScoreThrees()
        {
            return SumOfNumbers(3);
        }

        public int ScoreFours()
        {
            return SumOfNumbers(4);
        }

        public int ScoreFives()
        {
            return SumOfNumbers(5);
        }

        public int ScoreSixes()
        {
            return SumOfNumbers(6);
        }

        public int FullHouse()
        {
            var score = 0;
            var isTwoOfAKind = false;
            var isThreeOfAKind = false;

            var faceValues = new List<int> { 1, 2, 3, 4, 5, 6 };
            foreach (var faceValue in faceValues)
            {
                var countOfFaceValue = GetOccurrenceOfFaceValue(faceValue);

                if (IsOfAKind(countOfFaceValue, 2))
                {
                    isTwoOfAKind = true;
                    score += (faceValue) * 2;
                }

                if (IsOfAKind(countOfFaceValue, 3))
                {
                    score += (faceValue) * 3;
                    isThreeOfAKind = true;
                }
            }
            return IsFullHouse(isTwoOfAKind, isThreeOfAKind) ? score : 0;
        }

        private static bool IsOfAKind( int countOfFaceValue, int faceValue)
        {
            return countOfFaceValue== faceValue;
        }

        private int GetOccurrenceOfFaceValue(int i)
        {
            return DiceCollection.Count(d => d == i);
        }

        private static bool IsFullHouse(bool isTwoOfAKind, bool isThreeOfAKind)
        {
            return isTwoOfAKind && isThreeOfAKind;
        }

        public int LargeStraight()
        {
            var faceValues = new List<int> { 2, 3, 4, 5, 6 };
            foreach (var faceValue in faceValues)
            {
                var countOfFaceValue = GetOccurrenceOfFaceValue(faceValue);
                if (countOfFaceValue != 1) { return 0; }
            }
            return 20;
        }

        public int SmallStraight()
        {
            var faceValues = new List<int> { 1, 2, 3, 4, 5 };
            foreach (var faceValue in faceValues)
            {
                var countOfFaceValue = GetOccurrenceOfFaceValue(faceValue);
                if (countOfFaceValue != 1) { return 0; }
            }
            return 15;
        }

        public int ScoreOnePair()
        {
            return ScorePairs(1);
        }

        public int ScoreTwoPair()
        {
            return ScorePairs(2);
        }

        private int ScorePairs(int numberOfPairs)
        {
            var sum = 0;
            var pairCounter = 0;
            var faceValues = new List<int> { 1, 2, 3, 4, 5, 6 }.OrderByDescending(i => i);
            foreach (var faceValue in faceValues)
            {
                var countOfFaceValue = GetOccurrenceOfFaceValue(faceValue);
                if (countOfFaceValue >= 2)
                {
                    pairCounter++;
                    sum += faceValue * 2;
                }

                if (numberOfPairs == pairCounter)
                {
                    return sum;
                }
            }

            return 0;
        }

        public int ScoreFourOfAKind(int _1, int _2, int d3, int d4, int d5)
        {
            int[] tallies;
            tallies = new int[6];
            tallies[_1 - 1]++;
            tallies[_2 - 1]++;
            tallies[d3 - 1]++;
            tallies[d4 - 1]++;
            tallies[d5 - 1]++;
            for (var i = 0; i < 6; i++)
                if (tallies[i] >= 4)
                    return (i + 1) * 4;
            return 0;
        }

        public int ThreeOfAKind(int d1, int d2, int d3, int d4, int d5)
        {
            int[] t;
            t = new int[6];
            t[d1 - 1]++;
            t[d2 - 1]++;
            t[d3 - 1]++;
            t[d4 - 1]++;
            t[d5 - 1]++;
            for (var i = 0; i < 6; i++)
                if (t[i] >= 3)
                    return (i + 1) * 3;
            return 0;
        }

        public int ScoreYatzy(params int[] dice)
        {
            var counts = new int[6];
            foreach (var die in dice)
                counts[die - 1]++;
            for (var i = 0; i != 6; i++)
                if (counts[i] == 5)
                    return 50;
            return 0;
        }

        public int ScoreChance()
        {
            return DiceCollection.Sum();
        }
    }
}
