using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableProp : Target, IDamagable {
	[SerializeField] MaterialData materialData;
	List<ActionAfterDeath> actions;
	float durability;
	public override MaterialData.Type MaterialType => materialData != null ? materialData.type : MaterialData.Type.wood;

	public override bool Markable => durability > 0;

	public float Health {
		get { return durability; }
		set { durability = value; }
	}

	public bool IsAlive => Health > 0;

	private void Awake () {
		Initialize ();

		actions = new List<ActionAfterDeath> ();
		actions.AddRange (GetComponents<ActionAfterDeath> ());
	}

	public void Initialize () {
		Health = materialData ? materialData.durability : 1;
	}

	public void TakeDamage (float damage, MaterialData.Type type) {
		if (type != 0 && (type & MaterialType) == 0)
			return;

		Health -= damage;
		if (Health < 0)
			Kill ();
	}

	public void Kill () {
		ReturnAllMarks ();
		foreach (var action in actions) 
			action.Activate ();
		
		Destroy (gameObject);
	}
}
