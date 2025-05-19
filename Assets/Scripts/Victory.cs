using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Button start;

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(start.gameObject);
    }
}
