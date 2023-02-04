using UnityEngine;

namespace Game.Controllers
{
    public class TreeController : BaseTreeController, IEntityController
    {
        [SerializeField] private GameObject rootVfx;
        public GameObject spawnedVfx;

        protected override void Start()
        {
            base.Start();
            spawnedVfx = Instantiate(rootVfx, FindObjectOfType<MainTreeController>().transform.position + new Vector3(0, -3, 0), Quaternion.identity);
        }

        protected override void Update()
        {
            base.Update();

            spawnedVfx.GetComponentsInChildren<Transform>()[2].transform.position = transform.position;
        }
    }
}
