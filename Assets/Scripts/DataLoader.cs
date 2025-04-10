/*
 * DataLoader.cs
 */

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader<T> : MonoBehaviour where T : ScriptableObject {
    [SerializeField] private string _fileName;
    private string _filePath;

    // ?? //
    private string GetFilePath() {
        return Path.Combine(Application.streamingAssetsPath, _fileName);
    }

    // ?? //
    protected List<T> LoadData() {
        _filePath = GetFilePath();

        List<T> dataList = new List<T>();

        if (!File.Exists(_filePath)) {
            Debug.LogError($"CSV file not found");
            return dataList;
        }

        string[] csvLines = File.ReadAllLines(_filePath);
        
        dataList = ProcessCSVLines(csvLines);
        
        
        
        return dataList;
    }

    // ?? //
    private List<T> ProcessCSVLines(string[] csvLines) {
        List<T> dataList = new List<T>();

        for (int i = 1; i < csvLines.Length; i++) {
            string[] fields = csvLines[i].Split(',');
            
        }
        
        return dataList;
    }

    // ?? //
    protected virtual T CreateDataFromFields(string[] fields) {
        var properties = typeof(T).GetProperties();
        
        // ensure there are enough fields
        if (fields.Length < properties.Length) {
            Debug.LogWarning("Invalid csv row: not enough fields.");
            return null;
        }

        // create new instance of T
        T dataEntry = ScriptableObject.CreateInstance<T>();

        // 
        if (dataEntry is IParsable parsableData) {
            parsableData.Parse(fields);

        }
        
        //#if UNITY_EDITOR
        //string assetDictionary = ??;
        
        return dataEntry;
    }

    // //
    private void SaveAsset(ScriptableObject x) {
        
    }
    
}
