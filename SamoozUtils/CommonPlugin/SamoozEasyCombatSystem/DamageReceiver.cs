using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour {
    public virtual void DamageBy(DamageArea other) {
        Debug.Log("DamageBy " + other.gameObject.name);
        GetComponentInParent<Damagable>()?.GetHitBy(other.transform, 10f);
    }
}
