using UnityEngine;

public class ChangeObjectAfterDeath : ActionAfterDeath {
	[SerializeField] ReplacementObject[] replacements;
	public override void Activate () {
		foreach (var replacement in replacements) {
			for (int i = 0; i < replacement.count; i++) {
				Transform newObject = ObjectPool.Instance.GetFromPool (replacement.name).GetComponent<Transform> ();
				if (newObject != null) {
					newObject.SetParent (transform.parent);
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
	[System.Serializable]
	struct ReplacementObject {
		public string name;
		public int count;
		public bool copyScale;
		public float scale;
	}

}
