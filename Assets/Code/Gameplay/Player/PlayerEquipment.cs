using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {
	[SerializeField] Transform handle;
	int maxWeapons = 5;
	Dictionary<int, Weapon> weapons;
	Weapon equipedWeapon;
	int currentWeaponId;

	private void Awake () {
		weapons = new Dictionary<int, Weapon> ();
		Events.Gameplay.Eq.OnAddWeapon += AddWeapon;
		Events.Gameplay.Eq.OnSwitchWeapon += SetCurrentWeapon;
		Events.Gameplay.Eq.OnSwitchToNextWeapon += SwitchToNextWeapon;
		Events.Gameplay.Eq.OnSwitchToPreviousWeapon += SwitchToPreviousWeapon;
	}

	private void OnDestroy () {
		Events.Gameplay.Eq.OnAddWeapon -= AddWeapon;
		Events.Gameplay.Eq.OnSwitchWeapon -= SetCurrentWeapon;
		Events.Gameplay.Eq.OnSwitchToNextWeapon -= SwitchToNextWeapon;
		Events.Gameplay.Eq.OnSwitchToPreviousWeapon -= SwitchToPreviousWeapon;
	}
	bool CanAddNewWeapon (out int emptyId) {
		for (int i = 0; i < maxWeapons; i++) {
			if (!weapons.ContainsKey (i) || weapons[i] == null) {
				emptyId = i;
				return true;
			}
		}
		emptyId = -1;
		return false;
	}
	void AddWeapon (Weapon weapon) {
		if (!CanAddNewWeapon (out int emptySlot))
			return;

		if (emptySlot >= 0) {
			weapons[emptySlot] = weapon;
			if (equipedWeapon == null) {
				EquipWeapon (weapon);
				currentWeaponId = emptySlot;
			} else
				ObjectPool.Instance.ReturnToPool (weapon);
		}
	}
	void RemoveWeapon (Weapon weapon) {

	}

	void EquipWeapon (Weapon weapon) {
		equipedWeapon = weapon;
		equipedWeapon.transform.SetParent (handle);
		equipedWeapon.OnEquip ();
	}
	void UnequipWeapon () {
		if (equipedWeapon) {
			equipedWeapon.OnUnequip ();
			ObjectPool.Instance.ReturnToPool (equipedWeapon);
		}
	}
	void SwitchWeapon () {
		UnequipWeapon ();
		weapons.TryGetValue (currentWeaponId, out Weapon weapon);
		if (weapon) {
			Weapon newWeapon = ObjectPool.Instance.GetFromPool (weapon.Poolable.name).GetComponent<Weapon> ();
			newWeapon.SetStatistics (weapon);
			weapons[currentWeaponId] = newWeapon;
			EquipWeapon (newWeapon);
		}
	}
	void SetCurrentWeapon (int id) {
		currentWeaponId = id;
		SwitchWeapon ();
	}
	void SwitchToNextWeapon () {
		currentWeaponId++;
		if (currentWeaponId > maxWeapons - 1)
			currentWeaponId = 0;
		SwitchWeapon ();
	}
	void SwitchToPreviousWeapon () {
		currentWeaponId--;
		if (currentWeaponId < 0)
			currentWeaponId = maxWeapons - 1;
		SwitchWeapon ();
	}
}
