using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Wander", story: "[Self] Navigate To WanderPosition", category: "Action", id: "ff8f3b921686bdb5547b8c39f4307ad2")]
public partial class WanderAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    private NavMeshAgent agent;
    private Vector3 wanderPosition;
    private float currentWanderTime = 0f;
    private float maxWanderTime = 5f;

    protected override Status OnStart()
    {

        int jitterMin = 0;                                              // 최소 각도
        int jitterMax = 360;                                                // 최대 각도
        float wanderRadius = UnityEngine.Random.Range(2.5f, 6f);                // 현재 위치를 원점으로 하는 원의 반지름
        int wanderJitter = UnityEngine.Random.Range(jitterMin, jitterMax);  // 선택된 각도 (wanderJitterMin ~ wanderJitterMax)

        // 목표 위치 = 자신(Self)의 위치 + 각도(wanderJitter)에 해당하는 반지름(wanderRadius) 크기의 원의 둘레 위치
        wanderPosition = Self.Value.transform.position + Utils.GetPositionFromAngle(wanderRadius, wanderJitter);
        agent = Self.Value.GetComponent<NavMeshAgent>();
        agent.SetDestination(wanderPosition);
        currentWanderTime = Time.time;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {

        if ((wanderPosition - Self.Value.transform.position).sqrMagnitude < 0.1f || Time.time - currentWanderTime > maxWanderTime)
        {
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

