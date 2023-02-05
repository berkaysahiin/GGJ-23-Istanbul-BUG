using UnityEngine;

namespace Game.Enemy
{   
    public class Poision : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private float damage;
        [SerializeField] private float repeatRate;

        private void Awake() 
        {
            InvokeRepeating(nameof(Damage), 0, repeatRate);
        }

        private void Damage()
        {
            var colliders = Physics.OverlapSphere(this.transform.position, radius);

            foreach(var collider in colliders)
            {
                var enemy = collider.GetComponent<EnemyController>();
                if(enemy is null) continue;

                print("enemy has taken " + damage + " damage");
                enemy.TakeDamage(damage);
            }
        }
    }
}
