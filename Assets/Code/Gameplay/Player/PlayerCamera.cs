using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] Transform playerBody;

    float xDir;
    float yDir;
    float xRotation;
	private void Awake () {
        Events.Gameplay.Move.OnLookInDirection += LookInDirection;
    }
	private void OnDestroy () {
        Events.Gameplay.Move.OnLookInDirection -= LookInDirection;
    }
	private void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	private void Update () {
        float mouseX = xDir * Time.deltaTime * sensX;
        float mouseY = yDir * Time.deltaTime * sensY;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp (xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler (xRotation, 0f, 0f);
        playerBody.Rotate (Vector3.up * mouseX);
	}

    void LookInDirection(Vector2 direction) {
        xDir = direction.x;
        yDir = direction.y;
	}
}
