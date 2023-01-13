using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    public List<GameObject> clouds;
    public float waitSec;

    private void Start()
    {
        StartCoroutine(GenerateClouds());
    }

    private IEnumerator GenerateClouds() {
        while (true) {
            yield return new WaitForSeconds(waitSec);
            Instantiate(clouds[Random.RandomRange(0, clouds.Count)], transform.position, Quaternion.identity);
        }
    }
}
