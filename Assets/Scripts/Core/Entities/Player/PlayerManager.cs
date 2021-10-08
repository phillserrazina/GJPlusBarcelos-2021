using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime.Core.Components;

namespace Slime.Core
{
    public class PlayerManager : CharacterManager
    {
        // VARIABLES
        public bool Mounted => MountingManager.Instance.CurrentSlime != null;

        protected override void Initialize()
        {
            base.Initialize();

            GetComponent<PlayerSlimeDetector>().Initialize(this);
        }
    }
}
