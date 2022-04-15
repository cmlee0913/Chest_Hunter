using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject pivot;
    public float distance = 5.0f;
    private Vector3 velocity = Vector3.zero;
    public float SmoothTime = 0.2f;
    public bool isGround;
    private void Start() {
        mainCamera = GameObject.FindWithTag("MainCamera");
        pivot = GameObject.FindWithTag("Pivot");
    }
    private void Update() {
        AvoidGround();
        ScrollWheel();
    }

    private void ScrollWheel()
    {
        if (!isGround) {
            distance -= Input.GetAxis("Mouse ScrollWheel") * 10f;

            if (distance < 3.0f) distance = 3.0f;
            if (distance > 9.0f) distance = 9.0f;

            Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance); // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.
            transform.position = Vector3.SmoothDamp(
                                    transform.position,
                                    pivot.transform.position - transform.rotation * reverseDistance,
                                    ref velocity,
                                    SmoothTime);
        }
    }

    void AvoidGround() {
        RaycastHit hitInfo;
		if (Physics.Linecast(pivot.transform.position,
                            transform.position,
                            out hitInfo,
                            1<<LayerMask.NameToLayer("Ground"))) 
        {
            isGround = true;
            transform.position = hitInfo.point;
        }

        else if (!Physics.Linecast(pivot.transform.position,
                                    transform.position - (transform.rotation * new Vector3(0,0,2)),
                                    out hitInfo,
                                    1<<LayerMask.NameToLayer("Ground"))) 
        {
            isGround = false;
        }
    }
}