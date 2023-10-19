using UnityEngine;

public class ChangeObjectAfterDeath : ActionAfterDeath {
	[SerializeField] string newObjectName = "prop_brokenBarrel";
	public override void Activate () {
		Transform newObject = ObjectPool.Instance.GetFromPool (newObjectName).GetComponent<Transform> ();
		if (newObject != null) {
			newObject.SetParent (transform.parent);
			newObject.position = transform.position;
			newObject.rotation = transform.rotation;
			newObject.localScale = transform.localScale;
		}
	}
}
