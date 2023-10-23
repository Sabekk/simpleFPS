using System.Collections;
using UnityEngine;

public class MainCamera : MonoSingleton<MainCamera>
{
	Camera camera;
	public Camera Camera => camera;
	protected override void Awake () {
		base.Awake ();
		camera = GetComponent<Camera> ();
	}
}
