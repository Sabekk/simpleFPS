using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable {
	public void TakeDamage (float damage, MaterialData.Type type);
	public void Kill ();
}
