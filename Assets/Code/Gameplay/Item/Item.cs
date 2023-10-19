using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	public abstract string ItemName { get; }
	public abstract Sprite ItemSprite { get; }
}
