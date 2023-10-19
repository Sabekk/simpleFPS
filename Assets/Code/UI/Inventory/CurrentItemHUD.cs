using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentItemHUD : MonoBehaviour {
	[SerializeField] TMP_Text itemName;
	[SerializeField] TMP_Text bulletsLeft;
	[SerializeField] TMP_Text magazine;
	[SerializeField] TMP_Text ammunitionLeft;
	[SerializeField] GameObject weaponInformations;
	[SerializeField] GameObject additionalInformations;

	private void Awake () {
		Events.UI.ItemPreview.OnRefreshItemPreview += RefreshPreview;
	}
	private void OnDestroy () {
		Events.UI.ItemPreview.OnRefreshItemPreview -= RefreshPreview;
	}
	void RefreshPreview (Item item) {
		if (item == null) {
			gameObject.SetActive (false);
			return;
		} else {
			gameObject.SetActive (true);
			itemName.text = item.ItemName;
		}
		
		if (item is Weapon weapon) {
			switch (weapon.WeaponType) {
				case Weapon.Type.melee:
				RefreshText (weapon as MeleeWeapon);
				break;
				case Weapon.Type.gun:
				RefreshText (weapon as GunWeapon);
				break;
				default:
				break;
			}
		} else {
			weaponInformations.SetActive (false);
		}
	}

	void RefreshText (GunWeapon weapon) {
		weaponInformations.SetActive (true);
		additionalInformations.SetActive (true);
		bulletsLeft.text = weapon.BulletsLeft;
		magazine.text = weapon.Magazine;
		ammunitionLeft.text = weapon.AmmunitionLeft;
	}
	void RefreshText (MeleeWeapon weapon) {

	}
}
