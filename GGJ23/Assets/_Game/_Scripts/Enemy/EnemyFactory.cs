using Game.Utils;
using UnityEngine;

namespace Game.Enemy
{
  public class EnemyFactory : SingletonMonoBehaviour<EnemyFactory>
  {
    [SerializeField] private GameObject _oduncu;
    [SerializeField] private GameObject vfx;

    private void Awake() 
    {
        SetupInstance();
    }

    public EnemyController InstantiateEnemy(EnemyType type, Vector3 spawnPosition)
    {
        switch(type)
        {
          case EnemyType.Oduncu:
          {
            var obj = Instantiate(_oduncu, spawnPosition, Quaternion.identity);
            // vfx.transform.position = obj.transform.position;
            obj.transform.position = spawnPosition;
            var enemyController = obj.AddComponent<EnemyController>();
            enemyController.New(100);
            return enemyController;
          }
        }

        Debug.LogError("Please speficy enemy type you want to instantiate");
        return null;
      }
  }
}
