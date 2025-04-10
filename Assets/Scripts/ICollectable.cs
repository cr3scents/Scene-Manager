using UnityEngine;

public interface ICollectable {
    int CollectableValue { get; set; }

    void OnCollect()
    {
        
    }
}
