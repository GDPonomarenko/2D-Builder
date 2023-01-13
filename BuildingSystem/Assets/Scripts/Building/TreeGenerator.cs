using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{

    public SpriteRenderer[] grassTree;
    public int colorGen;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTreePrefabs();


    }


    public void GenerateTreePrefabs() {
        for (int x=0; x< grassTree.Length; x++) {
            colorGen = Random.RandomRange(210, 255);
            grassTree[x].color = new Color(colorGen, colorGen, colorGen, 255);
        }
    }
}
