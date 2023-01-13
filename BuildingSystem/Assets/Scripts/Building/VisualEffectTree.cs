using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffectTree : MonoBehaviour
{
    private float z;
    private Quaternion newRot;
    // Start is called before the first frame update
    void Start()
    {
        z = -5;
        newRot = new Quaternion(0, 0, z, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        while (transform.rotation.z != z)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.deltaTime);
        }

        if (transform.rotation.z != z)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.deltaTime);
        }
        else {
            GenerationRandomZ();
        }
    }

    public void GenerationRandomZ() {
        z = Random.RandomRange(-5,-40);
        newRot = new Quaternion(0, 0, z, 0);
    }
}
