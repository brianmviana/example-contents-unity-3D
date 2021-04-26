using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : Megaman {

    public bool sample = true;

    public Animator animator;

    void Start() {
        
    }
    void Update() {
        if (sample) {
            animator.SetBool("foward", Input.GetKey(KeyCode.D));
            animator.SetBool("backward", Input.GetKey(KeyCode.A));
            animator.SetBool("faster", Input.GetKey(KeyCode.LeftShift));
            if (Input.GetKeyDown(KeyCode.E)) {
                animator.SetTrigger("wave");
            }
        }
       /* else {
            float multi = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
            animator.SetFloat("Speed", Input.GetAxis("Horizontal") * multi);
        }*/
    }
}
