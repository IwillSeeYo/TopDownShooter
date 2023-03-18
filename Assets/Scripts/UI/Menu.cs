using UnityEngine;

public class Menu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}