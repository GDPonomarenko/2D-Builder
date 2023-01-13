using UnityEngine;

public class LernWASD : MonoBehaviour
{
    public GameObject rightClick;
    public bool w, a, s, d;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            a = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            w = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            s = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            d = true;
        }

        if (w && a && s && d)
        {
            rightClick.SetActive(true);
            Destroy(gameObject);
        }
    }
}

