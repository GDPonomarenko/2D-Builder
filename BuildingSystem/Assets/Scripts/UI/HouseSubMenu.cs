using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseSubMenu : MonoBehaviour
{
    [Header("Attack setting")]
    public Image imageBackgroundAttack;
    public Image imageIconAttack;
    public Button buttonAttack;


    public GameObject SubBuildingMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMenu(GameObject button) {
        BlurSubMenu(imageIconAttack, imageBackgroundAttack, buttonAttack);
        Debug.Log("Select");

        if (button.name == "ButtonActionBuilding") {
            SubBuildingMenu.SetActive(true);
        }
    }



    public void BlurSubMenu(Image imageIcon, Image imageBackground, Button button) {
        imageIcon.color = new Color(255,255,255,96);
        imageBackground.color = new Color(255,255,255,10);
        button.image.color = new Color(255, 255, 255, 96);
    }



}
