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
                SetupCardRotations(i);
                SetupCardPositions(i);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetupCardDeck();
                SetupCardRotations(CardManager.Instance.Cards.Count - 1);
                SetupCardPositions(CardManager.Instance.Cards.Count - 1);
            }
        }

        public void SetupCardDeck()
        {   
            int randomIndex = Random.Range(0, cardDetails.cardButtons.Count);
            
            var cardGo = Instantiate(cardDetails.cardButtons[randomIndex].gameObject,
                transform.position, Quaternion.identity);
            
            var cardButton = cardGo.GetComponent<CardButtonUI>();
            
            cardButton.SetupCardInfos(cardButton);
            
            CardManager.Instance.AddCard(cardButton);
            cardButton.transform.SetParent(this.transform);
        }

        public void SetupCardRotations(int index)
        {
            var cardTransform = CardManager.Instance.Cards[index];

            var cardRotation = cardTransform.transform.localEulerAngles;
            cardRotation.z = CardRotation(index);
            cardTransform.transform.localEulerAngles = cardRotation;
            
        }

        public void SetupCardPositions(int index)
        {
            var card = CardManager.Instance.Cards[index];
            float xPosition = (cardDetails.positionGap * index);

            var cardTransform = card.transform;

            cardTransform.localPosition = new Vector3(xPosition, cardTransform.localPosition.y, cardTransform.localPosition.z);
        }

        private float CardRotation(int index)
        {
            return (cardDetails.initialRotation - index * cardDetails.rotationGap);
        }
    }
}