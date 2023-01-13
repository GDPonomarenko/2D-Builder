using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHouse : MonoBehaviour
{
    private GameObject targetManager;
    void Start()
    {
        targetManager = GameObject.Find("TargetManager");
        targetManager.GetComponent<TargetManager>().targetBuilding.Add(gameObject);
    }
}
