using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager_Script : MonoBehaviour
{

    public GameObject Menu;
    public static bool IsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (IsPaused) {
                Return();
            } else {
                Pause();
            }

        }
    }

    public void Return() { 
        Menu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause() { 
        Menu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Restart(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        IsPaused = false;
        Time.timeScale = 1f;
    }
}
