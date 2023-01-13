using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : Character  
{
    public GameObject parentBuilding;
    private Vector3 newPath;
    private bool startCor;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        startCor = true;
        myTransform = GetComponent<Transform>();
        animCharacter = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        newPath = new Vector3(point.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSelect)
        {
            if (transform.position.y != positionCharacterInTirrain)
            {
                DownCharacter();
            }
            else
            {
                CharacterInTerrain();
                if (CheckCharacterDoneMove(newPath) == true)
                {
                    if (startCor == true) {
                        StartCoroutine(FarmerWork());
                        startCor = false;
                    }
                }
                else {
                    WalkCharacter(newPath);
                }
            }
        }

        Debug.Log(CheckCharacterDoneMove(newPath));

    }


    public IEnumerator FarmerWork() {
        while (true) {
            animCharacter.SetBool("Walk", false);
            animCharacter.SetBool("Work2", true);
            yield return new WaitForSeconds(5);
            animCharacter.SetBool("Work2", false);
            animCharacter.SetBool("Work1", true);
            yield return new WaitForSeconds(5);
            animCharacter.SetBool("Work1", false);
            spriteRenderer.flipX = true;
            animCharacter.SetBool("Work2", true);
            yield return new WaitForSeconds(5);
            animCharacter.SetBool("Work2", false);
            animCharacter.SetBool("Work1", true);
            yield return new WaitForSeconds(5);
            animCharacter.SetBool("Work1", false);
            spriteRenderer.flipX = false;
        }
    }

}
