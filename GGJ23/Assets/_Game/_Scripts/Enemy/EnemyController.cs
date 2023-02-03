using UnityEngine;

namespace Game.Enemy
{
  public class EnemyController : MonoBehaviour, IHealth
  {
    private float _health;
    public float Health => _health;
    public bool IsDead => _health <= 0;

    public void TakeDamage(float dmg)
    {
      if(IsDead) return;
      _health -= dmg;
    }
  }
}
