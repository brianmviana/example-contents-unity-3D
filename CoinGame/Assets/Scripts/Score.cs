using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int currentScore;

    public void AddScore(int value) {
        currentScore += value;
        scoreText.text = "x " + currentScore;
    }

    void OnEnable() {
        Player.OnCoinCollected += AddScore;    
    }

    void OnDisable() {
        Player.OnCoinCollected -= AddScore;    
    }

}
