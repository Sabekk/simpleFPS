using UnityEngine;
using UnityEngine.UI;

public class SightHUD : MonoBehaviour {
	[SerializeField] Image sight;
	[SerializeField] GameObject actionTimer;
	[SerializeField] Image actionProgress;

	bool inSpecialAction = false;
	private void Awake () {
		Events.Gameplay.Equipment.OnItemEquiped += OnItemEquiped;
		Events.Gameplay.Weapon.OnUpdateSpecialAction += UpdateActionProgress;
	}
	private void Start () {
		actionTimer.gameObject.SetActive (inSpecialAction);
	}
	private void OnDestroy () {
		Events.Gameplay.Equipment.OnItemEquiped -= OnItemEquiped;
		Events.Gameplay.Weapon.OnUpdateSpecialAction -= UpdateActionProgress;
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

	void UpdateActionProgress (float percentage) {
		if (percentage < 0) {
			ToggleSpecialAction (false);
			return;
		}

		if (!inSpecialAction) {
			ToggleSpecialAction (true);
		}
			actionProgress.fillAmount = percentage;

		if (percentage >= 1) {
			ToggleSpecialAction (false);
		}
	}

	void ToggleSpecialAction(bool state) {
		inSpecialAction = state;
		actionTimer.SetActive (state);
		sight.gameObject.SetActive (!state);
	}
}
