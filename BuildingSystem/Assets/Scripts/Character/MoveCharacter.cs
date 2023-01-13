using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : Character
{
    public bool targetDone;
    private Transform pos;
    private GameObject tg;


    // Start is called before the first frame update
    void Start()
    {
        animCharacter = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = new Vector2(2, 0);
        myTransform = GetComponent<Transform>();
        pos = transform;
        tg = GameObject.Find("TargetManager");
        targetManager = tg;
        speedMove = Random.RandomRange(speedMove - 0.05f, speedMove+0.05f);
        audioData = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (characterType)
        {
            case CharacterType.Worker:
                target = tg.GetComponent<TargetManager>().targetBuilding;
                break;
            case CharacterType.Unemployed:
                //Debug.Log("Unemployed");
                break;
            case CharacterType.Lumberjack:
                target = tg.GetComponent<TargetManager>().targetTree;
                break;
        }

        if (!isSelect)
        {
            if (transform.position.y != positionCharacterInTirrain)
            {
                DownCharacter();
            }
            else
            {
                CharacterInTerrain();
                if (target.Count > 0)
                {
                    MoveToTarget();
                }
                else {
                    MoveAroundSpawnPosition();
                }
            }
        }
    }

}
