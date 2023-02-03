using System;
using System.Collections;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;

namespace Game.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Awake()
        {
            SetupInstance();
        }
    }
}
