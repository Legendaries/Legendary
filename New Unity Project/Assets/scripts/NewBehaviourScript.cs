using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public Rigidbody rb;
	public float speed = 20f;
	public Vector3 rotation;
	public CameraController mainCam;
	public GameObject emitter;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rotation = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		float test = Input.GetAxis ("Fire1");
		if (test == 1) {
			GameObject t = Instantiate (bullet);
			t.transform.position = transform.position + mainCam.transform.forward*2;
			if(mainCam.firstPerson){
				t.GetComponent<Rigidbody>().AddForce(100*mainCam.transform.forward);
			} else {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit)){
					t.GetComponent<Rigidbody>().AddForce(100*(hit.point-transform.position).normalized);
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce (new Vector3(0, 750, 0));
		}
		if (mainCam.firstPerson) {
			//print (Mathf.Abs(Mathf.Sin (mainCam.rotation.y/180*Mathf.PI)) * moveY * speed);
			rb.AddForce (mainCam.transform.forward * moveY * speed);
			rb.AddForce (mainCam.transform.right * moveX * speed);
		} else {
			rb.AddForce (new Vector3 (moveX * speed, 0, moveY * speed));
		}
		emitter.transform.rotation = Quaternion.Euler(mainCam.transform.rotation.eulerAngles * -1);
	}
}
