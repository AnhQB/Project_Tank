using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Enum
{
  /*  public enum DameMonster : int
    {
        M1_320 = 1
    }
*/
    public class DameMonster
    {
        private static readonly float[] damage320 = { 0.1f, 0.2f, 0.3f,  0.5f, 0.7f, 1f, 10f};
        private static readonly float[] damage1280 = { 0.5f, 0.6f, 0.7f, 0.9f, 1.1f, 1.4f, 20f };
        private static readonly float[] damage5120 = { 1.5f, 1.6f, 1.7f, 1.9f, 2.1f, 3f , 30f};

        public static float GetDameMonsterByType(int monsterType, int expLevel)
        {
            float dame = 0;
            switch (expLevel)
            {
                //exp <= 320
                case 0:
                    dame = damage320[monsterType];
                    break;
                case 1: // exp <= 1280
                    dame = damage1280[monsterType];
                    break;
                case 2: //exp <= 5120
                    dame = damage5120[monsterType];
                    break;
            }
            return dame;
        }
    }
}
