using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceController : MonoBehaviour
{
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }


    public void MoveFenceToWall()
    {
        Vector2 _leftCheck = new Vector2(_transform.position.x - 0.15f, _transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(_leftCheck, Vector2.left);
        float distanceHit=0;

        Vector2 _rightCheck = new Vector2(_transform.position.x + 0.18f, _transform.position.y);
        RaycastHit2D hit2 = Physics2D.Raycast(_rightCheck, -Vector2.left);
        float distanceHit2 = 0;

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Building")
            {
                distanceHit = Vector2.Distance(_leftCheck, hit.collider.transform.position);
            }
        }

        if (hit2.collider != null)
        {
            if (hit.collider.tag == "Building")
            {
                distanceHit2 = Vector2.Distance(_rightCheck, hit2.collider.transform.position);
            }
        }

        Debug.Log(distanceHit +" AND "+ distanceHit2);

        if (distanceHit < distanceHit2)
        {
            if (_transform.position.x < 0)
            {
                _transform.position = new Vector3(_transform.position.x + distanceHit, _transform.position.y, _transform.position.z);
            }
            else {
                _transform.position = new Vector3(_transform.position.x - distanceHit, _transform.position.y, _transform.position.z);
            }
        }
        else {
            _transform.position = new Vector3(_transform.position.x - distanceHit2, _transform.position.y, _transform.position.z);
        }
    }


}
