using System;
using System.Collections;
using DG.Tweening;
using Game.Enemy;
using UnityEngine;

namespace Game.Controllers
{
    public class MushroomHouseController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float health;
        [SerializeField] private LittleMushroomController mushroom;
        
        public float Health => health; 
        public bool IsDead => health <= 0;

        private void Start()
        {
            StartCoroutine(SpawnMushroom());
        }

        public void TakeDamage(float dmg)
        {
            health -= dmg;
        }

        private IEnumerator SpawnMushroom()
        {
            if (LevelManager.Instance.isDay)
            {
                yield return new WaitForSeconds(2);
                Instantiate(mushroom.gameObject, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(3);
                StartCoroutine(SpawnMushroom());
            }
        }
    }
}
