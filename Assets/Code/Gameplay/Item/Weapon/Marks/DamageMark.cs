using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMark : MonoBehaviour,ObjectPool.IPoolable
{
	Target parent;
	public ObjectPool.PoolObject Poolable { get; set; }

	private void OnParticleSystemStopped () {
		parent.RemoveMark (this);
		ObjectPool.Instance.ReturnToPool (this);
	}

	public void SetTargetParent (Target target) {
		parent = target;
		transform.SetParent (parent.transform);
	}
	public void AssignPoolable (ObjectPool.PoolObject poolable) {
		Poolable = poolable;
		parent = null;
	}

}
