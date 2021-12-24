using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 對話框系統 : MonoBehaviour
{
    public GameObject move;
    public GameObject talk;
    public 課程 A;
    [Header("UI組件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文字文件")]
    public TextAsset textFile;
    public int index;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            A.GetComponent<課程>().enabled = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            textLabel.text = textList[index];
            index++;
        }
        A.GetComponent<課程>().enabled = false;
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }
}
