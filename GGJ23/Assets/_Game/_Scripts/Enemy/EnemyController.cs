using System;
using DG.Tweening;
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

    public BaseTreeController target { get; set; }

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
      var target = GetClosestTree();
      if(target == null) {
        // GameManager.Instance.LoseGame();
      }

      if (LevelManager.Instance.isNight)
      {
        transform.DOMove(new Vector3(-1000 * transform.forward.x, 0, -1000 * transform.forward.z), 1000);
        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, transform.localRotation.y * -1, transform.localRotation.z));
        _navMesh.SetDestination(Vector3.zero);
        _animator.SetBool("isDead", true);
        Destroy(this.gameObject, 5);
      }
      
      if(LevelManager.Instance.isNight) return;
      if(IsDead) Destroy(this.gameObject);
      
      transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
      try
      {
        if (Vector3.Distance(target.transform.position, transform.position) >= _navMesh.stoppingDistance)
        {
          _animator.SetBool("isAttacking", false);
          _navMesh.SetDestination(target.transform.position);
        }

        if (Vector3.Distance(target.transform.position, transform.position) <= _navMesh.stoppingDistance)
        {
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
      catch (Exception e)
      {
        Debug.Log("E: " + e.Message);
      }
      
    }

    private BaseTreeController GetClosestTree()
    {
      Collider[] colliders = Physics.OverlapSphere(transform.position, 40);

      float minDistance = float.MaxValue;
      BaseTreeController returnTree = null;

      foreach(var collider in colliders)
      {
        if(collider.gameObject.GetComponent<BaseTreeController>() is null) continue;

        var distance = Vector3.Distance(transform.position, collider.gameObject.transform.position);

        if(distance < minDistance)
        {
          minDistance = distance;
          returnTree = collider.GetComponent<BaseTreeController>();
        }
      }

      return returnTree;
    }

    public void OnDrawGizmos()
    {
      Gizmos.DrawWireSphere(transform.position, 40);
    }
  }
}