using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable {
	public float Health { get; set; }
	public float MaxHealth { get; }
	public bool IsAlive { get; }
	public void TakeDamage (float damage);
	public void Kill ();
}
