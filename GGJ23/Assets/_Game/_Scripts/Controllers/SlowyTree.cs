using Game.Controllers;
using Game.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class SlowyTree : BaseTreeController
    {
        [SerializeField] private float radius;
        [SerializeField] private float coefficent;

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            float minDistance = float.MaxValue;

            foreach (var collider in colliders)
            {
                if (collider.gameObject.GetComponent<EnemyController>() != null)
                {
                    collider.gameObject.GetComponent<NavMeshAgent>().speed = 0.7f;
                }
            }
        }
    }
}
