using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class DamageArea : MonoBehaviour {
    public string damageTag;
    public bool activeOnStart;
    private Rigidbody rb;
    private BoxCollider coll;
    private bool isDamageDetectActive;
    void Awake() {
        InitPhysic();
        if (activeOnStart) {
            SetDamageDetectActive(true);
        }
    }

    private void Update() {
        if (coll.enabled && !isDamageDetectActive) {
            coll.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log(other.gameObject.name);
        // Debug.Log(other.GetComponent<DamageReceiver>());
        if (other.GetComponent<DamageReceiver>()) {
            // Debug.Log("DamageReceive By " + other.gameObject.name);
            other.GetComponent<DamageReceiver>().DamageBy(this);
        }
    }

    private void InitPhysic() {
        // rb = GetComponentInParent<Rigidbody>();
        coll = GetComponent<BoxCollider>();

        // rb.constraints = RigidbodyConstraints.FreezeAll;
        coll.isTrigger = true;
        SetDamageDetectActive(false);
    }

    public void SetDamageDetectActive(bool active) {
        isDamageDetectActive = active;
        coll.enabled = active;
    }

}
