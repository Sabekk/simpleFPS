using UnityEngine;

public abstract class Weapon : MonoBehaviour, ObjectPool.IPoolable {
	public enum State { none, blocked, onUse, specialAction };
	public enum Type { melee, gun };
	protected State actualState;
	public abstract Type WeaponType { get; }
	public abstract string WeaponName { get; }
	public abstract bool CanBeUsed { get; }
	public abstract float Damage { get; }
	public abstract float AttackRange { get; }
	public abstract MaterialData.Type IntendedType { get; }
	public ObjectPool.PoolObject Poolable { get; set; }

	private void Update () {
		Tick ();
	}

	public abstract void Initialize ();
	public abstract void SetStatistics (Weapon weapon);
	public abstract void Use ();
	public virtual void Tick () {

	}
	public virtual void OnEquip () {
		actualState = State.none;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public virtual void OnUnequip () {
		actualState = State.blocked;
	}

	public void AssignPoolable (ObjectPool.PoolObject poolable) {
		Poolable = poolable;
	}

	public virtual void MakeMark (MaterialData.Type materialType, Vector3 point, Quaternion rotation, out DamageMark mark) {
		mark = null;
		string markName = GameplayManager.GetPropMarkName (WeaponType, materialType);
		if (!string.IsNullOrEmpty (markName)) {
			mark = ObjectPool.Instance.GetFromPool (markName).GetComponent<DamageMark> ();
			if (mark != null) {
				mark.transform.position = point;
				mark.transform.rotation = rotation;
			}
		}
	}
}
