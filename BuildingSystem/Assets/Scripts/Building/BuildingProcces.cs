using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProcces : MonoBehaviour
{
    public float timeStep;

    public GameObject[] frontPart;
    public GameObject[] backPart;
    public GameObject housePrefab;
    public bool withoutBackSide;
    public int countPeopleInProcces;
    public List<GameObject> characterInProcces;
    public GameObject targetManager;
    private List<GameObject> target;
    public float yUpBuilding;


    public float timeBuilding;

    private IEnumerator coroutine;


    void Start()
    {
        coroutine = WaitAndPrint();
        timeBuilding = timeStep * 5;
        targetManager = GameObject.Find("TargetManager");
        target = targetManager.GetComponent<TargetManager>().targetBuilding;
    }

    void FixedUpdate()
    {
        timeBuilding = timeStep * 5 / countPeopleInProcces;
    }

    private IEnumerator WaitAndPrint()
    {
        int x = 0;
        while (x < frontPart.Length) {
            frontPart[x].SetActive(true);
            if (withoutBackSide == false) {
                backPart[x].SetActive(true);
            }
            yield return new WaitForSeconds(timeBuilding/5);
            x++;
        }
        if (x == frontPart.Length) {
            Instantiate(housePrefab, new Vector3(transform.position.x, yUpBuilding, transform.position.z), Quaternion.identity);
            for (int z = 0; z < characterInProcces.Count; z++)
            {
                characterInProcces[z].GetComponent<Character>().StopWorkProcces();
            }
            target.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character_work") {
            characterInProcces.Add(collision.gameObject);
            countPeopleInProcces++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character_work")
        {
            characterInProcces.Remove(collision.gameObject);
            countPeopleInProcces--;
        }
    }

}
