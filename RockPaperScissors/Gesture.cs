using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Gesture
    {
        //Member variable
        public string name;
        public List<string> winsAgainstList;

        //Constructor
        public Gesture(string name, List<string> winsAgainstList)
        {
            this.name = name;
            this.winsAgainstList = winsAgainstList;
        }

        //Member methods
        public int WinsAgainst(List<string> winsAgainstlist)
        {
            foreach (string gesture in winsAgainstList)
            {
                if (gesture == this.name)
                {
                    //3 signifies tie
                    return 3;
                }
                else if (winsAgainstList.Contains(gesture))
                {
                    //2 signifies win
                    return 2;
                }
                else
                {
                    //1 signifies loss
                    return 1;
                }
            }
            return 0;
        }


    }
}
