using UnityEngine;

public class LearnActiveMenu : MonoBehaviour
{
    public GameObject buildMenu;
    public bool select;

    public void SelectBuildMenu() {
        buildMenu.SetActive(true);
        Destroy(gameObject);
    }
}
