using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class miniMenu : MonoBehaviour
{

    public Button startText;


    // Use this for initialization
    void Start()
    {

        startText = startText.GetComponent<Button>();

    }

    public void StartLevel()
    {
        SceneManager.LoadScene(GameMain.MINI_GAME1);
    }

}
