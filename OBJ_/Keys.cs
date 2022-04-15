
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Keys : MonoBehaviour
{
    public GameManager GetManager;
    public GameObject talkBox;
    public int setId;
    public GameObject parent;
    void Start()
    {

    }

    void Update()
    {
        RotateKeys();
    }

    void RotateKeys()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20);    
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Player") {
            GetManager.silverKeyCount = GetManager.silverKeyCount + 1;
            GetManager.KeyCountUpdate();
            parent = GameObject.Find("GameObject");
            GameObject tb = Instantiate(talkBox, other.transform.position, other.transform.rotation, parent.transform) as GameObject;
            tb.GetComponent<ObjData>().id = setId;
            Destroy(this.gameObject);
        }
    }
}
