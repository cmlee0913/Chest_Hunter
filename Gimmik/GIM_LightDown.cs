using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_LightDown : MonoBehaviour
{
    public bool isPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LightDown();
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            isPlayer = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.name == "Player") {
            isPlayer = false;
        }
    }

    void LightDown() {
        if (isPlayer) {
            if (Input.GetButtonDown("Interactive")) {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
