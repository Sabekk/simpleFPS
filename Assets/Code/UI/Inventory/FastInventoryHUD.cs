using System.Collections.Generic;
using UnityEngine;

public class FastInventoryHUD : MonoBehaviour {
	[SerializeField] List<SlotPosition> slots;

	private void Awake () {

		foreach (var slot in slots) {
			slot.slot.Initialize ();
		}

		Events.Gameplay.Equipment.OnAddedNewWeapon += OnAddedNewWeapon;
		Events.Gameplay.Equipment.OnItemEquiped += OnItemEquiped;
	}
	private void OnDestroy () {
		Events.Gameplay.Equipment.OnAddedNewWeapon -= OnAddedNewWeapon;
		Events.Gameplay.Equipment.OnItemEquiped -= OnItemEquiped;
	}
	void OnAddedNewWeapon (Weapon weapon, int id) {
		foreach (var slot in slots) {
			if (slot.id == id)
				slot.slot.SetImage (weapon != null ? weapon.ItemSprite : null);
		}
	}

	void OnItemEquiped (Item item, int id) {
		foreach (var slot in slots) {
			slot.slot.Select (slot.id == id);
		}
	}
	[System.Serializable]
	struct SlotPosition {
		public int id;
		public FastItemSlot slot;
	}
}
