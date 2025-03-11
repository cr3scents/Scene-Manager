using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _collectableValue = 10;
    public int CollectableValue {
        get { return _collectableValue; }
        set { _collectableValue = value; }
    }

    void OnCollect() {
        
    }
}
