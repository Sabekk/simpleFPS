using UnityEngine;

public class GunWeapon : Weapon {
	[SerializeField] protected GunData gunData;
	[SerializeField] ParticleSystem shotParticle;
	[SerializeField] string holeEffect;
	public override Type WeaponType => Type.gun;
	public override string WeaponName => gunData.weaponName;
	public override float Damage => gunData.basicDamage;
	public override float AttackRange => gunData.range;
	public override bool CanBeUsed => actualState == State.none && bulletsLeft > 0;
	public override MaterialData.Type IntendedType => gunData.intendedType;
	public string HoleEffect => holeEffect;
	int Magazine => gunData.magazine;

	int ammunitionLeft;
	int bulletsLeft;
	float timer;

	public override void Initialize () {
		bulletsLeft = gunData.magazine;
		ammunitionLeft = gunData.maxAmmountOfBullets;
	}

	public override void Tick () {
		base.Tick ();

		switch (actualState) {
			case State.onUse:
			timer += Time.deltaTime;
			if (timer >= gunData.timeBetweenShots) {
				timer = 0;
				actualState = State.none;
			}
			break;
			case State.specialAction:
			timer += Time.deltaTime;
			if (timer >= gunData.reloadTime) {
				timer = 0;
				actualState = State.none;
				OnReloaded ();
			}
			break;
			default:
			break;
		}
	}

	public override void Use () {
		bulletsLeft--;
		Debug.Log (WeaponName + " used, Bullets in magazine left: " + bulletsLeft + "/" + Magazine);
		shotParticle.Play ();
		actualState = State.onUse;
	}

	public override void OnUnequip () {
		base.OnUnequip ();
		timer = 0;
	}

	public override void SetStatistics (Weapon weapon) {
		if (weapon is GunWeapon gunWeapon) {
			bulletsLeft = gunWeapon.bulletsLeft;
			ammunitionLeft = gunWeapon.ammunitionLeft;
		}
	}

	public void StartReload () {
		if (ammunitionLeft == 0)
			return;
		timer = 0;
		actualState = State.specialAction;
	}

	void OnReloaded () {
		int bulletsCount = 0;
		if (ammunitionLeft - (Magazine - bulletsLeft) > 0)
			bulletsCount = Magazine - bulletsLeft;
		else
			bulletsCount = ammunitionLeft;

		ammunitionLeft -= bulletsCount;
		bulletsLeft += bulletsCount;
	}
}
