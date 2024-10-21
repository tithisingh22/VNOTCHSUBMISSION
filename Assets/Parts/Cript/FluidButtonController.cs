using System.Collections;
using UnityEngine;
using Obi;

public class FluidButtonController : MonoBehaviour {

    [Header("Fluid Button Controller - Made by RG")]
    public ObiEmitter faucetEmitter;
    public Animator buttonAnimator; 
    public float emissionSpeed = 10f;
    private bool isFaucetRunning = false;

    void Start() {
        faucetEmitter = GetComponentInChildren<ObiEmitter>();
        faucetEmitter.speed = 0; 
        isFaucetRunning = false; 
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.CompareTag("Interactable")) {
                    ToggleFaucet(); 
                }
            }
        }
    }

    void ToggleFaucet() {
        isFaucetRunning = !isFaucetRunning;

        buttonAnimator.Play("ButtonPress");

        if (isFaucetRunning) {
            faucetEmitter.speed = emissionSpeed; 
        } else {
            faucetEmitter.speed = 0; 
        }
    }
}
