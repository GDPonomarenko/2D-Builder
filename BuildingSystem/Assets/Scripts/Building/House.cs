using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class House : MonoBehaviour
{
    public int levelHouse;
    public int countPeople;

    public GameObject[] windowFront;
    public GameObject[] windowBack;
    public GameObject[] smokePipe;
    public GameObject[] doorsFront;
    public GameObject[] doorsBack;

    public Transform housePosition;

    public float minXPipe, maxXPipe, minYPipe, maxYPipe;

    public float minXWinFront, maxXWinFront, minYWinFront, maxYWinFront;
    public float minXWinBack, maxXWinBack, minYWinBack, maxYWinBack;

    public float minXDoorFront, maxXDoorFront, minYDoorFront, maxYDoorFront;
    public float minXDoorBack, maxXDoorBack, minYDoorBack, maxYDoorBack;




    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerationHouse() {
        Vector3 winFrontPos;
        Vector3 winBackPos;
        Vector3 pipekPos;
        Vector3 doorFrontPos;
        Vector3 doorBackPos;


        int randWin = (int)Random.RandomRange(0,2);
        if (randWin == 0)
        {
            winFrontPos = GenerateRandomPosition(minXWinFront, maxXWinFront, minYWinFront, maxYWinFront, housePosition.position);
            winBackPos = GenerateRandomPosition(minXWinBack, maxXWinBack, minYWinBack, maxYWinBack, housePosition.position);
            Instantiate(windowFront[(int)Random.RandomRange(0, windowFront.Length)], winFrontPos, Quaternion.identity, transform);
            Instantiate(windowBack[(int)Random.RandomRange(0, windowBack.Length)], winBackPos, Quaternion.identity, transform);
        }

        if(randWin == 1) {
            winFrontPos = GenerateRandomPosition(minXDoorFront, maxXDoorFront, minYDoorFront, maxYDoorFront, housePosition.position);
            doorBackPos = GenerateRandomPosition(minXDoorBack, maxXDoorBack, minYDoorBack, maxYDoorBack, housePosition.position);

            Instantiate(windowFront[(int)Random.RandomRange(0, windowFront.Length)], winFrontPos, Quaternion.identity, transform);
            Instantiate(doorsBack[(int)Random.RandomRange(0, doorsBack.Length)], doorBackPos, Quaternion.identity, transform);
        }
        if (randWin == 2)
        {
            winBackPos = GenerateRandomPosition(minXWinBack, maxXWinBack, minYWinBack, maxYWinBack, housePosition.position);
            doorFrontPos = GenerateRandomPosition(minXDoorFront, maxXDoorFront, minYDoorFront, maxYDoorFront, housePosition.position);

            Instantiate(windowBack[(int)Random.RandomRange(0, windowBack.Length)], winBackPos, Quaternion.identity, transform);
            Instantiate(doorsFront[(int)Random.RandomRange(0, doorsFront.Length)], doorFrontPos, Quaternion.identity, transform);
        }
        pipekPos = GenerateRandomPosition(minXPipe, maxXPipe, minYPipe, maxYPipe, housePosition.position);
        Instantiate(smokePipe[(int)Random.RandomRange(0, smokePipe.Length)], pipekPos, Quaternion.identity, transform);
    }


    public Vector3 GenerateRandomPosition(float minX, float maxX, float minY, float maxY,Vector3 housePos) {
        return new Vector3(housePosition.position.x + (float)Random.Range(minX, maxX), housePosition.position.y + (float)Random.Range(minY, maxY), housePos.z - 0.1f);
    }
}
