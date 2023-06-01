using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs : MonoBehaviour
{
    public Sprite elementoCertoSprite;
    public Sprite elementoErrado1Sprite;
    public Sprite elementoErrado2Sprite;
    public Vector2 elementoCertoSizeDelta;
    public Vector2 elementoErrado1SizeDelta;
    public Vector2 elementoErrado2SizeDelta;
    public AudioClip elementoCertoAudioClip;
    public AudioClip elementoErrado1AudioClip;
    public AudioClip elementoErrado2AudioClip;

    public Configs(Sprite certoSprite, Sprite errado1Sprite, Sprite errado2Sprite,
        Vector2 certoSizeDelta, Vector2 errado1SizeDelta, Vector2 errado2SizeDelta,
        AudioClip certoAudioClip, AudioClip errado1AudioClip, AudioClip errado2AudioClip)
    {
        elementoCertoSprite = certoSprite;
        elementoErrado1Sprite = errado1Sprite;
        elementoErrado2Sprite = errado2Sprite;
        elementoCertoSizeDelta = certoSizeDelta;
        elementoErrado1SizeDelta = errado1SizeDelta;
        elementoErrado2SizeDelta = errado2SizeDelta;
        elementoCertoAudioClip = certoAudioClip;
        elementoErrado1AudioClip = errado1AudioClip;
        elementoErrado2AudioClip = errado2AudioClip;
    }
}
