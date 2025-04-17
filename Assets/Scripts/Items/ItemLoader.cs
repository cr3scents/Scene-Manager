using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemLoader : MonoBehaviour {
    [Tooltip("File name and extension")]
    [SerializeField] private string _fileName;
    private string _filePath;

    private string GetFilePath() {
        return Path.Combine(Application.streamingAssetsPath, _fileName);
    }

    public List<ItemData> LoadItems() {
        List<ItemData> items = new List<ItemData>();
        _fileName =GetFilePath();
        
        if (!File.Exists(_filePath)) {
            
        }
        
        return null;
    }
}
