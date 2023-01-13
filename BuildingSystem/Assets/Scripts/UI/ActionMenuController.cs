using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenuController : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public Canvas actionMenu;
    public GameObject action, attack, build;
    public GameObject subMenuBuild, subMenuAttack, subMenuAction;
    private GameObject actionMenuGO;
    [Header("PREFABS BUILDING")]
    public GameObject housePrefab;
    public GameObject wallPrefab;
    public GameObject chopPrefab;
    public GameObject placePrefabs;
    public GameObject farmPrefabs;
    private AudioSource audioSource;


    public float upY;

    public bool activeSubmenu;


    // Start is called before the first frame update
    void Start()
    {
        actionMenuGO = GameObject.Find("CanvasSubMenu");
        actionMenuGO.SetActive(false);
        activeSubmenu = true;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(mousePositionOffset, Vector3.forward*10, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            OnRightClick();
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void CloseButton() {
        actionMenuGO.SetActive(false);
    }


    public void OnRightClick()
    {
        actionMenuGO.SetActive(false);
        actionMenuGO.SetActive(true);
        ReloadDataSubMenu();
        mousePositionOffset = GetMouseWorldPosition();
        RectTransform rt = actionMenu.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.position = new Vector3(mousePositionOffset.x, mousePositionOffset.y, -9);

        RaycastHit2D hit = Physics2D.Raycast(mousePositionOffset, Vector3.forward);

        if (hit)
        {
            //selectGO = hit.collider.gameObject;
            // selectGO.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Building")
            {
                activeSubmenu = false;
            }
            else
            {
                activeSubmenu = true;
            }
        }
        else {
            activeSubmenu = true;
        }

    }

    public void DownButton(GameObject button) {
        ReloadDataSubMenu();
        if (button.name == "ButtonActionBuilding" && activeSubmenu == true) {
            subMenuBuild.SetActive(true);
           
        }
        if (button.name == "ButtonActionAttack")
        {
            subMenuAttack.SetActive(true);
        }
        if (button.name == "ButtonActionAction")
        {
            subMenuAction.SetActive(true);
        }
    }


    private void ReloadDataSubMenu()
    {
        audioSource.Play();

        subMenuBuild.SetActive(false);
        subMenuAttack.SetActive(false);
        subMenuAction.SetActive(false);

    }


    public void BuildingHouse() {
        BuildFunc(housePrefab, 0.5f);
    }

    public void BuildingWall()
    {
        BuildFunc(wallPrefab, 0.3f);
    }

    public void BuildingChopHouse()
    {
        BuildFunc(chopPrefab, 1.2f);
    }

    public void BuildingFarm()
    {
        BuildFunc(farmPrefabs, 1.2f);
    }




    public void BuildFunc(GameObject prefab, float size) {
        placePrefabs.GetComponent<BuildingPlaceController>().prefabs = prefab;
        placePrefabs.GetComponent<BuildingPlaceController>().setSize = size;
        Vector3 housePos = new Vector3(mousePositionOffset.x, upY, 1);
        Instantiate(placePrefabs, housePos, Quaternion.identity);
        audioSource.Play();
        actionMenuGO.SetActive(false);
    }
}
