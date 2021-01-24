using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    public class PlayerList
    {
        public List<IBuff> _buffs = new List<IBuff>();
        public float MyPoints = 0.0f;
        public float Speed = 0.0f;

        public PlayerList(float basePoints)
        {
            MyPoints = basePoints;
        }
    }
}
