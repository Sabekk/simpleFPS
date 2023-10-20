using UnityEngine;

public abstract class Weapon : Item, ObjectPool.IPoolable {
	public enum State { none, blocked, onUse, specialAction };
	public enum Type { melee, gun };

	[SerializeField] protected WeaponData weaponData;

	protected State actualState;
	public override string ItemName => weaponData.itemName;
	public override Sprite ItemSprite => weaponData.itemSprite;
	public abstract Type WeaponType { get; }
	public abstract string UsingAnimation { get; }
	public abstract bool CanBeUsed { get; }
	public virtual MaterialData.Type IntendedType => weaponData.intendedType;
	public virtual float Damage => weaponData.basicDamage;
	public virtual float AttackRange => weaponData.attackRange;
	public virtual float TimeBetweenAttacks => weaponData.timeBetweenAttack;
	public virtual string Aim => weaponData.aim;
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
