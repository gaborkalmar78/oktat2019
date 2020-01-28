namespace _014.Models
{
    public interface IHasLegs
    {
        int LegNumber
        {
            get;
            set;
        }
        void Walk(int distance);
    }
}