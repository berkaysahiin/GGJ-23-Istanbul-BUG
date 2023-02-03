using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Controllers
{
    public abstract class BaseTreeController : MonoBehaviour
    {  
        [Header("Animations")]
        [SerializeField] private float xAnimValue = -0.5f;
        [SerializeField] private float zAnimValue = -0.5f;
        [SerializeField] private float initialAnimationDuration = 0.2f;

        private void Start()
        {
            transform.DOScale(new Vector3(xAnimValue, transform.localScale.y, zAnimValue), initialAnimationDuration)
                .OnComplete(() => transform.DOScale(new Vector3(1, 1, 1), 1.0f));
        }
    }
}