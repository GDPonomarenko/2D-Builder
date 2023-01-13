using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaterialSprite : MonoBehaviour
{
    public Sprite normalMap, sprite;
    public Texture2D croppedTexture, texture2D, normalMap2D;
    public Shader shader;
    public Material mat; 
    // Start is called before the first frame update
    void Start()
    {
        texture2D = ConvertTexture(sprite);
        normalMap2D = ConvertTexture(normalMap);
        GenerateMaterial(texture2D, normalMap2D);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Texture2D ConvertTexture(Sprite spriteGen) {
        Color[] pixels;
        // assume "sprite" is your Sprite object
        croppedTexture = new Texture2D((int)spriteGen.rect.width, (int)spriteGen.rect.height);
        pixels = spriteGen.texture.GetPixels((int)spriteGen.textureRect.x,
                                                (int)spriteGen.textureRect.y,
                                                (int)spriteGen.textureRect.width,
                                                (int)spriteGen.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        return croppedTexture;
    }


    public void GenerateMaterial(Texture2D texture, Texture2D normal) {
        Renderer rend = GetComponent<Renderer>();
        rend.material = new Material(shader);
        rend.material.SetTexture("_MainTexture", texture);
        rend.material.SetTexture("_NormalMap", normal);
    }
}
