namespace _017.Models
{
    public class QueryModel
    {
        public QueryModel(int min, int max, bool inv)
        {
            Min = min;
            Max = max;
            Inv = inv;
        }

        public int Min
        {
            get;
            set;
        }
        public int Max
        {
            get;
            set;
        }
        public bool Inv
        {
            get;
            set;
        }
    }
}