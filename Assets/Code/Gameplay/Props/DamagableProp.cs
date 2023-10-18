using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableProp : Target, IDamagable {
	[SerializeField] MaterialData materialData;
	List<ActionAfterDeath> actions;
	float durability;

	public float Durability {
		get { return durability; }
		set { durability = value; }
	}

	public override MaterialData.Type MaterialType => materialData != null ? materialData.type : MaterialData.Type.wood;

	public override bool Markable => Durability > 0;

	private void Awake () {
		Initialize ();

		actions = new List<ActionAfterDeath> ();
		actions.AddRange (GetComponents<ActionAfterDeath> ());
	}

	public void Initialize () {
		if (materialData) {
			durability = materialData.durability;
		} else {
			durability = 1;
		}
	}
	public void OnDestroyProp () {

	}

	public void TakeDamage (float damage, MaterialData.Type type) {
		if (type != 0 && (type & MaterialType) == 0)
			return;

		Durability -= damage;
		Debug.Log (Durability);
		if (Durability < 0)
			Death ();
	}

	public void Death () {
		ReturnAllMarks ();
		foreach (var action in actions) {
			action.Activate ();
		}

		Destroy (gameObject);
	}
}
