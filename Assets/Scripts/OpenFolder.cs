using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OpenFolder : MonoBehaviour
{
    public Button button;
    public GameObject parent;

    private void Start()
    {
        button.onClick.AddListener(CreateSprites);
    }

    public void CreateSprites()
    {
        string filePath = EditorUtility.OpenFilePanel("Select image", "", "jpg,png");
        if (string.IsNullOrEmpty(filePath))
        {
            return;
        }

        Texture2D texture = LoadTexture(filePath);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 32);
        //AssetDatabase.CreateAsset(sprite, "Assets/Sprites/" + System.IO.Path.GetFileNameWithoutExtension(filePath) + ".asset");

        GameObject prefab = new GameObject(System.IO.Path.GetFileNameWithoutExtension(filePath));
        prefab.transform.SetParent(parent.transform);
        prefab.AddComponent<SpriteRenderer>().sprite = sprite;
        prefab.AddComponent<FollowMouse>();
        prefab.GetComponent<SpriteRenderer>().sortingOrder = 2;

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
