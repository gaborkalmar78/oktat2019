namespace _017.Models
{
    public class DataModel
    {
        public DataModel(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int Value
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }
}