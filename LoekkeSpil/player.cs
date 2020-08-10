using System;
using System.Collections.Generic;
using System.Text;

namespace LoekkeSpil
{
    class player
    {
        protected string name;
        protected int points;

        public player(string name, int points)
        {
            Name = name;
            Points = points;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
    }
}
