using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    public float speed;
    private Transform _transform;
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.A)) {
            if (_transform.position.x > -17)
            {
                _transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (_transform.position.x < 17) {
                _transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (_transform.position.y < 1f )
            {
                _transform.position += Vector3.up * Time.deltaTime * speed;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (_transform.position.y > -0.7f)
            {
                _transform.position += Vector3.down * Time.deltaTime * speed;
            }
        }
    }
}
