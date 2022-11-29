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
            var grouped = DiceCollection.GroupBy(x => x);
            var sumOfTwos = 0;
            var sumOfThrees = 0;

            foreach (var item in grouped)
            {
                if (item.Count() == 2)
                {
                    sumOfTwos = item.Key * 2;
                }
                if (item.Count() == 3)
                {
                    sumOfThrees = item.Key * 3;
                }
            }
            
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
            return countOfFaceValue == faceValue;
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

        public int ScoreThreeOfAKind()
        {
            return ScoreMultipleOfAKind(3);
        }

        public int ScoreFourOfAKind()
        {
            return ScoreMultipleOfAKind(4);
        }

        private int ScoreMultipleOfAKind(int amountOfAKind)
        {
            var faceValues = new List<int> { 1, 2, 3, 4, 5, 6 }.OrderByDescending(i => i);
            foreach (var faceValue in faceValues)
            {
                int countOfFaceValue = GetOccurrenceOfFaceValue(faceValue);
                if (countOfFaceValue >= amountOfAKind) { return faceValue * amountOfAKind; }
            }
            return 0;
        }

        public int ScoreYatzy()
        {
            var faceValues = new List<int> { 1, 2, 3, 4, 5, 6 }.OrderByDescending(i => i);
            foreach (var faceValue in faceValues)
            {
                int countOfFaceValue = GetOccurrenceOfFaceValue(faceValue);
                if (countOfFaceValue >= 5) { return 50; }
            }
            return 0;
        }

        public int ScoreChance()
        {
            return DiceCollection.Sum();
        }
    }
}
