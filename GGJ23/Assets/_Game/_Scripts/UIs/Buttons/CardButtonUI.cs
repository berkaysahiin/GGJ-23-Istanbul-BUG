using System;
using DG.Tweening;
using Game.Managers;
using Game.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UIs
{
    [Serializable]
    public struct CardMovement
    {
        public float cardMovement;
        public float cardDuration;
    }
    
    public abstract class CardButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CardMovement _cardMovement;
        [SerializeField] private CardScriptableObject cardScriptableObject;
        public CardScriptableObject CardScriptableObject => cardScriptableObject;

        private bool _isDragging;
        
        private TextMeshProUGUI _cardName;
        private TextMeshProUGUI _oxygenCount;
        private Image _cardImage;

        private void Awake()
        {            
            _cardName    = GetComponentsInChildren<TextMeshProUGUI>()[0];
            _oxygenCount = GetComponentsInChildren<TextMeshProUGUI>()[1];
            _cardImage   = GetComponentInChildren<Image>();
        }

        protected virtual void Start()
        {
            MoveCard(transform.up, _cardMovement.cardMovement, _cardMovement.cardDuration);
        }

        public void SetupCardInfos(CardButtonUI cardButtonUI)
        {
            _cardName.text = cardButtonUI.cardScriptableObject.cardName;
            _cardImage.sprite = cardButtonUI.cardScriptableObject.cardSprite;
            _oxygenCount.text = cardButtonUI.cardScriptableObject.oxygenCount.ToString();
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            MoveCard(transform.up, _cardMovement.cardMovement, _cardMovement.cardDuration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MoveCard(transform.up * -1, _cardMovement.cardMovement, _cardMovement.cardDuration);
        }

        private void MoveCard(Vector3 direction, float movementSpeed, float duration)
        {
            transform.DOLocalMove((transform.localPosition + direction * movementSpeed), duration);
        }

        public void DraggingStart()
        {
            _isDragging = true;
        }

        public void SelectionOver()
        {
            _isDragging = false;
            CardManager.Instance.Cards.Remove(this);
            Destroy(this.gameObject);
        }

        protected abstract void SpawnEntity();
    }
}