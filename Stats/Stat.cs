﻿namespace Mine.Stats
{
    public class Stat
    {
        public float Base;
        public float Multiplier;

        public Stat(float @base, float multiplier)
        {
            Base = @base;
            Multiplier = multiplier;
        }
    }
}