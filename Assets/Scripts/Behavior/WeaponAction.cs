using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Weapon", story: "try attack with [CurrentWeapon]", category: "Action", id: "171502ebefc899dcb2853ca4ef2144ae")]
public partial class WeaponAction : Action
{
    [SerializeReference] public BlackboardVariable<WeaponBase> CurrentWeapon;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {

        CurrentWeapon.Value.TryAttack();

        return Status.Success;
    }

}

