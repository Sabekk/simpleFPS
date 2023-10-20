using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMark : PoolableEffect {
	Target parent;
	private void OnEnable () {
		parent = null;
	}
	protected override void OnEffectFinish () {
		if (parent)
			parent.RemoveMark (this);
	}
	public void SetTargetParent (Target target) {
		parent = target;
		transform.SetParent (parent.transform);
	}
}
