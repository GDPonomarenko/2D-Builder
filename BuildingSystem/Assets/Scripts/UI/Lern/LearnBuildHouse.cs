using UnityEngine;

public class LearnBuildHouse : MonoBehaviour
{
    public GameObject selectPlace;
    public bool select;

    public void SelectBuildHouse()
    {
        selectPlace.SetActive(true);
        Destroy(gameObject);
    }
}
