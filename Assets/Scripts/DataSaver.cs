using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaver : MonoBehaviour {
    [Tooltip("CSV file name including extension (e.g. data.csv)")] [SerializeField]
    private string fileName;

    private string filePath;

    // returns full path to CSV file inside the StreamingAssets folder
    private string GetFilePath() {
        return Path.Combine(Application.streamingAssetsPath, fileName);
    }

    protected void SaveData() {
        filePath = GetFilePath();

        if (!File.Exists(filePath)) {
            CreateNewFile();
        }
    }

    private void CreateNewFile() {
        /*
        var properties = typeof(T).GetProperties();
        

        List<string> headers = new List<string>();
        foreach (var property in properties) {
            headers.Add(property.Name);
            
        }
        */

    }
}
