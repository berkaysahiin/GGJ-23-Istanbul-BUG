using System;
using System.Collections.Generic;
using System.Linq;
using Game.UIs;
using Game.Utils;
using UnityEngine;

namespace Game.Managers
{
    public class CardManager : SingletonMonoBehaviour<CardManager>
    {
        [SerializeField] private List<CardButtonUI> cards;

        public List<CardButtonUI> Cards => cards;
        
        private void Awake()
        {
            SetupInstance();
        }

        private void Start()
        {
            cards = FindObjectsOfType<CardButtonUI>().ToList();
        }

        public void AddCard(CardButtonUI item)
        {
            if(item != null) 
                cards.Add(item);
               
        }

        public void RemoveCard(CardButtonUI item)
        {
            if (item != null)
                cards.Remove(item);
        }
    }
}
