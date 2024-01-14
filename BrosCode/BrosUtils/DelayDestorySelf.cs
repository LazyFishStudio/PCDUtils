using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestorySelf : MonoBehaviour {
    public float delayTime = 2.0f;
    private float delayTimeCount;
    void OnEnable() {
        delayTimeCount = 0;
    }

    void Update() {
        delayTimeCount += Time.deltaTime;
        if (delayTimeCount >= delayTime) {
            GameObject.Destroy(gameObject);
        }
    }
}
