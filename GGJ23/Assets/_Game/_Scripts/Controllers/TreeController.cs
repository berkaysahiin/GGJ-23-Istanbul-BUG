using System;
using Game.Managers;
using UnityEngine;

namespace Game.Controllers
{
    public class TreeController : BaseTreeController, IEntityController
    {
        protected override void Start()
        {
            base.Start();
            try
            {
                spawnedVfx = Instantiate(rootVfx, FindObjectOfType<MainTreeController>().transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
            catch (Exception e)
            {
                Debug.LogWarning("E" + e.Message);
            }
        }

        protected override void Update()
        {
            base.Update();
            if (spawnedVfx == null)
            {
                GameManager.Instance.LoseGame();
                return;
            }
            spawnedVfx.GetComponentsInChildren<Transform>()[2].transform.position = transform.position;
        }
    }
}
