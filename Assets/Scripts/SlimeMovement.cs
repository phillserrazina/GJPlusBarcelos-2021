using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Slime.Core.Components
{
    public class SlimeMovement : CharacterMovement
    {
        private NavMeshAgent agent;

        public override void Initialize(CharacterManager manager)
        {
            base.Initialize(manager);
            
            agent = GetComponent<NavMeshAgent>();
        }

        protected override void GetInput()
        {
            if (!agent.hasPath)
            {
                var newRandomPoint = transform.position + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));

                agent.SetDestination(newRandomPoint);
            }
        }

        protected override void Move()
        {

        }

        public override void SetMovementActive(bool value)
        {
            base.SetMovementActive(value);

            agent.enabled = value;
        }
    }
}
