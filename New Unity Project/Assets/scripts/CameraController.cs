using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	public float zoomSpeed = 2f;
	public bool firstPerson;

	public float mouseSensitivity = 2f;

	public Vector3 rotation = new Vector3(0,0,0);

	void Start () {
		offset = transform.position-player.transform.position;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}else if (Input.GetKeyDown (KeyCode.E)) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		float dc = Input.GetAxis ("Mouse ScrollWheel");
		offset = offset * ((dc > 0) ? 1/zoomSpeed : (dc < 0) ? zoomSpeed : 1f);

		if (offset.magnitude < 5) {
			firstPerson = true;
		}else
			firstPerson = false;

		float dx = Input.GetAxis ("Mouse X");
		rotation.y += dx * mouseSensitivity;
		float dy = Input.GetAxis ("Mouse Y");
		rotation.x += Mathf.Abs(Mathf.Cos (rotation.y)) * -dy * mouseSensitivity;
		rotation.z += Mathf.Sin (rotation.y) * dy * mouseSensitivity;
	}

	void LateUpdate(){
		if (!firstPerson) {
			transform.position = player.transform.position + offset;
			transform.LookAt (player.transform.position);
		} else {
			transform.position = player.transform.position;
			transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z+1));
			transform.Rotate (rotation.x, rotation.y, 0);
			//transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z+1));
		}
		//transform.rotation = new Quaternion (transform.rotation.x, player.transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
}
