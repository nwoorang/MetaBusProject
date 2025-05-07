using UnityEngine;
using UnityEditor;
using System.IO;

public class DeleteSaveFile : EditorWindow
{
    [MenuItem("Tools/Delete Save File")]
    public static void ShowWindow()
    {
        GetWindow(typeof(DeleteSaveFile));
    }

    void OnGUI()
    {
        GUILayout.Label("세이브 파일 삭제", EditorStyles.boldLabel);

        if (GUILayout.Button("score.json 삭제"))
        {
            string filePath = Application.persistentDataPath + "/score.json";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("score.json 삭제 완료!");
            }
            else
            {
                Debug.Log("score.json 파일이 존재하지 않음.");
            }
        }

        if (GUILayout.Button("PlayerPrefs 전체 삭제"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("PlayerPrefs 전체 삭제 완료!");
        }
    }
}
