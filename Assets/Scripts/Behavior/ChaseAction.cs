using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Self] Navigate To [Target]", category: "Action", id: "6352cb4f6f038fe8a7ed1b0ac00be7a3")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private NavMeshAgent agent;
    private EntityBase target;

    protected override Status OnStart()
    {

        agent = Self.Value.GetComponent<NavMeshAgent>();
        target = Target.Value.GetComponent<EntityBase>();

        agent.speed = 5f;
        agent.SetDestination(target.MiddlePoint);


        return Status.Running;
    }


}

