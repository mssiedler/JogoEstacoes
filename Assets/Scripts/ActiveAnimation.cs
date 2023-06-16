using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnimation : MonoBehaviour
{
    public Animator animacao;
    public SpriteRenderer animacaoSprite;
    private bool animacaoAtivada = false;
    void Awake()
    {
        SpriteRenderer animacaoSprite = GetComponent<SpriteRenderer>();
        animacaoSprite.enabled = false;
        animacao.enabled = false;
    }
    void Update()
    {
        if (DragAndDrop.colouCerto && !animacaoAtivada)
        {
            animacaoSprite.enabled = true;
            animacao.enabled = true;
            animacao.Play("AnimationBaloes", 0, 0);
            animacaoAtivada = true;
        }
        else if (!DragAndDrop.colouCerto && animacaoAtivada)
        {
            animacaoSprite.enabled = false;
            animacao.ResetTrigger("Subir");
            animacao.enabled = false;
            animacaoAtivada = false;
        }
    }
}
