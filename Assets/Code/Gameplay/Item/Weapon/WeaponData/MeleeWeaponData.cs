using UnityEngine;

[CreateAssetMenu (fileName = "Melee", menuName = "Weapon/Melee")]
public class MeleeWeaponData : WeaponData {
	[Tooltip ("Maximal durability of weapon")]
	public float durability;
}
