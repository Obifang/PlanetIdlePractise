using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float RotationSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            RotateBasedOnMouseMovement();
        }
    }

    public void RotateBasedOnMouseMovement()
    {
        var mouseAxis = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X")) * RotationSpeed * Time.deltaTime;
        transform.Rotate(mouseAxis, Space.World);
    }
}
