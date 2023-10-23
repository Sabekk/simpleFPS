using UnityEngine;

public abstract class WeaponData : ItemData {
	[Tooltip("Material that reacts to weapon attack")]
	public MaterialData.Type intendedType;
	[Tooltip("Basic damage in one attack")]
	public float basicDamage;
	[Tooltip("Delay between actions")]
	public float timeBetweenAttack;
	[Tooltip("Attack range")]
	public float attackRange;
	[Tooltip("Spread in attack direction")]
	public float spread;
	[Tooltip("Count attacks per one action")]
	public int attacksPerAction;
	[Tooltip("UI aim sprite name")]
	public string aim;
	[Tooltip("Use if first attack of weapon should be in central without spread")]
	public bool centalFirstAttack;
}
