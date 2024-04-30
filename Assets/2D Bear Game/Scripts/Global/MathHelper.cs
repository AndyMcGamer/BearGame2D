using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Global
{
    public static class MathHelper
    {
        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
