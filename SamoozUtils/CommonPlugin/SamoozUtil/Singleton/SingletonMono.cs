using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    static private T _instance;

    public static T Instance {
        get {
            return _instance != null ? _instance : GetInstance();
        }
    }

    public static T GetInstance() {
        if (_instance == null) {
            _instance = GameObject.FindObjectOfType<T>();
            if (_instance == null) {
                GameObject newObj = new GameObject(typeof(T).ToString());
                _instance = newObj.AddComponent<T>();
            }
        }
        return _instance;
    }

    public static T TryGetInstance() {
        if (_instance == null) {
            _instance = GameObject.FindObjectOfType<T>();
        }
        return _instance;
    }
}
