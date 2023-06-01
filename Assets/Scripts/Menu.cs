using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private string currentScene = "cenaVerão";
    private string previousScene = "";
    private void Start()
    {
        if (PlayerPrefs.HasKey("currentScene"))
        {
            currentScene = PlayerPrefs.GetString("currentScene");
        }
        if (PlayerPrefs.HasKey("previousScene"))
        {
            previousScene = PlayerPrefs.GetString("previousScene");
        }
    }
    public void LoadScenes (string cena)
    {
        previousScene = currentScene;
        currentScene = cena;
        PlayerPrefs.SetString("currentScene", currentScene);
        SceneManager.LoadScene(cena);
    }
    public void LoadNextGame()
    {
        Debug.Log(previousScene);
        if (previousScene == "CenaCartaOutono")
        {
            SceneManager.LoadScene("cenaVerao");
        }
        else if (previousScene == "cenaPrimavera")
        {
            SceneManager.LoadScene("CenaCartaInverno");
        }
    }
    public void AvancarProximaCena()
    {
        if (currentScene == "cenaOutono")
        {
            currentScene = "cenaInverno";
        }
        else if (currentScene == "cenaPrimavera")
        {
            currentScene = "cenaVerao";
        }
        else if (currentScene == "cenaVerao")
        {
            currentScene = "cenaOutono";
        }
        else if ( currentScene == "cenaInverno")
        {
            currentScene = "cenaPrimavera";
        }

        PlayerPrefs.SetString("currentScene", currentScene);

        SceneManager.LoadScene(currentScene);
    }
    public void VoltarCena()
    {
        if (previousScene == "cenaInverno")
        {
            currentScene = "cenaInverno";
        }
        else if (previousScene == "cenaVerão")
        {
            currentScene = "cenaVerão";
        }
        else if (previousScene == "cenaOutono")
        {
            currentScene = "cenaOutono";
        }
        else if (previousScene == "cenaPrimavera")
        {
            currentScene = "cenaPrimavera";
        }

        PlayerPrefs.SetString("currentScene", currentScene);
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
