using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteAtlasTest : MonoBehaviour
{
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private SpriteRenderer spriteRenderer1;
    [SerializeField] private SpriteRenderer spriteRenderer2;

    private void Start()
    {
        Sprite flower = spriteAtlas.GetSprite("Flower1");
        spriteRenderer1.sprite = flower;
        
        Sprite[] spriteArray = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(spriteArray);
        spriteRenderer2.sprite = spriteArray[1];
    }
}
