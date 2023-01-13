using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branches : MonoBehaviour
{
    public GameObject targetManager;
    private List<GameObject> target;
    public bool selectBrunches;
    public Transform targetTransform; 

    void Start()
    {
        targetManager = GameObject.Find("TargetManager");
        target = targetManager.GetComponent<TargetManager>().targetTree;
        target.Add(gameObject);

    }

    private void FixedUpdate()
    {
        if (selectBrunches == true) {
            SelectBranches();
        }
    }

    public void SelectBranches() {
        transform.position = new Vector3(targetTransform.position.x, 0, transform.position.z);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building_forester") {
            target.Remove(gameObject);
            target.RemoveAt(0);
            Destroy(gameObject);
        }
    }

}
