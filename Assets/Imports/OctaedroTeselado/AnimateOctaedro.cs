using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimateOctaedro : MonoBehaviour
{

    public float speed, speedLimit, rotationSpeed;
    public Vector3 axis, rotationAxis;
    public float mass;

    private CreateOctaedro octaedro;
    int iteration = 1, operation = 1;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(.1f, 3f);
        octaedro = GetComponent<CreateOctaedro>();
    }

    private void FixedUpdate()
    {
        //transform.RotateAround(sun.position, axis, speed);
        transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
    }


    
}
