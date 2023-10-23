using UnityEngine;

public abstract class Item : MonoBehaviour
{
	public abstract string ItemName { get; }
	public abstract Sprite ItemSprite { get; }
}
