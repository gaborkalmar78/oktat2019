namespace _019.Models
{
    public class DataModel
    {
        public DataModel(int playernumber, string[] names)
        {
            Playernumber = playernumber;
            Names = names;
        }

        public int Playernumber
        {
            get;
            set;
        }
        public string[] Names
        {
            get;
            set;
        }
    }
}