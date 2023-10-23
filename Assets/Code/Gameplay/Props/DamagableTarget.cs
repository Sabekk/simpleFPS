using System.Collections.Generic;
using UnityEngine;

public class DamagableTarget : Target, IDamagable {
	[SerializeField] MaterialData materialData;
	[SerializeField] bool useHealthBar = true;

	HealthBarHUD healthBar;
	List<ActionAfterDeath> actions;
	float maxDurability;
	float durability;
	public override MaterialData.Type MaterialType => materialData != null ? materialData.type : MaterialData.Type.wood;
	public override bool Markable => durability > 0;
	public override bool ShowHitValue => true;

	public float Health {
		get { return durability; }
		set { durability = value; }
	}
	public float MaxHealth => maxDurability;
	public bool IsAlive => Health > 0;
	const string HEALTH_BAR = "HUD_healthBar";


	private void Awake () {
		Initialize ();

		actions = new List<ActionAfterDeath> ();
		actions.AddRange (GetComponents<ActionAfterDeath> ());
		Events.UI.SliderPreview.OnSliderRemoved += OnSliderRemoved;
	}

	void OnKill () {
		ReturnAllMarks ();
		foreach (var action in actions)
			action.Activate ();
		if (useHealthBar && healthBar)
			healthBar.Dispose ();
		Events.UI.SliderPreview.OnSliderRemoved -= OnSliderRemoved;
	}
	public void Initialize () {
		Health = materialData ? materialData.durability : 1;
		maxDurability = Health;
	}

	public void TakeDamage (float damage) {
		Health -= damage;
		if (useHealthBar) {
			if (!healthBar) {
				healthBar = ObjectPool.Instance.GetFromPool (HEALTH_BAR).GetComponent<HealthBarHUD> ();
				healthBar.Initiliaze ();
				healthBar.transform.SetParent (transform);
				healthBar.transform.localPosition = Vector3.zero;
			}

			healthBar.UpdateStatus (Health / MaxHealth);
		}

		if (Health < 0)
			Kill ();
	}

	public void Kill () {
		OnKill ();
		Destroy (gameObject);
	}
	void OnSliderRemoved (HealthBarHUD healthBar) {
		if (this.healthBar == healthBar)
			this.healthBar = null;
	}
}
