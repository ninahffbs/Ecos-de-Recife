using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button start;
    public Button Exit;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(Exit.gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") < -0.1f)
        {
            EventSystem.current.SetSelectedGameObject(start.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0.1f)
        {
            EventSystem.current.SetSelectedGameObject(Exit.gameObject);
        }
    }
    public void PlayGame()
    {
        Application.Quit();
    }

    public void ExitGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
