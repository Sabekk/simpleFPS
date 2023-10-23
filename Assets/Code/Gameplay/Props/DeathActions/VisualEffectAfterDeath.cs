using UnityEngine;

public class VisualEffectAfterDeath : ActionAfterDeath {
	[SerializeField] string effectName = "effect_explode";
	public override void Activate () {
		var effect = ObjectPool.Instance.GetFromPool (effectName);
		if (effect != null) {
			effect.prefab.transform.SetParent (null);
			effect.prefab.transform.position = transform.position;
		}
	}
}