using System;
using UnityEngine;
using Game.Managers;

namespace Game.Controllers
{
    public class MainTreeController : BaseTreeController, IEntityController
    {
        protected override void Start()
        {
        }

        private void OnDestroy()
        {
            GameManager.Instance.LoseGame();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
