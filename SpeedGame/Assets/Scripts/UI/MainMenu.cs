using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextscene;
    public GameObject OptionsScreen;
    public GameObject SelectScreen;
    public GameObject TutorialScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(nextscene);
        //SelectScreen.SetActive(true);

    }
    public void CloseSelect()
    {
        SelectScreen.SetActive(false);
    }

    public void OpenOptions()
    {
        OptionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        OptionsScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("BYE BYE");
    }
    public void CloseTutorial()
    {
        TutorialScreen.SetActive(false);
    }
    public void OpenTutorial()
    {
        TutorialScreen.SetActive(true);
    }
}
