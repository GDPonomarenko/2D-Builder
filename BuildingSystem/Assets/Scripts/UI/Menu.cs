using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pause;

    public void DownPlay() {
        Time.timeScale = 1;
        pause.GetComponent<Pause>().check = false;
}

    public void DownReload() {
        SceneManager.LoadScene(0);
    }
}
