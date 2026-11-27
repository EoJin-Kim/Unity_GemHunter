using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckTargetDetect", story: "Compare values of [CurrentDistance] and [ChaseDistance]", category: "Conditions", id: "de79dabe3b6c03c2275d8f2abbdee51e")]
public partial class CheckTargetDetectCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> CurrentDistance;
    [SerializeReference] public BlackboardVariable<float> ChaseDistance;

    public override bool IsTrue()
    {
        if ( CurrentDistance.Value <= ChaseDistance.Value )
        {
            return true;
        }

        return false;
    }


}
