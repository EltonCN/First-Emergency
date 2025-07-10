using System;
using UnityEngine;

namespace MyUnityScripts
{
    static public class RandomUtils
    {
        static public double normal(double mean, double std)
        {
            double u1 = 1.0 - UnityEngine.Random.Range(0f, 1f);
            double u2 = 1.0 - UnityEngine.Random.Range(0f, 1f);
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                        Math.Sin(2.0 * Math.PI * u2);
            double randNormal =
                        mean + std * randStdNormal;

            return randNormal;
        }
    }
}