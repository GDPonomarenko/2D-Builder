using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetTransform;
    private Transform _transform;
    public Transform parallaxLayer1, parallaxLayer2, parallaxLayer3;
    public Transform water;
    public float p1, p2, p3;


    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime*3);
        parallaxLayer1.position = new Vector3(-transform.position.x/p1, parallaxLayer1.position.y, parallaxLayer1.position.z);
        parallaxLayer2.position = new Vector3(-transform.position.x /p2, parallaxLayer2.position.y, parallaxLayer2.position.z);
        parallaxLayer3.position = new Vector3(-transform.position.x / p3, parallaxLayer3.position.y, parallaxLayer3.position.z);
        water.position = new Vector3(transform.position.x, water.position.y, water.position.z);
    }
}
