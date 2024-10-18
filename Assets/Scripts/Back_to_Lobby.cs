using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_to_Lobby : MonoBehaviour
{
    private string filePath = "Assets/LevelData.txt"; // ���� � �����
    public GameObject Player;

    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = Player.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        LevelData levelData = new LevelData();
        levelData.level1Passed = true;
        levelData.level2Passed = false;
        levelData.level3Passed = false;

        // ���������� ���������� � ����
        if (other == col)
        {
            SceneManager.LoadScene("New_Lobby");   
            WriteLevelDataToFile(levelData);

        }
    }
    private void WriteLevelDataToFile(LevelData data)
    {
        // ����������� ���������� �� ������� � ������
        string levelDataString = data.level1Passed.ToString() + "," +
                                 data.level2Passed.ToString() + "," +
                                 data.level3Passed.ToString();

        // ���������� ������ � ����
        File.WriteAllText(filePath, levelDataString);
    }
}
 

