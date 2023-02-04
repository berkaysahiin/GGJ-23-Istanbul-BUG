using Game.Utils;
using UnityEngine;

namespace Game.Managers
{
    public class GridManager : SingletonMonoBehaviour<GridManager>
    {
        [SerializeField] private float gridSize;
        
        private void Awake()
        {
            SetupInstance();
        }

        public float RoundToNearest(float pos)
        {
            float xDiff = pos % gridSize;
            pos -= xDiff;

            if (xDiff > (gridSize / 2))
            {
                pos += gridSize;
            }

            return pos;
        }
    }
}
