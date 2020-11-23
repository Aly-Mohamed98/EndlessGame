using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float yCamera;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > 7){
            yCamera = target.position.y - 1;
        }
        else {
            yCamera = target.position.y + 1;
        }
        Vector3 newPosition = new Vector3(transform.position.x, yCamera, offset.z + target.position.z);
        transform.position = newPosition;        
    }
}
