using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButtons : MonoBehaviour
{
    public GameObject estacoesButton;
    public GameObject cartasButton;
    public GameObject startButton;
    void Start()
    {
        startButton.SetActive(true);
        cartasButton.SetActive(false);
        estacoesButton.SetActive(false);
    }

    public void trocaBotoes()
    {
        if (startButton.activeSelf)
        {
            startButton.SetActive(false);
            cartasButton.SetActive(true);
            estacoesButton.SetActive(true);
        }
    }
}
