
namespace _008
{
    public class Card
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int MaxSpeed { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public int Engine { get; set; }

        public override string ToString()
        {
            return Name;
            // return $@< table >
            // < tr >
            // < td > Speed:</ td >


            //  < td >{ MaxSpeed}</ td >


            //   </ tr >


            //   < tr >


            //   < td > Weight:</ td >


            //    < td >{ Weight}</ td >


            //     </ tr >


            //     </ table >
        }
        public object ToHtml()
        {
            return Name;
        }
    }
}
