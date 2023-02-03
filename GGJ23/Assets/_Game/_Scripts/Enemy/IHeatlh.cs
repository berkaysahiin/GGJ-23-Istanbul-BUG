using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public interface IHealth
    {
        public float Health {get; }
        public void TakeDamage(float dmg);
        public bool IsDead{get; }
    }
}
