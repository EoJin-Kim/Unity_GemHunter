using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Unity.Behavior;



public class EnemyFSM : MonoBehaviour
{

    private EnemyBase owner;

    private NavMeshAgent navMeshAgent;  // 적 이동 경로 설정 및 이동 제어

    private BehaviorGraphAgent behaviorAgent;	// 적 행동 제어


    private void Awake()
    {
        owner = GetComponent<EnemyBase>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        behaviorAgent = GetComponent<BehaviorGraphAgent>();

        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

    }

    public void Setup(EntityBase target, GameObject[] wayPoints)
    {
        owner.Target = target;

        behaviorAgent.SetVariableValue("PatrolPoints", wayPoints.ToList());
    }


}

