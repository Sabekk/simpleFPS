using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IDamageable {
	[SerializeField] MaterialData materialData;

	List<ActionAfterDeath> actions;
	MaterialData.Type materialType;
	float durability;
	public MaterialData.Type Type => materialType;
	public float Durability {
		get { return durability; }
		set { durability = value; }
	}
	private void Awake () {
		Initialize ();

		actions = new List<ActionAfterDeath> ();
		actions.AddRange (GetComponents<ActionAfterDeath> ());
	}

	private void OnDestroy () {
		OnDestroyProp ();
		actions.Clear ();
	}
	public void Initialize () {
		if (materialData) {
			materialType = materialData.type;
			durability = materialData.durability;
		} else {
			materialType = MaterialData.Type.wood;
			durability = 1;
		}
	}
	public void OnDestroyProp () {
		foreach (var action in actions) {
			action.Activate ();
		}
	}

	public void TakeDamage (float damage, MaterialData.Type type) {
		if (type != 0 && (type & materialType) == 0)
			return;

		Durability -= damage;
		Debug.Log (Durability);
		if (Durability < 0)
			Destroy (gameObject);
	}
}
