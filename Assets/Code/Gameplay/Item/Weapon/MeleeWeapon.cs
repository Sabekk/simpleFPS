using UnityEngine;

public class MeleeWeapon : Weapon {
	[SerializeField] protected MeleeWeaponData meleeData;
	float durabilityLeft;
	public override Type WeaponType => Type.melee;
	public override string UsingAnimation => "";
	public override bool CanBeUsed => durabilityLeft > 0;
	public override float SpecialActionPercentage => 0;
	float MaxDurability => meleeData.durability;

	public override void Initialize () {
		durabilityLeft = meleeData.durability;
	}

	public override void SetStatistics (Weapon weapon) {
		if (weapon is MeleeWeapon meeleWeapon)
			durabilityLeft = meeleWeapon.durabilityLeft;
	}

	public override void Use () {
		durabilityLeft--;
	}

	public override void UseVisualisation () {
	}
}
