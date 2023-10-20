using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable {
	public float Health { get; set; }
	public bool IsAlive { get; }
	public void TakeDamage (float damage, MaterialData.Type type);
	public void Kill ();
}
