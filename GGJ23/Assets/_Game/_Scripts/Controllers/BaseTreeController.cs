using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Controllers
{
    public abstract class BaseTreeController : MonoBehaviour
    {  
        [Header("Animations"), Space]
        [SerializeField] private float xAnimValue = -0.5f;
        [SerializeField] private float zAnimValue = -0.5f;
        [SerializeField] private float initialAnimationDuration = 0.2f;

        [Header("Oxygen Produce Factor"), Space] 
        [SerializeField] protected float oxygenProduceFactor;
        
        private OxygenController _oxygenController;

        public OxygenController OxygenController => _oxygenController;

        private Vector3 offset;

        private void Awake()
        {
            _oxygenController = FindObjectOfType<OxygenController>();
        }

        protected virtual void Start()
        {   
     
        }

        private void Update()
        {
            MakeOxygen();
        }

        protected void MakeOxygen()
        {
            OxygenController.IncreaseOxygenAmount(oxygenProduceFactor);
        }
    }
}