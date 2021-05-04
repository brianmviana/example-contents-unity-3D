using UnityEngine;
using System;


public class CoinSpawnerButton : MonoBehaviour {

    public float pressedPostion = 0.05f;

    public static Action OnCoinSpawn;
    public GameObject visualButton;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            visualButton.transform.localPosition = new Vector3(0f, 0f, pressedPostion);
            OnCoinSpawn.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            visualButton.transform.localPosition = Vector3.zero;
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy() {
        Destroy(visualButton);
    }
}
