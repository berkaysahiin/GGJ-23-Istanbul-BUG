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
            if (other.gameObject.tag.Equals("Enemy"))
            {
                other.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            }
        }
    }
}
