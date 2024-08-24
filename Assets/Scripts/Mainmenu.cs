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
        LevelTransition.ChangeScene(0); //go to map
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
