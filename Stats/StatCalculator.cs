using Assets.Scripts.Data;

namespace Assets.Scripts
{
    public static class StatCalculator
    {

        public static float Calculate(Stat stat, int level)
        {
            return stat.Base + stat.Multiplier * level;
        }

        public static int CalculateAsInt(Stat stat, int level)
        {
            return (int)Calculate(stat,level);
        }
    }
}