namespace cardgame_asp.T
{
    public interface IHasLegs
    {
        int Legscount { get; set; }
        void Walk(int distance);



    }
}