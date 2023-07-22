using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventoDrop : MonoBehaviour, IDropHandler
{
    public GameObject continueButton;
    public GameObject animationButton;
    private AudioSource audioSource;
    private void Start()
    {
        continueButton.SetActive(false);
        animationButton.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void CheckDragAndDrop()
    {
        if (DragAndDrop.colouCerto)
        {
            continueButton.SetActive(true);
            animationButton.SetActive(true);
            audioSource.Play();
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Se eu não estiver arrastando
        if ( eventData.pointerDrag != null)
        {
            //Compara o game tag do objeto que eu to arrastando com o objeto parado
            if (eventData.pointerDrag.gameObject.tag.Equals(gameObject.tag))
            {
                //O objeto arrastado recebe a posição do objeto parado
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
                DragAndDrop.colouCerto = true;
                CheckDragAndDrop();
            }
        }
    }
}
