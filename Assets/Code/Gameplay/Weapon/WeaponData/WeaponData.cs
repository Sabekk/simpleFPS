using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ScriptableObject {
	public MaterialData.Type intendedType;
	public string weaponName;
	public float basicDamage;
}
