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
        }

        public void PlayVFX(Vector3 position)
        {
            GameObject.Instantiate(vfx, position, Quaternion.identity);
        }

        public void TurnOffPoision()
        {
            enabled = false;
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
