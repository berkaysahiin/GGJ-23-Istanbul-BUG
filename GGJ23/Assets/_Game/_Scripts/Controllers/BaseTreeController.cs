using System;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;
using Game.Enemy;

namespace Game.Controllers
{
    public abstract class BaseTreeController : MonoBehaviour, IHealth
    {  
        [Header("Animations"), Space]
        [SerializeField] private float xAnimValue = -0.5f;
        [SerializeField] private float zAnimValue = -0.5f;
        [SerializeField] private float initialAnimationDuration = 0.2f;  
        [SerializeField] protected GameObject rootVfx;
        public GameObject spawnedVfx;
        
        [Header("Oxygen Produce Factor"), Space] 
        [SerializeField] protected float oxygenProduceFactor;
        
        private OxygenController _oxygenController;
        
        [SerializeField] private float _health;

        public OxygenController OxygenController => _oxygenController;

        public float Health => _health; 
        public bool IsDead => _health <= 0;

        private void Awake()
        {
            _oxygenController = FindObjectOfType<OxygenController>();
        }

        protected virtual void Start()
        {   
            transform.DOScale(new Vector3(xAnimValue, transform.localScale.y, transform.localScale.z), initialAnimationDuration)
                .OnComplete(() => transform.DOScale(new Vector3(.2f, transform.localScale.y, .2f), 1.0f));

        }

        protected virtual void Update()
        {
            MakeOxygen();
        }

        protected void MakeOxygen()
        {
            OxygenController.IncreaseOxygenAmount(oxygenProduceFactor);
        }

        public void TakeDamage(float dmg)
        {
            _health -= dmg;
        }
  }
}