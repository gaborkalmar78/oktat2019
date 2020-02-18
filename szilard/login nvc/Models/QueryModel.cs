namespace login_nvc.Models
{
    public class QueryModel
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public QueryModel(int max, int min)
        {
            this.Max = max;
            this.Min = min;
        }

        public QueryModel()
        {

        }
    }
}