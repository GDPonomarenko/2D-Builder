using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopBuildingController : MonoBehaviour
{
    public int countCharacterInBuilding;
    public Sprite woman, free, work;
    public SpriteRenderer firstIcon, secondIcon;
    public bool select;
    public GameObject selectMenu;
    public GameObject selectCharacter;
    public List<string> characterInBuilding;
    public GameObject parentBuilding;
    public GameObject chopper;
    public bool isFarmer;

    // Start is called before the first frame update
    void Start()
    {
        selectMenu.SetActive(false);
        firstIcon.sprite = null;
        secondIcon.sprite = null;
        select = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && select == true && selectCharacter != null)
        {
            CheckPlaceInBuilding();
            StartCoroutine(WaitForDesableMenu(2f));

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        select = true;
        selectMenu.SetActive(true);
        if (collision.gameObject.tag == "Character" || collision.gameObject.tag == "Character_free" || collision.gameObject.tag == "Character_chopper") {
            selectCharacter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        select = false;
        selectCharacter = null;
        if (collision.gameObject.tag == "Character" || collision.gameObject.tag == "Character_free" || collision.gameObject.tag == "Character_chopper")
        {
            selectCharacter = null;
        }
        selectMenu.SetActive(false);
        //StartCoroutine(WaitForDesableMenu(2f));
    }


    public void CheckPlaceInBuilding() {
        if (countCharacterInBuilding < 2)
        {
            if (countCharacterInBuilding == 0)
            {
                SelectBuilding(firstIcon);
            }
            else
            {
                
                    SelectBuilding(secondIcon);
                
            }
            
        }

        
    }


    public void SetIconSprite(Sprite sprite, SpriteRenderer spriteRenderer) {
        spriteRenderer.sprite = sprite;
    }


    private IEnumerator WaitForDesableMenu(float timeWait) {
        select = false;
        yield return new WaitForSeconds(timeWait);
        selectMenu.SetActive(false);
    }

    public void SelectBuilding(SpriteRenderer icon) {
        SetIconSprite(work, icon);
        characterInBuilding.Add(selectCharacter.name);
        Destroy(selectCharacter);
        if (isFarmer == false)
        {
            Instantiate(chopper, transform.position, Quaternion.identity);
        }
        countCharacterInBuilding++;
    }
}
