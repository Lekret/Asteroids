﻿using Services;
using UnityEngine;

namespace ServicesImpl
{
    public class Randomizer : IRandomizer
    {
        public int Range(int min, int max)
        {
            return Random.Range(min, max);
        }

        public float Range(float min, float max)
        {
            return Random.Range(min, max);
        }

        public Vector2 RandomDirection()
        {
            return Random.insideUnitCircle.normalized;
        }
    }
}