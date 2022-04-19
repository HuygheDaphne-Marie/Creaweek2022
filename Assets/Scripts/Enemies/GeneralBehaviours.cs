using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public sealed class GeneralBehaviours
{
    public static BehaviourState MoveTo(Blackboard blackboard)
    {
        Vector3 target = blackboard.GetData<Vector3>("MoveTarget");
        NavMeshAgent enemyAgent = blackboard.GetData<NavMeshAgent>("ThisAgent");

        NavMeshPath path = new NavMeshPath();
        if (enemyAgent.CalculatePath(target, path))
        {
            /* If we run into performance issues, plan out the complete path and store it in the blackboard */
            if (path.status == NavMeshPathStatus.PathInvalid)
            {
                /* Cry */
                Debug.LogError("Path could not be calculated!");
                return BehaviourState.Failure;
            }

            enemyAgent.SetPath(path);

            return BehaviourState.Success;
        }

        return BehaviourState.Failure;
    }

    /* Make sure no-one can instantiate this class */
    private GeneralBehaviours() { }
}
