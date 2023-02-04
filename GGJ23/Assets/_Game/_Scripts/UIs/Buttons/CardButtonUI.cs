using System;
using DG.Tweening;
using Game.Controllers;
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
        [SerializeField] private CardMovement cardMovement;
        [SerializeField] private CardScriptableObject cardScriptableObject;
        public CardScriptableObject CardScriptableObject => cardScriptableObject;

        private bool _isDragging;
        
        private TextMeshProUGUI _cardName;
        private TextMeshProUGUI _oxygenCount;
        private Image _cardImage;

        private Vector3 initialVector;

        
        private bool IsCardSelectable => cardScriptableObject.oxygenCount < OxygenController.OxygenAmount;
        
        private void Awake()
        {            
            _cardName    = GetComponentsInChildren<TextMeshProUGUI>()[0];
            _oxygenCount = GetComponentsInChildren<TextMeshProUGUI>()[1];
            _cardImage   = GetComponentInChildren<Image>();
        }

        protected virtual void Start()
        {
            MoveCard(initialVector, cardMovement.cardMovement, cardMovement.cardDuration);
        }

        protected virtual void Update()
        {
            if (IsCardSelectable)
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
        }

        public void SetupCardInfos(CardButtonUI cardButtonUI)
        {
            _cardName.text = cardButtonUI.cardScriptableObject.cardName;
            _cardImage.sprite = cardButtonUI.cardScriptableObject.cardSprite;
            _oxygenCount.text = cardButtonUI.cardScriptableObject.oxygenCount.ToString();
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            MoveCard(transform.up, cardMovement.cardMovement, cardMovement.cardDuration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MoveCard(transform.up * -1, cardMovement.cardMovement, cardMovement.cardDuration);
        }

        private void MoveCard(Vector3 direction, float movementSpeed, float duration)
        {
            if (IsCardSelectable)
            {
                transform.DOLocalMove((transform.localPosition + direction * movementSpeed), duration);
            }
        }
        
        // private void MoveCard(Vector3 dir, float pos, float duration)
        // {
        //     if (IsCardSelectable)
        //     {
        //         transform.DOLocalMoveY(pos, duration);
        //     }
        // }

        public void DraggingStart()
        {
            if (IsCardSelectable)
            {
                _isDragging = true;
                BuildingManager.Instance.SelectObject(cardScriptableObject);
            }
        }

        public void SelectionOver()
        {
            if (IsCardSelectable)
            {
                BuildingManager.Instance.PlaceObject();
                CardManager.Instance.Cards.Remove(this);
                _isDragging = false;
                Destroy(this.gameObject);
            }
        }
    }
}