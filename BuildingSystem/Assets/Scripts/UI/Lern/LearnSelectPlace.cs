using System.Collections;
using UnityEngine;

public class LearnSelectPlace : MonoBehaviour
{
    public GameObject unemployedCharacter;

    void Start()
    {
        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime() {
        yield return new WaitForSeconds(10);
        unemployedCharacter.SetActive(true);
        Destroy(gameObject);
    }
}
