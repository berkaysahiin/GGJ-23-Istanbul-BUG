using UnityEngine;
using Game.Controllers;

namespace Game.Enemy
{
  public class EnemyController : MonoBehaviour, IHealth, IDamageDealer
  {
    [SerializeField] private float _health;
    public float Health => _health;
    public bool IsDead => _health <= 0;

    public BaseTreeController  target { get; set; }

    public void DealDamage(IHealth health, float damage)
    {
      health.TakeDamage(damage);
    }

    public void New(float health)
    {
      this._health = health;
    }

    public void TakeDamage(float dmg)
    {
      if(IsDead) return;
      _health -= dmg;
    }

    public void Update()
    {
      if(IsDead) Destroy(this.gameObject);

    }

    private BaseTreeController GetClosestTree()
    {
      Collider[] colliders = Physics.OverlapSphere(transform.position, 20);

      float minDistance = float.MaxValue;
      BaseTreeController targetTree = null;

      foreach(var collider in colliders)
      {
        if(collider.gameObject.GetComponent<BaseTreeController>() is null) continue;

        var distance = Vector3.Distance(transform.position, collider.gameObject.transform.position);

        if(distance < minDistance) 
        {
          targetTree = collider.GetComponent<BaseTreeController>();
        }

      }

      return targetTree;
    }

    public void OnDrawGizmos()
    {
      Gizmos.DrawWireSphere(transform.position, 20);
    }
  }
}
