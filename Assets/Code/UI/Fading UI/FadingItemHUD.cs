using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CanvasGroup))]
public abstract class FadingItemHUD : MonoBehaviour, ObjectPool.IPoolable {
	[SerializeField] protected float liveTime = 10;
	[SerializeField] float fadeTime = 3;
	float PercentageFade => timer / fadeTime;
	CanvasGroup canvas;
	protected float timer;
	public ObjectPool.PoolObject Poolable { get; set; }

	private void Awake () {
		canvas = GetComponent<CanvasGroup> ();
	}

	private void Update () {
		OnUpdate ();
	}


	public virtual void Initiliaze () {
		transform.localPosition = Vector3.zero;
		timer = liveTime;
		canvas.alpha = 1;
	}

	public virtual void OnUpdate () {
		timer -= Time.deltaTime;
		if (timer <= 0)
			Dispose ();
		else {
			if (timer <= fadeTime)
				canvas.alpha = PercentageFade;
			transform.LookAt (MainCamera.Instance.Camera.transform);
		}
	}

	public abstract void Dispose ();

	public void AssignPoolable (ObjectPool.PoolObject poolable) {
		Poolable = poolable;
	}
}
