using UnityEngine;
using UnityEngine.Events;

public class ImpactForOthersAfterDeath : ActionAfterDeath {
	[SerializeField] UnityEvent impactEvent;
	public override void Activate () {
		impactEvent.Invoke ();
	}
}
