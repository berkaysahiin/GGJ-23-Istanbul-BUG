using UnityEngine;
using Game.Controllers;
using Game.Managers;
using UnityEngine.AI;

namespace Game.Enemy
{
  public class EnemyController : BaseCharacterController, IHealth, IDamageDealer
  {
    [SerializeField] private float _health;
    public float Health => _health;
    private NavMeshAgent _navMesh;
    private Animator _animator;
    public bool IsDead => _health <= 0;
    public bool IsFeared => LevelManager.Instance.isNight;
    private BaseTreeController _targetTree = null;


    public Transform  target { get; set; }

    private void Awake()
    {
      _navMesh = GetComponent<NavMeshAgent>();
      _animator = GetComponent<Animator>();
    }

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
      if(IsFeared)
      {
        target = GetClosestTree();
        // SetTarget(Vector3.back * 100);
      }
      else {
        target = GetClosestTree();
      }

      if(IsDead) Destroy(this.gameObject);
      
      transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
      
      if (Vector3.Distance(target.transform.position, transform.position) >= _navMesh.stoppingDistance)
      {
        _animator.SetBool("isAttacking", false);
        _navMesh.SetDestination(target.transform.position);
      }

      if (Vector3.Distance(target.transform.position, transform.position) <= _navMesh.stoppingDistance)
      {
        print("Attacking");
        _animator.SetBool("isAttacking", true);
        DealDamage(target.GetComponent<IHealth>(), 0.1f);
       
        if (target.GetComponent<IHealth>().IsDead)
        {
          if(target.GetComponent<TreeController>() != null)
            Destroy(target.GetComponent<TreeController>().spawnedVfx.gameObject);
          Destroy(target.gameObject);
        }
        
        transform.LookAt(target.transform);
      }
    }

    private Transform GetClosestTree()
    {
      Collider[] colliders = Physics.OverlapSphere(transform.position, 40);

      float minDistance = float.MaxValue;

      foreach(var collider in colliders)
      {
        if(collider.gameObject.GetComponent<BaseTreeController>() is null) continue;

        var distance = Vector3.Distance(transform.position, collider.gameObject.transform.position);

        if(distance < minDistance)
        {
          minDistance = distance;
          _targetTree = collider.GetComponent<BaseTreeController>();
        }
      }

      return _targetTree.transform;
    }

    public void SetTarget(Vector3 fearPoint)
    {
      target.position = fearPoint;
    }

    public void OnDrawGizmos()
    {
      Gizmos.DrawWireSphere(transform.position, 40);
    }
  }
}