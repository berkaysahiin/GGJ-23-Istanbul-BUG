using System;
using Game.Controllers;
using Game.Enemy;
using Game.ScriptableObjects;
using Game.UIs;
using Game.Utils;
using UnityEngine;

namespace Game.Managers
{
    public class BuildingManager : SingletonMonoBehaviour<BuildingManager>
    {
        [SerializeField] private LayerMask layer;
        
        private GameObject _pendingObject;
        private Vector3 _pos;
        private RaycastHit _hit;
        private OxygenController _oxygenController;
        
        private CardScriptableObject _holdingCardSo;
        
        private void Awake()
        {
            SetupInstance();
            _oxygenController = FindObjectOfType<OxygenController>();
        }

        private void Update()
        {   
            if (_pendingObject != null)
            {
                _pendingObject.transform.position = _pos;
            }
        }

        private void FixedUpdate()
        {
            SetObjectPosition();
        }

        private void SetObjectPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out _hit, layer))
            {
                if (_hit.transform.gameObject.GetComponent<BaseTreeController>() != null ||
                    _hit.transform.gameObject.GetComponent<MushroomHouseController>() != null || 
                    _hit.transform.gameObject.GetComponent<Poision>() != null )
                {
                    return;
                }
                
                if(_holdingCardSo == null) return;
                
                var spawnPoint = new Vector3
                (
                    GridManager.Instance.RoundToNearest((_hit.point).x)  + _holdingCardSo.spawnOffset.x,
                    _hit.point.y + _holdingCardSo.spawnOffset.y,
                    GridManager.Instance.RoundToNearest((_hit.point).z)  + _holdingCardSo.spawnOffset.z
                );
                
                _pos = spawnPoint;
            }
        }

        public void PlaceObject()
        {
            CameraManager.Instance.ShakeCamera(0.8f, 0.3f, 10, 20);
            _oxygenController.DecreaseOxygenAmount(_holdingCardSo.oxygenCount);
            _pendingObject = null;
        }
        
        public void SelectObject(CardScriptableObject card)
        {
            _holdingCardSo = card;
            _pendingObject = Instantiate(card.card, _pos, Quaternion.identity);
            
            if (_pendingObject.gameObject.GetComponent<IEntityController>() != null)
            {
            }
        }
    }
}