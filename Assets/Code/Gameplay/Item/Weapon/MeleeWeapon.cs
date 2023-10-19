using UnityEngine;

public class MeleeWeapon : Weapon {
	[SerializeField] protected MeleeWeaponData meleeData;
	float durabilityLeft;
	public override Type WeaponType => Type.melee;
	public override string ItemName => meleeData.itemName;
	public override Sprite ItemSprite => meleeData.itemSprite;
	public override bool CanBeUsed => durabilityLeft > 0;
	public override float Damage => meleeData.basicDamage;
	public override float AttackRange => 0;
	public override MaterialData.Type IntendedType => meleeData.intendedType;


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
		Debug.Log (ItemName + " used, Durability left: " + durabilityLeft + "/" + MaxDurability);
	}
}
