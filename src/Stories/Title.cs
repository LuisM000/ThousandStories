using Infrastructure;

namespace Model
{
    public class Title : Entity
    {
        public string Value { get; private set; }

        protected Title() { }
        public Title(string value)
        {
            //ToDo: create bussines rules
            this.Value = value;
        }


    }
}
