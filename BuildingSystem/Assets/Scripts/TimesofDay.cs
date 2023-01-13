using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimesofDay : MonoBehaviour
{
    public Material skyMaterial;
    public Light2D globalLight;

    [Header("COLOR DAY")]
    public Color downDay;
    public Color upDay;

    [Header("COLOR EVENING")]
    public Color downEvening;
    public Color upEvening;

    [Header("COLOR NIGHT")]
    public Color downNight;
    public Color upNight;

    [Header("COLOR MORNING")]
    public Color downMorning;
    public Color upMorning;


    void Start()
    {
        StartCoroutine(TimeOfDayWait());
    }

    private IEnumerator TimeOfDayWait() {

        while (true) {
            yield return new WaitForSeconds(10);
            StartCoroutine(Day(5,0.6f,1f,upMorning,downMorning,upDay,downDay));
            yield return new WaitForSeconds(10);
            StartCoroutine(Day(5, 1, 0.7f, upDay, downDay, upEvening, downEvening));
            yield return new WaitForSeconds(10);
            StartCoroutine(Day(5, 0.7f, 0.3f, upEvening, downEvening, upNight, downNight));
            yield return new WaitForSeconds(10);
            StartCoroutine(Day(5, 0.3f, 0.6f, upNight, downNight, upMorning, downMorning));
        }

    }

    private IEnumerator Day(float wait, float lightFrom, float lightTo, Color upFrom, Color downFrom, Color upTo, Color downTo)
    {
        float timeElapsed = 0;
        while (true)
        {
            if (timeElapsed < wait)
            {
                globalLight.intensity = Mathf.Lerp(lightFrom, lightTo, timeElapsed / wait);
                skyMaterial.SetColor("_DownColor", Color.Lerp(downFrom, downTo, timeElapsed / wait));
                skyMaterial.SetColor("_UpColor", Color.Lerp(upFrom, upTo, timeElapsed / wait));
                timeElapsed += Time.deltaTime;
            }
            yield return null;
        }

    }

}
