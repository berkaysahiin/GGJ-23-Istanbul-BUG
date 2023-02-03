using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Card", menuName = "My Assets/Card Scriptable Object")]
    public class CardScriptableObject : ScriptableObject
    {
        public string cardName;
        public Sprite cardSprite;
        public GameObject card;
        [Multiline] public string description;
        public int oxygenCount;
        public Vector3 spawnOffset;
    }
}