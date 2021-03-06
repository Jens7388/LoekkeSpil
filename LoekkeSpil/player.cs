﻿namespace LoekkeSpil
{
    class Player
    {
        protected string name;
        protected int points;

        public Player(string name, int points)
        {
            Name = name;
            Points = points;
        }
        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name != value)
                {
                    name = value;
                }
            }
        }
        public virtual int Points
        {
            get
            {
                return points;
            }
            set
            {
                if(points != value)
                {
                    points = value;
                }
            }
        }
    }
}