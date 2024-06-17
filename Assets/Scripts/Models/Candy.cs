using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class Candy : ICandy
    {
        public string CandyId { get; }
        public int Amount { get; set; }
        public int Collect()
        {
            return Amount;
        }

        public Candy(string candyId, int amount)
        {
            CandyId = candyId;
            Amount = amount;
        }

    }
}