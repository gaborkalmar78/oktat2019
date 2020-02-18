namespace login_nvc.Models
{
    public class DataModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public DataModel(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }





}