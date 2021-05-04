using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour {

    public UnityEvent OnEndGame;

    public int numberOfCoins = 10;
    public int maxCoinValue = 10;
    public Coin CoinPrefab;
    public static List<Coin> coins = new List<Coin>();

    void Start() {
        CoinsInstaciate();
    }

    private void CoinsInstaciate() {
        for (var i = 0; i < numberOfCoins; i++) {
            var position = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
            var coin = Instantiate(CoinPrefab, position, Quaternion.identity);
            var value = Random.Range(1, maxCoinValue);
            coin.SetupCoin(value, OnCoinDestroyer);
            coins.Add(coin);
        }
        Debug.Log("Coin qtd: " + coins.Count);
    }
    
    void Update() {
        if (coins.Count <= 0) {
            numberOfCoins *= 2;
            CoinsInstaciate();
        }
    }

    void OnCoinDestroyer(Coin coin) {
        coins.Remove(coin);
        Debug.Log("Coin qtd restante: " + coins.Count);
        if (coins.Count == 0) {
            Debug.Log("Next Level");
        }
    }

    void OnCoinDestroyed(Coin coin) {
        coins.Remove(coin);
        if (coins.Count == 0) {
            if (OnEndGame != null) {
                OnEndGame.Invoke();
            }
        }
    }

    void OnEnable() {
        CoinSpawnerButton.OnCoinSpawn += CoinsInstaciate;
    }

    void OnDisable() {
        CoinSpawnerButton.OnCoinSpawn -= CoinsInstaciate;
    }

}
