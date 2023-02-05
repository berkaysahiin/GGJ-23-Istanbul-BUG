using UnityEngine;

namespace Game.Enemy
{   
    public class Poision : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private float damage;
        [SerializeField] private float lifeTime;

        [SerializeField] private GameObject vfx;

        private void Awake() 
        {
            Destroy(this.gameObject, lifeTime);
            GameObject.Instantiate(vfx, this.transform.position, Quaternion.identity);
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
