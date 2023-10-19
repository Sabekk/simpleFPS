using UnityEngine;

public class GunWeapon : Weapon {
	[SerializeField] protected GunData gunData;
	[SerializeField] ParticleSystem shotParticle;
	[SerializeField] string holeEffect;

	int ammunitionLeft;
	int bulletsLeft;
	float timer;

	public override Type WeaponType => Type.gun;
	public override string ItemName => gunData.itemName;
	public override Sprite ItemSprite => gunData.itemSprite;
	public override float Damage => gunData.basicDamage;
	public override float AttackRange => gunData.range;
	public override bool CanBeUsed => actualState == State.none && bulletsLeft > 0;
	public override MaterialData.Type IntendedType => gunData.intendedType;
	public string BulletsLeft => bulletsLeft.ToString ();
	public string Magazine => gunData.magazine.ToString ();
	public string AmmunitionLeft => ammunitionLeft.ToString ();
	public string HoleEffect => holeEffect;
	public int MagazineValue => gunData.magazine;

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
		shotParticle.Play ();
		actualState = State.onUse;
		Events.UI.ItemPreview.OnRefreshItemPreview.Invoke (this);
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
		if (ammunitionLeft - (MagazineValue - bulletsLeft) > 0)
			bulletsCount = MagazineValue - bulletsLeft;
		else
			bulletsCount = ammunitionLeft;

		ammunitionLeft -= bulletsCount;
		bulletsLeft += bulletsCount;

		Events.UI.ItemPreview.OnRefreshItemPreview.Invoke (this);
	}
}
