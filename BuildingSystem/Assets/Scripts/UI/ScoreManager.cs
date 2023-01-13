using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textBuilder, textChopper, textFree, textFarm;
    public int scoreBuilder, scoreChopper, scoreFree, scoreFarm;

    // Start is called before the first frame update
    void Start()
    {
        scoreChopper = 1;
    }

    // Update is called once per frame
    void Update()
    {
        textChopper.SetText(scoreChopper.ToString());
        textFree.SetText(scoreFree.ToString());
    }
}
