using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectAfterDeath : ActionAfterDeath {
	[SerializeField] ReplacementObject[] replacements;
	BoxCollider objectCollider;

	private void Awake () {
		objectCollider = GetComponent<BoxCollider> ();
	}

	public override void Activate () {
		foreach (var replacement in replacements) {
			for (int i = 0; i < replacement.count; i++) {
				Transform newObject = ObjectPool.Instance.GetFromPool (replacement.name).GetComponent<Transform> ();
				if (newObject != null) {
					newObject.SetParent (transform.parent);
					if (replacement.randomPosition && objectCollider) {
						newObject.position = GetRandomPostion (objectCollider.bounds);
					} else
						newObject.position = transform.position + Vector3.up;
					newObject.rotation = transform.rotation;
					if (replacement.copyScale)
						newObject.localScale = transform.localScale;
					else
						newObject.localScale = Vector3.one * replacement.scale;
				}
			}
		}
	}

	Vector3 GetRandomPostion (Bounds bounds) {
		return new Vector3 (
			Random.Range (bounds.min.x, bounds.max.x),
			Random.Range (bounds.min.y, bounds.max.y),
			Random.Range (bounds.min.z, bounds.max.z));
	}

	[System.Serializable]
	struct ReplacementObject {
		public string name;
		public int count;
		public bool copyScale;
		public float scale;
		public bool randomPosition;
	}
}
