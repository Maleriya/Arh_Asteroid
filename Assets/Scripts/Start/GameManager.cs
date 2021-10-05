using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    public static class GameManager
    {
        public static Vector3 screenXYMin;
        public static Vector3 screenXYMax;
        public static Transform[] asteroidPoint;
        public static Transform[] kometaPoint;
        public static int numAsteroid;
        public static int numKometa;
        public static int numBullet;

        public static void IncremNumAsteroid()
        {
            numAsteroid++;
        }

        public static void IncremNumKometa()
        {
            numKometa++;
        }

        public static void IncremNumBullet()
        {
            numBullet++;
        }
    }
}
