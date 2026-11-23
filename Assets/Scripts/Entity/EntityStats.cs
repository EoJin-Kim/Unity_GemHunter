using UnityEngine;
using System.Linq;

[System.Serializable]
public struct EntityStats
{
	[Header("Level, Exp")]
	public	int		level;				// 레벨
	public	float	exp;				// 경험치

	[Header("Current Stats")]
	[SerializeField]
	private	Stat	currentHP;

	[Header("Stats")]
	[SerializeField]
	private	Stat[]	stats;

	public readonly Stat CurrentHP					=> currentHP;
	public readonly	Stat GetStat(Stat stat)			=> stats.FirstOrDefault(s => s.StatType == stat.StatType);
	public readonly Stat GetStat(StatType statType)	=> stats.FirstOrDefault(s => s.StatType == statType);
}

