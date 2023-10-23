using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, ObjectPool.IPoolable {
	[SerializeField] Image slotImage;
	[SerializeField] GameObject selection;

	public ObjectPool.PoolObject Poolable {get;set;}
	public void AssignPoolable (ObjectPool.PoolObject poolable) {
		Poolable = poolable;
	}
	
	public virtual void Initialize () {
		Select (false);
	}
    public virtual void SetImage(Sprite sprite) {
        slotImage.sprite = sprite;
	}
	public virtual void Select (bool isSelected) {
		selection.SetActive (isSelected);
	}
}
