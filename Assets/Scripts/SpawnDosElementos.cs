using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnDosElementos : MonoBehaviour
{
    private GameObject elementoCerto;
    private GameObject elementoErrado;
    public Canvas canvas;
    public int gameMode;
    public Vector2 normalizedPosition;
    void Start()
    {
        //Carrega os prefabs
        elementoCerto = Resources.Load<GameObject>("Prefabs/ElementoCerto");
        elementoErrado = Resources.Load<GameObject>("Prefabs/ElementoErrado");

        //Obtém a cena atual
        Scene cenaAtual = SceneManager.GetActiveScene();
        string currentScene = cenaAtual.name;

        GameObject elementoCertoInstance = null;
        GameObject elementoErrado1Instance = null;
        GameObject elementoErrado2Instance = null;

        //Seed aleatoria
        int seedPosicao = Random.Range(0, 3);

        //Posicao do canvas em relacao a camera
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
        Vector2 spawnPositionPixels = new Vector2(canvasSize.x * normalizedPosition.x, canvasSize.y * normalizedPosition.y);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(spawnPositionPixels);
        worldPosition.z = 0f;

        float x1 = 0, x2 = 0, x3 = 0, y1 = 0, y2 = 0;

        if (gameMode == 1)
        {
            x1 = 2.4f; x2 = 6.4f; x3 = 4.2f; y1 = 6.5f; y2 = 2.5f;
        }

        else if (gameMode == 2)
        {
            x1 = 3f; x2 = 7.9f; x3 = 12.6f; y1 = 6.9f; y2 = 6.9f;
        }

        Vector3 pos1 = new Vector3(worldPosition.x + x1, worldPosition.y + y1, worldPosition.z);
        Vector3 pos2 = new Vector3(worldPosition.x + x2, worldPosition.y + y1, worldPosition.z);
        Vector3 pos3 = new Vector3(worldPosition.x + x3, worldPosition.y + y2, worldPosition.z);

        if (seedPosicao == 0)
        {
            elementoCertoInstance = Instantiate(elementoCerto, pos1, transform.rotation, gameObject.transform);
            elementoErrado1Instance = Instantiate(elementoErrado, pos2, transform.rotation, gameObject.transform);
            elementoErrado2Instance = Instantiate(elementoErrado, pos3, transform.rotation, gameObject.transform);
        }

        else if (seedPosicao == 1)
        {
            elementoErrado1Instance = Instantiate(elementoErrado, pos1, transform.rotation, gameObject.transform);
            elementoCertoInstance = Instantiate(elementoCerto, pos2, transform.rotation, gameObject.transform);
            elementoErrado2Instance = Instantiate(elementoErrado, pos3, transform.rotation, gameObject.transform);
        }

        else if (seedPosicao == 2)
        {
            elementoErrado1Instance = Instantiate(elementoErrado, pos1, transform.rotation, gameObject.transform);
            elementoErrado2Instance = Instantiate(elementoErrado, pos2, transform.rotation, gameObject.transform);
            elementoCertoInstance = Instantiate(elementoCerto, pos3, transform.rotation, gameObject.transform);
        }

        elementoCertoInstance.GetComponent<DragAndDrop>().canvas = canvas;
        elementoErrado1Instance.GetComponent<DragAndDrop>().canvas = canvas;
        elementoErrado2Instance.GetComponent<DragAndDrop>().canvas = canvas;

        Sprite[] personagens;
        Sprite[] cartas;
        AudioClip[] audios;
        AudioClip[] audiosCartas;

        personagens = new Sprite[4];
        audios = new AudioClip[4];

        cartas = new Sprite[12];
        audiosCartas = new AudioClip[12];
        

        string[] estacoes = { "verao", "outono", "inverno", "primavera" };
        string[] audiosPersonagens = { "menina_verão", "menina_outono", "menino_inverno", "menino_primavera" };

        for(int i = 0; i < 4; i++)
        {
            personagens[i] = Resources.Load<Sprite>("Images/Bonecos/sprite_" + estacoes[i]);
            audios[i] = Resources.Load<AudioClip>("Audios/Audios Bonecos/audio_" + audiosPersonagens[i]);
        }

        
        int index = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                cartas[index] = Resources.Load<Sprite>("Images/Cartas/carta_" + j + "_" + estacoes[i]);
                audiosCartas[index] = Resources.Load<AudioClip>("Audios/Audios Cartas/audio_carta_" + j + "_" + estacoes[i]);
                index++; 
            }
        }
        
        Image elementoCertoImage = elementoCertoInstance.GetComponent<Image>();
        AudioSource elementoCertoAudioSource = elementoCertoInstance.GetComponent<AudioSource>();
        elementoCertoAudioSource.playOnAwake = false;

        Image elementoErrado1Image = elementoErrado1Instance.GetComponent<Image>();
        AudioSource elementoErrado1AudioSource = elementoErrado1Instance.GetComponent<AudioSource>();
        elementoErrado1AudioSource.playOnAwake = false;

        Image elementoErrado2Image = elementoErrado2Instance.GetComponent<Image>();
        AudioSource elementoErrado2AudioSource = elementoErrado2Instance.GetComponent<AudioSource>();
        elementoErrado2AudioSource.playOnAwake = false;

        Dictionary<string, Configs> configsMap = new Dictionary<string, Configs>()
        {
            { "cenaVerao",      new Configs(personagens[0], personagens[3], personagens[1], new Vector2(150, 170), new Vector2(130, 190), new Vector2(160, 180), audios[0], audios[3], audios[1]) },
            { "cenaOutono",     new Configs(personagens[1], personagens[3], personagens[0], new Vector2(160, 180), new Vector2(130, 190), new Vector2(150, 170), audios[1], audios[3], audios[0]) },
            { "cenaInverno",    new Configs(personagens[2], personagens[1], personagens[3], new Vector2(110, 190), new Vector2(160, 180), new Vector2(130, 190), audios[2], audios[1], audios[3]) },
            { "cenaPrimavera",  new Configs(personagens[3], personagens[2], personagens[0], new Vector2(130, 190), new Vector2(110, 190), new Vector2(150, 170), audios[3], audios[2], audios[0]) }

        };

        if (gameMode == 1 && configsMap.ContainsKey(currentScene) )
        {
            Configs configs = configsMap[currentScene];

            elementoCertoImage.sprite = configs.elementoCertoSprite;
            elementoErrado1Image.sprite = configs.elementoErrado1Sprite;
            elementoErrado2Image.sprite = configs.elementoErrado2Sprite;

            elementoCertoImage.rectTransform.sizeDelta = configs.elementoCertoSizeDelta;
            elementoErrado1Image.rectTransform.sizeDelta = configs.elementoErrado1SizeDelta;
            elementoErrado2Image.rectTransform.sizeDelta = configs.elementoErrado2SizeDelta;

            elementoCertoAudioSource.clip = configs.elementoCertoAudioClip;
            elementoErrado1AudioSource.clip = configs.elementoErrado1AudioClip;
            elementoErrado2AudioSource.clip = configs.elementoErrado2AudioClip;
        }

        Dictionary<string, int> cartaConfigMap = new Dictionary<string, int>()
        {
            { "CenaCartaVerao", 0 },
            { "CenaCartaOutono", 3 },
            { "CenaCartaInverno", 6 },
            { "CenaCartaPrimavera", 9 }
        };

        if (gameMode == 2 && cartaConfigMap.ContainsKey(currentScene))
        {
            int config = cartaConfigMap[currentScene];
            int randCardCerta = Random.Range(config, config + 3);
            int randCardErrada1, randCardErrada2;
            do
            {
                randCardErrada1 = Random.Range(0, 12);
            } while (randCardErrada1 == config || randCardErrada1 == config + 1 || randCardErrada1 == config + 2);
            do
            {
                randCardErrada2 = Random.Range(0, 12);
            } while (randCardErrada2 == config || randCardErrada2 == config + 1 || randCardErrada2 == config + 2 || randCardErrada2 == randCardErrada1);

            elementoCertoImage.sprite = cartas[randCardCerta];
            elementoErrado1Image.sprite = cartas[randCardErrada1];
            elementoErrado2Image.sprite = cartas[randCardErrada2];

            elementoCertoImage.rectTransform.sizeDelta = new Vector2(150, 150);
            elementoErrado1Image.rectTransform.sizeDelta = new Vector2(150, 150);
            elementoErrado2Image.rectTransform.sizeDelta = new Vector2(150, 150);

            elementoCertoAudioSource.clip = audiosCartas[randCardCerta];
            elementoErrado1AudioSource.clip = audiosCartas[randCardErrada1];
            elementoErrado2AudioSource.clip = audiosCartas[randCardErrada2];
        }
    }
}
