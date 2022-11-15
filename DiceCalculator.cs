using System;
using System.Collections.Generic;
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
            this.DiceCollection = new List<int> { dice1, dice2, dice3, dice4, dice5 };
        }

        public int SumOfNumbers(int number)
        {
            return this.DiceCollection.Count(x => x == number) * number;
        }

        public int ScoreOnes()
        {
            return this.SumOfNumbers(1);
        }
    }
}
