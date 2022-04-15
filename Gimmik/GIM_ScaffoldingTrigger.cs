using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_ScaffoldingTrigger : MonoBehaviour
{
    public GIM_Scaffolding Scaffolding;
    Renderer ScaffoldColor;
    public string num;
    public bool onTrap = false;
    void Awake() {
        ScaffoldColor = gameObject.GetComponent<Renderer>();
        Scaffolding = GameObject.Find("GIM_Scaffolding").GetComponent<GIM_Scaffolding>();
    }

    void Update() {
        if (Scaffolding.isCheck)
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.name == "Player" && onTrap == false) {
            if (ScaffoldColor.material.color != Color.blue) {
                ScaffoldColor.material.color = Color.blue;
                Scaffolding.input += num;
            }
            else {
                ScaffoldColor.material.color = Color.gray;
                Scaffolding.input = Scaffolding.input.Replace(num, string.Empty);
            }
        }
    }
}
