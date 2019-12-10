using System.Collections.Generic;

namespace CardGame
{
    public class Card
    {
        public int MaxSpeed { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{{Max: {MaxSpeed}, Weight: {Weight}}}";
        }



        public static string Teszt()
        {
            return "teszt";
        }

        // public string ToHtml()
        // {
        //     return $@"<table>
        //         <tr>
        //             <td>Speed:</td>
        //             <td>{MaxSpeed}</td>
        //         </tr>
        //         <tr>
        //             <td>Weight:</td>
        //             <td>{Weight}</td>
        //         </tr>
        //     </table>";
        // }
    }
}