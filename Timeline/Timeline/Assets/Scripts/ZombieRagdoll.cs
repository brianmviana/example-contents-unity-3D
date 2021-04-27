using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRagdoll : MonoBehaviour {

    private Animation anim;
    private Collider[] colliders;
    private Rigidbody[] rigidbodies;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animation>();
        colliders = GetComponentsInChildren<Collider>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    private void DisableRagdoll() {
        anim.enabled = true;
        for (var i = 0; i < colliders.Length; i++) {
            colliders[i].isTrigger = true;
            rigidbodies[i].isKinematic = true;
        }
    }

    private void EnableRagdoll() {
        anim.enabled = false;
        for (var i = 0; i < colliders.Length; i++) {
            colliders[i].isTrigger = false;
            rigidbodies[i].isKinematic = false;
            rigidbodies[i].AddForce(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)), ForceMode.Impulse);
        }
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            EnableRagdoll();
        }        
    }
}
