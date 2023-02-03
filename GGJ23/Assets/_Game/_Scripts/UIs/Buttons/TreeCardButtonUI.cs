using Unity.Mathematics;
using UnityEngine;

namespace Game.UIs
{
    public class TreeCardButtonUI : CardButtonUI
    {
        [SerializeField] private LayerMask layerMask;
        private Vector3 _mousePosition;
        private Camera _camera;


        protected override void Start()
        {
            base.Start();
            _camera = Camera.main;
        }

        private void OnDestroy()
        {
            SpawnEntity();
        }

        protected override void SpawnEntity()
        {
            _mousePosition = Input.mousePosition;
            
            Ray ray = _camera.ScreenPointToRay(_mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, layerMask))
            {
                Instantiate(CardScriptableObject.card, hit.point + CardScriptableObject.spawnOffset, quaternion.identity);
            }
        }
    }
}
