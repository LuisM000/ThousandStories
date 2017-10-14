using Infrastructure;

namespace Model
{
    public class Rating : Entity
    {
        public int Positives { get; set; }
        public int Negatives { get; set; }

        //ToDo: the rest of positives less negatives, return (only getter property) that indicates the ratio
        //not use enums please

    }
}
