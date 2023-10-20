using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ItemData {
	public MaterialData.Type intendedType;
	public float basicDamage;
	public float timeBetweenAttack;
	public float attackRange;
	public float spread;
	public int attacksPerAction;
	public string aim;
	public bool centalFirstAttack;
}
