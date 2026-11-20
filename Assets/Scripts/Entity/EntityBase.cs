using UnityEngine;

public class EntityBase : MonoBehaviour
{
	[SerializeField]
	protected	EntityStats	stats;
	[SerializeField]
	private		Transform	middlePoint;

	public		EntityStats	Stats => stats;
	public		bool		IsDead => stats.currentHP <= 0;
	public		Vector3		MiddlePoint => middlePoint != null ? middlePoint.position : Vector3.zero;
	public		EntityBase	Target	{ get; set; }

	protected virtual void Setup()
	{
		stats.currentHP	= stats.maxHP;
	}

	public void TakeDamage(float damage)
	{
		if ( IsDead ) return;

		stats.currentHP = stats.currentHP - damage > 0 ? stats.currentHP - damage : 0;

		if ( stats.currentHP <= 0 )
		{
			// 사망 처리
		}
	}
}


/* // middlePoint 변수에 값을 할당하지 않았을 때 예외처리
		if ( middlePoint == null )
		{
			for ( int i = 0; i < transform.childCount; ++ i )
			{
				Transform child = transform.GetChild(i);
				if ( child.name.Equals("MiddlePoint") )
				{
					middlePoint = child;
				}
			}
		}
*/