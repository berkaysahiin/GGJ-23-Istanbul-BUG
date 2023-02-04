using UnityEngine;

namespace Game.Controllers
{
    public class TreeController : BaseTreeController, IEntityController
    {
        [SerializeField] private GameObject rootVfx;
        private GameObject _spawnedVfx;

        protected override void Start()
        {
            base.Start();
            _spawnedVfx = Instantiate(rootVfx, FindObjectOfType<MainTreeController>().transform.position + new Vector3(0, -3, 0), Quaternion.identity);
        }

        protected override void Update()
        {
            base.Update();

            _spawnedVfx.GetComponentsInChildren<Transform>()[2].transform.position = transform.position;
        }
    }
}
