using Infrastructure;

namespace Model
{
    public class Rating : Entity
    {
        public int Positives { get; set; }
        public int Negatives { get; set; }

        public int Popularity
        {
            get { return this.Positives - this.Negatives; }
            private set { }//Used by EF
        }

        public int NumberOfVotes
        {
            get { return this.Positives + this.Negatives; }
        }

    }
}
