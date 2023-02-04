using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public interface IDamageDealer  
    {
      void DealDamage(IHealth health, float damage);
    }
}

