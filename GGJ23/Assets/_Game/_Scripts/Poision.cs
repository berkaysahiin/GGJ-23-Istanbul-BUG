using UnityEngine;

namespace Game.Enemy
{   
    public class Poision : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private float damage;
        [SerializeField] private float lifeTime;

        private void Awake() 
        {
            Destroy(this.gameObject, lifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<EnemyController>();
            if(enemy is null) return;
            enemy.TakeDamage(damage);
        }
    }
}
