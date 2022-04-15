using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_PasswordInput : MonoBehaviour
{
    public enum switchColor {
        Red, Blue, Green, Yellow, Purple, Black, Skyblue, Orange
    }
    public GIM_Password password;
    public switchColor input;
    Color myColor;

    void Awake() {
        myColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    void Update() {
        if (password.input.Length == password.answer.Length) {
            Invoke("ChangeColor", 0.4f);
        }
    }

    public void Input() {
        password.input += ((float)input);

    }

    void ChangeColor() {
        if (password.isCheck) {
            Debug.Log("ChangeColorGreen");
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            this.enabled = false;
        }
        else {
            Debug.Log("ChangeColorRed");
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            Invoke("ReturnColor", 1f);
        }
    }

    void ReturnColor() {
        this.gameObject.GetComponent<Renderer>().material.color = myColor;
    }
}
