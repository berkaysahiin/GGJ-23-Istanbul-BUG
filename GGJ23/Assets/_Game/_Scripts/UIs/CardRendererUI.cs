using System;
using System.Collections.Generic;
using Game.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.UIs
{
    [Serializable]
    public struct CardDetails
    {
        public List<CardButtonUI> cardButtons;
        public float rotationGap;
        public float initialRotation;
        public int cardAmount;
        public float positionGap;
    }
    public class CardRendererUI : MonoBehaviour
    {
        [SerializeField] private CardDetails cardDetails;
        private void Start()
        {
            for (int i = 0; i < cardDetails.cardAmount; i++)
            {
                SetupCardDeck();
                SetupCardRotations(CardManager.Instance.Cards.Count);
                SetupCardPositions(CardManager.Instance.Cards.Count);
            }
        }

        private void SetupCardDeck()
        {
            int randomIndex = Random.Range(0, cardDetails.cardButtons.Count);
            
            var cardGo = Instantiate(cardDetails.cardButtons[randomIndex].gameObject,
                transform.position, Quaternion.identity);
            
            var cardButton = cardGo.GetComponent<CardButtonUI>();
            
            cardButton.SetupCardInfos(cardButton);
            
            CardManager.Instance.AddCard(cardButton);
            cardButton.transform.SetParent(this.transform);
        }

        private void SetupCardRotations(int index)
        {
            Debug.Log("TOTAL CARDS: " + CardManager.Instance.Cards.Count);
            for (int i = 0; i < index; i++)
            {
                var card = CardManager.Instance.Cards[i];
                float zRotate = (cardDetails.initialRotation - i * cardDetails.rotationGap);

                var cardTransform = card.transform;
                card.transform.localRotation = Quaternion.Euler(new Vector3(cardTransform.localRotation.x, cardTransform.localRotation.y, zRotate));
            }
        }

        private void SetupCardPositions(int index)
        {
            for (int i = 0; i < index; i++)
            {
                var card = CardManager.Instance.Cards[i];
                float xPosition = (cardDetails.positionGap * i);

                var cardTransform = card.transform;

                cardTransform.localPosition = new Vector3(xPosition, cardTransform.localPosition.y, cardTransform.localPosition.z);
            }
        }
    }
}