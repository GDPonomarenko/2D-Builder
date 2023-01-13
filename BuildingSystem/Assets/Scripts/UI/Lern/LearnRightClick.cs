using UnityEngine;

public class LearnRightClick : MonoBehaviour
{
    public GameObject selectMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            selectMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}
