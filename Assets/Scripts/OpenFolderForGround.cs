using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OpenFolderForGround : MonoBehaviour
{
    public Button button;
    public GameObject parent;



    public void CreateSprites()
    {
        string filePath = EditorUtility.OpenFilePanel("Select image", "", "jpg,png");
        if (string.IsNullOrEmpty(filePath))
        {
            return;
        }

        Texture2D texture = LoadTexture(filePath);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        //AssetDatabase.CreateAsset(sprite, "Assets/Sprites/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + ".asset");

        GameObject prefab = new GameObject(System.IO.Path.GetFileNameWithoutExtension(filePath));
        prefab.transform.SetParent(parent.transform);
        prefab.AddComponent<SpriteRenderer>().sprite = sprite;
        prefab.GetComponent<SpriteRenderer>().sortingOrder = 1;

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
