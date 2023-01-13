using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingController : House
{
    public GameObject freeCharacter;
    public GameObject scoreManager;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        GenerationHouse();
        Instantiate(freeCharacter, transform.position, Quaternion.identity);
        Instantiate(freeCharacter, transform.position, Quaternion.identity);
        score = scoreManager.GetComponent<ScoreManager>().scoreFree;
        score += 2;
        scoreManager.GetComponent<ScoreManager>().scoreFree = score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
