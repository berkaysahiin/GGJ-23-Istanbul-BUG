using System.Collections;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;

namespace Game.Enemy
{
  public class EnemyFactory : SingletonMonoBehaviour<EnemyFactory>
  {
    private void Awake() 
    {
        SetupInstance();
    }

    public EnemyController InstantiateEnemy(EnemyType type, Vector3 spawnPosition)
    {
        var obj = new GameObject(type.ToString());
        obj.transform.position = spawnPosition;
        return obj.AddComponent<EnemyController>();
    }
  }
}
