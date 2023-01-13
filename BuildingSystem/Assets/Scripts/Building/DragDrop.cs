using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{

    Vector3 mousePositionOffset;
    private float tileWidth, tileHeight;
    public bool freeSpace;

   

    private void Start()
    {
        CheckTileSize();
    }


    private void FixedUpdate()
    {

    }


    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }


    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
        CheckFreeSpaseButtom();
    }


    private void OnMouseUp()
    {
        if (freeSpace == true)
        {
            StayBuildingInPlace();
        }
        else
        {
            DestroyBuilding();
        }    
    }


    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void CheckTileSize()
    {
        tileWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        tileHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(tileWidth, tileHeight);
    }


    private void StayBuildingInPlace()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
        transform.position = new Vector3(transform.position.x, 0, 0);
        ArchChange();
    }


    private void DestroyBuilding()
    {
        Destroy(gameObject);
    }


    private void CheckFreeSpaseButtom()
    {
        Debug.DrawRay(new Vector3((float)(transform.position.x - tileWidth / 2f), transform.position.y, 0), -transform.up * 1f, Color.yellow);
        Debug.DrawRay(new Vector3((float)(transform.position.x + tileWidth / 2f), transform.position.y, 0), -transform.up * 1f, Color.yellow);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - tileWidth / 2f, transform.position.y - 1f), -Vector2.up);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + tileWidth / 2f, transform.position.y - 1f), -Vector2.up);

        if (hit) {
            if (hit.collider.tag == "Building" || hit2.collider.tag == "Building")
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                freeSpace = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                freeSpace = true;
            }
        }
    }


    private void ArchChange()
    {
        //GameObject arch = GameObject.FindGameObjectWithTag("Arch");
        //arch.SetActive(false);
    }

}
