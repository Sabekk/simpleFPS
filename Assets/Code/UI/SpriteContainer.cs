using UnityEngine;

[CreateAssetMenu (fileName = "SpriteContainer", menuName = "Containers/SpriteContainer")]
public class SpriteContainer : ScritableSingleton<SpriteContainer> {
	[SerializeField] SpriteKey[] sprites;

	public Sprite FindSprite (string key) {
		foreach (var sprite in sprites) {
			if (sprite.name == key)
				return sprite.sprite;
		}
		return null;
	}

	[System.Serializable]
	struct SpriteKey {
		public string name;
		public Sprite sprite;
	}
}
