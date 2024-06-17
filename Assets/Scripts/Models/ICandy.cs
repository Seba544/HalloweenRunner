using System.ComponentModel;

namespace Models
{
    public interface ICandy
    {
        public string CandyId { get; }
        public int Amount { get; set; }

        public int Collect();
    }
}