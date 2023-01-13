using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    private Transform _transform;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        speed = Random.RandomRange(0.01f, 0.06f);
        _transform.position = new Vector3(_transform.position.x, Random.RandomRange(_transform.position.y - 0.5f, _transform.position.y + 0.5f), _transform.position.z);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,Random.RandomRange(0.4f,0.8f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _transform.position += Vector3.left * Time.deltaTime * speed;
        if (_transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }

}
