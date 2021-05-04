using UnityEngine;
using System;

public class Player : MonoBehaviour {

    // public delegate void CollectedCoin(int value);
    // public static event CollectedCoin OnCoinCollected;
    public static Action<int> OnCoinCollected;

    public float moveSpeed;
    public float turnSpeed;

    public bool autoMovement;
    public Coin closestCoin;
    private float distance = 20f;

    private void Start() {
        float x = PlayerPrefs.GetFloat("PlayerX", 0);
        float z = PlayerPrefs.GetFloat("PlayerZ", 0);
    }

    void Update() {
        if (!autoMovement) {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            transform.Translate(0, 0, moveSpeed * z * Time.deltaTime, Space.Self);
            transform.Rotate(0, turnSpeed * x * Time.deltaTime, 0);
        }
        else {
            autoMovementPlayer();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Coin")) {
            //SeguirCoin();

            Coin coin = other.GetComponent<Coin>();
            if (OnCoinCollected != null) {
                OnCoinCollected.Invoke(coin.value);
            }
            Destroy(other.gameObject);
        }
    }

    private void SeguirCoin() {
        distance = 20f;
        foreach (var coin in CoinSpawner.coins) {
            var d = Vector3.Distance(coin.transform.position, transform.position);
            // closestCoin = coin;
            if (d < distance) {
                distance = d;
                closestCoin = coin;
            }
        }
    }

    private void autoMovementPlayer() {
        if (closestCoin == null) {
            SeguirCoin();
        }

        float step = moveSpeed * Time.deltaTime; // calculate distance to move

        Vector3 playerPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 coinPosition = new Vector3(closestCoin.transform.position.x, 0f, closestCoin.transform.position.z);

        transform.position = Vector3.MoveTowards(playerPosition, coinPosition, step);

        // Check if the position of the cube and sphere are approximately equal.
        //if (Vector3.Distance(transform.position, closestCoin.transform.position) < 0.001f) {
            // Swap the position of the cylinder.
          //  closestCoin.transform.position *= -1.0f;
//        }

        //transform.Translate(moveSpeed * closestCoin.transform.position.x * Time.deltaTime, 0, moveSpeed * closestCoin.transform.position.z * Time.deltaTime, Space.Self);
    }

}
