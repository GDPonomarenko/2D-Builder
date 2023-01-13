using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceController : MonoBehaviour
{
    public GameObject prefabs;
    private Vector3 mousePositionOffset;
    public float setSize;
    private bool canBuild;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        mousePositionOffset = GetMouseWorldPosition();
        transform.localScale = new Vector3(setSize, transform.localScale.y, transform.localScale.z);
        audioSource = GetComponent<AudioSource>();
        canBuild = true;
    }
    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        mousePositionOffset = GetMouseWorldPosition();
        transform.position = new Vector3(mousePositionOffset.x, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canBuild == true) {
            audioSource.Play();
            Instantiate(prefabs, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building" || collision.gameObject.tag == "Building_forester" || collision.gameObject.tag == "Tree" || collision.gameObject.tag == "Wall")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.2f);
            canBuild = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building" || collision.gameObject.tag == "Building_forester" || collision.gameObject.tag == "Tree" || collision.gameObject.tag == "Wall")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.2f);
            canBuild = true;
        }
    }
}
