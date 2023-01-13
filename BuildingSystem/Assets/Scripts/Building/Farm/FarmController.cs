using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmController : MonoBehaviour
{
    public Transform propeller;
    public float speedRotatePropeller;
    public GameObject wheatLeft, wheatRight;
    public GameObject selectController;
    private SpriteRenderer first, second;
    public GameObject leftCharacter, rightCharacter;

    // Start is called before the first frame update
    void Start()
    {
        first = selectController.GetComponent<ChopBuildingController>().firstIcon;
        second = selectController.GetComponent<ChopBuildingController>().secondIcon;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotatePropeler();
        if (first.sprite != null) {
            speedRotatePropeller = 0.2f;
            wheatRight.SetActive(true);
            rightCharacter.SetActive(true);

        }
        if (second.sprite != null)
        {
            speedRotatePropeller = 0.2f;
            wheatLeft.SetActive(true);
            leftCharacter.SetActive(true);

        }

        if (second.sprite != null && first.sprite != null) {
            speedRotatePropeller = 0.4f;
        }
    }

    public void RotatePropeler() {
        propeller.Rotate(new Vector3(0,0, speedRotatePropeller));
    }
}
