using UnityEngine;

public class Collector : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<ICollectable>(out ICollectable collectable)) {
           //collectable.onCollect();
        }
    }
}
