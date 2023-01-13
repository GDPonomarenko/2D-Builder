using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public GameObject building;
    public GameObject wall;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            //OnDownBuild();
        }
    }


    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnDownBuild() {
        mousePositionOffset = GetMouseWorldPosition();
        Instantiate(building, new Vector3(mousePositionOffset.x, 0,0), Quaternion.identity);
    }
    public void OnDownBuildWall()
    {
        mousePositionOffset = GetMouseWorldPosition();
        Instantiate(wall, new Vector3(mousePositionOffset.x, 0, 0), Quaternion.identity);
    }
}
