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
            var isTwoOfAKind = false;
            var isThreeOfAKind = false;
            var sum = 0;

            for (int i = 1; i <= 6; i++)
            {
                var countOfDie = GetOccurrenceOfDieNumber(i);

                if (IsTwoOfAKind(countOfDie))
                {
                    isTwoOfAKind = true;
                    sum += (i) * 2;
                }

                if (IsThreeOfAKind(countOfDie))
                {
                    isThreeOfAKind = true;
                    sum += (i) * 3;
                }
            }

            return IsFullHouse(isTwoOfAKind, isThreeOfAKind) ? sum : 0;
        }

        private int GetOccurrenceOfDieNumber(int i)
        {
            return DiceCollection.Count(d => d == i);
        }

        private static bool IsThreeOfAKind(int countOfDie)
        {
            return countOfDie == 3;
        }

        private static bool IsTwoOfAKind(int countOfDie)
        {
            return countOfDie == 2;
        }

        private static bool IsFullHouse(bool isTwoOfAKind, bool isThreeOfAKind)
        {
            return isTwoOfAKind && isThreeOfAKind;
        }

        public int LargeStraight(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies;
            tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;
            if (tallies[1] == 1 &&
                tallies[2] == 1 &&
                tallies[3] == 1 &&
                tallies[4] == 1
                && tallies[5] == 1)
                return 20;
            return 0;
        }

        public int ScorePair(int d1, int d2, int d3, int d4, int d5)
        {
            var counts = new int[6];
            counts[d1 - 1]++;
            counts[d2 - 1]++;
            counts[d3 - 1]++;
            counts[d4 - 1]++;
            counts[d5 - 1]++;
            int at;
            for (at = 0; at != 6; at++)
                if (counts[6 - at - 1] >= 2)
                    return (6 - at) * 2;
            return 0;
        }

        public int TwoPair(int d1, int d2, int d3, int d4, int d5)
        {
            var counts = new int[6];
            counts[d1 - 1]++;
            counts[d2 - 1]++;
            counts[d3 - 1]++;
            counts[d4 - 1]++;
            counts[d5 - 1]++;
            var n = 0;
            var score = 0;
            for (var i = 0; i < 6; i += 1)
                if (counts[6 - i - 1] >= 2)
                {
                    n++;
                    score += 6 - i;
                }

            if (n == 2)
                return score * 2;
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

        public int SmallStraight(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies;
            tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;
            if (tallies[0] == 1 &&
                tallies[1] == 1 &&
                tallies[2] == 1 &&
                tallies[3] == 1 &&
                tallies[4] == 1)
                return 15;
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
