using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float RotationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), 0, Space.World);
    }
}