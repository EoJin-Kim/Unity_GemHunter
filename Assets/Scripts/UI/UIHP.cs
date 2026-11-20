using UnityEngine;
using UnityEngine.UI;

public class UIHP : MonoBehaviour
{
	[SerializeField]
	private	Image		image;
	[SerializeField]
	private	EntityBase	entity;

	public void Setup(EntityBase entity)
	{
		this.entity = entity;
	}

	private void Update()
	{
		image.fillAmount = entity.Stats.currentHP / entity.Stats.maxHP;
	}
}


/*
 * Memo
 * 플레이어와 같이 Hierarchy View에 미리 배치해둔 오브젝트는 Inspector View에서 entity를 설정하고,
 * 적과 같이 코드를 이용해 게임 도중 생성하는 오브젝트는 Setup() 메소드를 이용해 entity를 설정한다.
 */