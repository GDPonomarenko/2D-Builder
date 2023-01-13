using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatController : MonoBehaviour
{
    public float startPosY, finishPosY;
    public float timeWaitWheat;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.position = new Vector3(_transform.position.x, startPosY, _transform.position.z);
        StartCoroutine(WaitWheat());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }


    public IEnumerator WaitWheat() {
        float timeElapsed = 0;
        while (true)
        {
            if (timeElapsed < timeWaitWheat)
            {
                _transform.position = Vector3.Lerp(new Vector3(_transform.position.x, startPosY, _transform.position.z), new Vector3(_transform.position.x, finishPosY, _transform.position.z), timeElapsed / timeWaitWheat);
                timeElapsed += Time.deltaTime;
            }
            yield return null;
        }
    }
}
