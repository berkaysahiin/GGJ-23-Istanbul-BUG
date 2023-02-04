using UnityEngine;
using Game.Managers;

namespace Game.Controllers
{
    public class MainTreeController : BaseTreeController, IEntityController
    {
        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            base.Update();

            if(this.IsDead)
            {
                GameManager.Instance.LoseGame();
            }

        }
    }
}
