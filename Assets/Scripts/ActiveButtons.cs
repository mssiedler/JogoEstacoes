using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButtons : MonoBehaviour
{
    public GameObject estacoesButton;
    public GameObject cartasButton;
    public GameObject startButton;
    public GameObject infoEstacoesButton;

    public GameObject configButton;
    public GameObject infoButton;
    public GameObject audioButton;
    public GameObject howToPlayButton;

    private bool botoesAbertos = false;
    private float lerpSpeed = 7f;
    private Vector3 configButtonPosition;
    private Vector3 infoButtonTargetPosition;
    private Vector3 audioButtonTargetPosition;
    private Vector3 howToPlayButtonTargetPosition;

    void Start()
    {
        startButton.SetActive(true);
        cartasButton.SetActive(false);
        estacoesButton.SetActive(false);
        infoEstacoesButton.SetActive(false);
        configButton.SetActive(true);
        infoButton.SetActive(false);
        audioButton.SetActive(false);
        howToPlayButton.SetActive(false);

        configButtonPosition = configButton.transform.position;
        infoButton.transform.position = configButtonPosition;
        audioButton.transform.position = configButtonPosition;
        howToPlayButton.transform.position = configButtonPosition;

        infoButtonTargetPosition = configButtonPosition + new Vector3(0, 1.5f, 0);
        audioButtonTargetPosition = configButtonPosition + new Vector3(0, 2.8f, 0);
        howToPlayButtonTargetPosition = configButtonPosition + new Vector3(0, 4.1f, 0);
    }

    public void trocaBotoesStart()
    {
        if (startButton.activeSelf)
        {
            startButton.SetActive(false);
            cartasButton.SetActive(true);
            estacoesButton.SetActive(true);
            infoEstacoesButton.SetActive(true);
        }  
    }
    public void trocaBotoesConfig()
    {
        if (configButton.activeSelf)
        {
            if (!botoesAbertos)
            {
                infoButton.SetActive(true);
                audioButton.SetActive(true);
                StartCoroutine(MoveButtonsCoroutine());
            }
            if (botoesAbertos)
            {
                StartCoroutine(RetreatButtonsCoroutine());
            }
        }
        botoesAbertos = !botoesAbertos;
    }

    private IEnumerator MoveButtonsCoroutine()
    {
        float t = 0;
        Vector3 infoButtonInitialPosition = infoButton.transform.position;
        Vector3 audioButtonInitialPosition = audioButton.transform.position;
        Vector3 howToPlayButtonInitialPosition = howToPlayButton.transform.position;

        while (t < 1)
        {
            t += lerpSpeed * Time.deltaTime;

            infoButton.transform.position = Vector3.Lerp(infoButtonInitialPosition, infoButtonTargetPosition, t);
            audioButton.transform.position = Vector3.Lerp(audioButtonInitialPosition, audioButtonTargetPosition, t);
            howToPlayButton.transform.position = Vector3.Lerp(howToPlayButtonInitialPosition, howToPlayButtonTargetPosition, t);

            if (t >= 1)
            {
                infoButton.SetActive(true);
                audioButton.SetActive(true);
                howToPlayButton.SetActive(true);
            }

            yield return null;
        }
    }

    private IEnumerator RetreatButtonsCoroutine()
    {
        float t = 0;
        while (t < 1)
        {
            t += lerpSpeed * Time.deltaTime;
            Vector3 infoButtonInitialPosition = infoButton.transform.position;
            Vector3 audioButtonInitialPosition = audioButton.transform.position;
            Vector3 howToPlayButtonInitialPosition = howToPlayButton.transform.position;

            infoButton.transform.position = Vector3.Lerp(infoButtonInitialPosition, configButtonPosition, t);
            audioButton.transform.position = Vector3.Lerp(audioButtonInitialPosition, configButtonPosition, t);
            howToPlayButton.transform.position = Vector3.Lerp(howToPlayButtonInitialPosition, configButtonPosition, t);

            if (t >= 0.7)
            {
                infoButton.SetActive(false);
                audioButton.SetActive(false);
                howToPlayButton.SetActive(false);
            }
            yield return null;
        }
    }
}
