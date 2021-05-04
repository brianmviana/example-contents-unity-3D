using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour {

    public delegate void CoinCallback(Coin coin);
    private CoinCallback coincallback;

    public float turnSpeed = 100f;
    public int value = 10;

    public void SetupCoin(int value, CoinCallback callback = null) {
        this.value = value;
        this.coincallback = callback;
    }

    void Update() {
        transform.Rotate(0, Time.deltaTime * turnSpeed, 0);    
    }

    private void OnDestroy() {
        if (coincallback != null) {
            coincallback.Invoke(this);
        }
    }
}
