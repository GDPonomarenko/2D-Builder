using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _leftCheck, _rightCheck;
    public float wallWidth;
    public GameObject incideWall;
    private bool left;
    public List<GameObject> walls;
    private GameObject wallManager;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWallBetwen();
    }

    public void CheckWallBetwen() {
        HitRay();
    }

    public void HitRay() {
        _leftCheck = new Vector2(_transform.position.x - 0.1f, _transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(_leftCheck, Vector2.left*10);


        _rightCheck = new Vector2(_transform.position.x + 0.1f, _transform.position.y);
        RaycastHit2D hit2 = Physics2D.Raycast(_rightCheck, -Vector2.left*10);

        if (hit.collider != null && hit2.collider != null)
        {
            if ((hit.collider.tag == "Wall" || hit.collider.tag == "Fence") && (hit2.collider.tag == "Wall" || hit2.collider.tag == "Fence"))
            {
                ChacgeWall();
            }
        }
    }

    public void ChacgeWall() {
        Vector2 newPos = new Vector2(_transform.position.x, _transform.position.y - 0.1f);
        Instantiate(incideWall, newPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
