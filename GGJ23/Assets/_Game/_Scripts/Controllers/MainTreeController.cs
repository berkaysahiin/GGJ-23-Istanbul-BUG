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

            if(Health <= 0)
            {
                Debug.Log("Main Tree Controller is Dead");
                GameManager.Instance.LoseGame();
            }

        }
    }
}
