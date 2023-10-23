using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T GetInstance() {
        if (instance == null) {
            instance = GameObject.FindObjectOfType<T>();
            if (instance == null) {
                GameObject newObj = new GameObject(typeof(T).ToString());
                instance = newObj.AddComponent<T>();
            }
        }
        return instance;
    }
}
