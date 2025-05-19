using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public Button start;
    public Button exit;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(start.gameObject);
    }
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") < -0.1f)
        {
            EventSystem.current.SetSelectedGameObject(start.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") > 0.1f)
        {
            EventSystem.current.SetSelectedGameObject(exit.gameObject);
        }
    }
    public void RestartButton()
    {
        
        SceneManager.LoadScene("Main Menu"); 
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
