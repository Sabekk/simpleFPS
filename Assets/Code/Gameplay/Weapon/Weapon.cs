using UnityEngine;

public abstract class Weapon : MonoBehaviour, ObjectPool.IPoolable {
	public abstract string WeaponName { get; }
	public abstract bool CanBeUsed { get; }
	public abstract float Damage { get; }
	public abstract float AttackRange { get; }
	public abstract MaterialData.Type IntendedType { get; }
	public ObjectPool.PoolObject Poolable { get; set; }
	protected bool readyToUse;

	private void Update () {
		Tick ();
	}

	public abstract void Initialize ();
	public abstract void SetStatistics (Weapon weapon);
	public abstract void Use ();
	public virtual void Tick () {

	}
	public virtual void OnEquip () {
		readyToUse = true;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public virtual void OnUnequip () {
		readyToUse = false;
	}

	public void AssignPoolable (ObjectPool.PoolObject poolable) {
		Poolable = poolable;
	}
}
