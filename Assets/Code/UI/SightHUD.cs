using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightHUD : MonoBehaviour {
	[SerializeField] Image sight;
	private void Awake () {
		Events.Gameplay.Eq.OnItemEquiped += OnItemEquiped;
	}
	private void OnDestroy () {
		Events.Gameplay.Eq.OnItemEquiped -= OnItemEquiped;
	}
	void OnItemEquiped (Item item, int id) {
		if (item is Weapon weapon) {
			sight.gameObject.SetActive (true);
			Sprite newAim = SpriteContainer.Instance.FindSprite (weapon.Aim);
			if (newAim)
				sight.sprite = newAim;
			else
				sight.gameObject.SetActive (false);
		} else
			sight.gameObject.SetActive (false);
	}
}
