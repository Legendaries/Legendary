using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;
    public float RotationSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
        void FixedUpdate()
    { 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveJump = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVertical);

        rb.AddForce(moveHorizontal*10,0,moveVertical*10);

         
	}
    void Update()
        {
            transform.Rotate((-1 * Input.GetAxis("Mouse Y") * Input.GetAxis("Mouse Y") * Input.GetAxis("Mouse Y")*RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * Input.GetAxis("Mouse X")*Input.GetAxis("Mouse X")*RotationSpeed * Time.deltaTime), 0, Space.World);
        }
}
