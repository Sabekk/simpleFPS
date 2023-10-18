using UnityEngine;

public class GunWeapon : Weapon {
	[SerializeField] protected GunData gunData;
	[SerializeField] ParticleSystem shotParticle;
	[SerializeField] string holeEffect;
	public override Type WeaponType => Type.gun;
	public override string WeaponName => gunData.weaponName;
	public override float Damage => gunData.basicDamage;
	public override float AttackRange => gunData.range;
	public override bool CanBeUsed => readyToUse && bulletsLeft > 0;
	public override MaterialData.Type IntendedType => gunData.intendedType;
	public string HoleEffect => holeEffect;
	float MaxAmmo => gunData.maxAmmountOfBullets;
	float Magazine => gunData.magazine;


	float bulletsLeft;
	float timer;
	bool reloading;

	public override void Initialize () {
		bulletsLeft = gunData.magazine;
	}

	public override void Tick () {
		base.Tick ();
		if (!readyToUse) {
			timer += Time.deltaTime;
			if (timer >= gunData.timeBetweenShots) {
				timer = 0;
				readyToUse = true;
			}
		}
	}

	public override void Use () {
		bulletsLeft--;
		Debug.Log (WeaponName + " used, Bullets in magazine left: " + bulletsLeft + "/" + Magazine);
		shotParticle.Play ();
		readyToUse = false;
	}

	public override void OnUnequip () {
		base.OnUnequip ();
	}

	public override void SetStatistics (Weapon weapon) {
		if (weapon is GunWeapon gunWeapon)
			bulletsLeft = gunWeapon.bulletsLeft;
	}

	public void Reload () {
		reloading = true;
	}
}
