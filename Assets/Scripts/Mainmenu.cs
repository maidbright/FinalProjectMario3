using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void StartGame()
    {
        Debug.Log("StartClicked");
        //SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Debug.Log("EndClicked");
        // Application.Quit();
    }
}
