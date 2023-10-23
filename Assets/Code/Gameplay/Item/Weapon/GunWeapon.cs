using UnityEngine;

public class GunWeapon : Weapon {
	[SerializeField] ParticleSystem shotParticle;

	GunData gunData;
	int ammunitionLeft;
	int bulletsLeft;
	float timer;
	string shootingAnimation;

	public override string UsingAnimation => shootingAnimation;
	public override Type WeaponType => Type.gun;
	public override bool CanBeUsed => actualState == State.none && bulletsLeft > 0;
	public string BulletsLeft => bulletsLeft.ToString ();
	public string Magazine => gunData.magazine.ToString ();
	public string AmmunitionLeft => ammunitionLeft.ToString ();
	public int MagazineValue => gunData.magazine;
	public bool NeedReload => bulletsLeft < MagazineValue;

	public override float SpecialActionPercentage {
		get {
			if (actualState == State.specialAction) {
				return timer / gunData.reloadTime;
			} else
				return 0;
		}
	}

	public override void Initialize () {
		if (weaponData is GunData gunData) {
			this.gunData = gunData;
			bulletsLeft = gunData.magazine;
			ammunitionLeft = gunData.maxAmmountOfBullets;

			shootingAnimation = GameplayManager.GetWeaponUsingTrigger (gunData.weaponSize);
		} else
			Debug.LogWarning ("Weapon wrong initialized! Check assigned data", this);
	}

	public override void Tick () {
		base.Tick ();

		switch (actualState) {
			case State.onUse:
			timer += Time.deltaTime;
			if (timer >= TimeBetweenAttacks) {
				timer = 0;
				actualState = State.none;
			}
			break;
			case State.specialAction:
			timer += Time.deltaTime;
			Events.Gameplay.Weapon.OnUpdateSpecialAction.Invoke (SpecialActionPercentage);
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
		actualState = State.onUse;
		Events.UI.ItemPreview.OnRefreshItemPreview.Invoke (this);
	}
	public override void UseVisualisation () {
		shotParticle.Play ();
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

		Events.Gameplay.Weapon.OnReloaded.Invoke ();
		Events.UI.ItemPreview.OnRefreshItemPreview.Invoke (this);
	}
}
