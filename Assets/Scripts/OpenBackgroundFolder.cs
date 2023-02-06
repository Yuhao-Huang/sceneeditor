using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OpenBackgroundFolder : MonoBehaviour
{
    public GameObject background;

    public void CreateSprites()
    {
        Vector3 colliderCenter = background.transform.parent.GetComponent<BoxCollider>().bounds.center;

        string filePath = EditorUtility.OpenFilePanel("Select image", "", "jpg,png");
        if (string.IsNullOrEmpty(filePath))
        {
            return;
        }

        Texture2D texture = LoadTexture(filePath);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 32);
        background.GetComponent<SpriteRenderer>().sprite = sprite;
        background.transform.position = colliderCenter;

        AssetDatabase.Refresh();
    }

    static Texture2D LoadTexture(string filePath)
    {
        Texture2D texture = null;
        byte[] fileData;

        if (System.IO.File.Exists(filePath))
        {
            fileData = System.IO.File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
        }
        return texture;
    }
}
