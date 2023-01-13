using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool check;
    public GameObject demoMenu, learningCanvas;
    // Start is called before the first frame update
    void Start()
    {
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        demoMenu.SetActive(check);
        if (check == true)
        {
            Time.timeScale = 0;
            learningCanvas.SetActive(false);
        }
        else {
            Time.timeScale = 1;
            learningCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (check == true)
            {
                check = false;
            }
            else {
                check = true;
            }
        }
    }
}
