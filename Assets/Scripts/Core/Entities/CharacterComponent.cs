using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core.Components
{
    public class CharacterComponent : MonoBehaviour
    {
        // VARIABLES
        protected CharacterManager manager;

        // METHODS
        public virtual void Initialize(CharacterManager manager)
        {
            this.manager = manager;
        }
    }
}
