using Kakera;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddImage : MonoBehaviour
{
    [SerializeField] private Unimgpicker imagePicker;
    [SerializeField] private Material ssImage;
    public Texture2D texture;
    public Sprite texture2;

    private void Awake()
    {
        imagePicker.Completed += path => StartCoroutine(LoadImage(path, ssImage));
    }

    private void Start()
    {
        if (!ssImage)
        {
            ssImage = gameObject.GetComponent<Renderer>().material;
        }
    }

    public void OnPressShowPicker()
    {
        imagePicker.Show("Select Image", "unimgpicker", 512);//1024��512�ɕύX
    }

    private IEnumerator LoadImage(string path, Material output)
    {
        string url = "file://" + path;
        WWW www = new WWW(url);
        yield return www;

        texture = www.texture;
        // �܂����T�C�Y
        int _CompressRate = TextureCompressionRate.TextureCompressionRatio(texture.width, texture.height);
        TextureScale.Bilinear(texture, texture.width / _CompressRate, texture.height / _CompressRate);
        // ���Ɉ��k(�c���E����������Ǝg���Ȃ��ꍇ������悤�ł��B) -> https://forum.unity.com/threads/strange-error-message-miplevel-m_mipcount.441907/
        //texture.Compress(false);
        // Sprite�ɕϊ����Ďg�p����
        texture2 = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        var croppedTexture = new Texture2D((int)texture2.rect.width, (int)texture2.rect.height);
        var pixels = texture2.texture.GetPixels((int)texture2.textureRect.x,
                                            (int)texture2.textureRect.y,
                                            (int)texture2.textureRect.width,
                                            (int)texture2.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        output.SetTexture("_MainTex", croppedTexture);
    }
}


public static class TextureCompressionRate
{
    /// <summary>
    /// Texture��500x500�Ɏ��܂�悤�Ƀ��T�C�Y���܂�
    /// </summary>
    public static int TextureCompressionRatio(int width, int height)
    {
        if (width >= height)
        {
            if (width / 500 > 0) return (width / 500);
            else return 1;
        }
        else if (width < height)
        {
            if (height / 500 > 0) return (height / 500);
            else return 1;
        }
        else return 1;
    }
}