using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {
	[SerializeField] Transform handle;
	int maxWeapons = 5;
	Dictionary<int, Weapon> weapons;
	Weapon equipedWeapon;
	int currentWeaponId;

	public Weapon EquipedWeapon => equipedWeapon;

	private void Awake () {
		weapons = new Dictionary<int, Weapon> ();
		Events.Gameplay.Equipment.OnInitializeStartingWeapon += AddWeapon;
		Events.Gameplay.Equipment.OnSwitchWeapon += SetCurrentWeapon;
		Events.Gameplay.Equipment.OnSwitchToNextWeapon += SwitchToNextWeapon;
		Events.Gameplay.Equipment.OnSwitchToPreviousWeapon += SwitchToPreviousWeapon;
	}

	private void OnDestroy () {
		Events.Gameplay.Equipment.OnInitializeStartingWeapon -= AddWeapon;
		Events.Gameplay.Equipment.OnSwitchWeapon -= SetCurrentWeapon;
		Events.Gameplay.Equipment.OnSwitchToNextWeapon -= SwitchToNextWeapon;
		Events.Gameplay.Equipment.OnSwitchToPreviousWeapon -= SwitchToPreviousWeapon;
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
			Events.Gameplay.Equipment.OnAddedNewWeapon.Invoke (weapon, emptySlot);
		}
	}
	void RemoveWeapon (Weapon weapon) {

	}

	void EquipWeapon (Weapon weapon) {
		equipedWeapon = weapon;
		if (weapon) {
			equipedWeapon.transform.SetParent (handle);
			equipedWeapon.OnEquip ();
		}
		Events.Gameplay.Equipment.OnItemEquiped.Invoke (weapon, currentWeaponId);
		Events.UI.ItemPreview.OnRefreshItemPreview.Invoke (weapon);
	}
	void UnequipWeapon () {
		if (equipedWeapon) {
			equipedWeapon.OnUnequip ();
			ObjectPool.Instance.ReturnToPool (equipedWeapon);
			equipedWeapon = null;
			Events.Gameplay.Weapon.OnUpdateSpecialAction.Invoke (-1);
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
		} else {
			EquipWeapon (null);
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
