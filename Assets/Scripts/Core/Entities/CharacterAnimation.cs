using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core.Components
{
    public class CharacterAnimation : CharacterComponent
    {
        private Animator animator;

        public override void Initialize(CharacterManager manager)
        {
            base.Initialize(manager);
            animator = GetComponentInChildren<Animator>();
        }

        public void SetBool(string parameterName, bool value) => animator.SetBool(parameterName, value);
        public void SetFloat(string parameterName, float value) => animator.SetFloat(parameterName, value);
        public void SetTrigger(string parameterName) => animator.SetTrigger(parameterName);
    }
}
