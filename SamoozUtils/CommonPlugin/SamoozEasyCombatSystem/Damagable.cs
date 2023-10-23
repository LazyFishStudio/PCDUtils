using UnityEngine;

public class Damagable : MonoBehaviour {
    public float maxHp = 30.0f;
    public float hp;
    [SerializeField]
    protected GameObject[] hitEffects;
    [SerializeField]
    protected GameObject[] deathEffects;
    [SerializeField]
    protected Renderer[] flashRenders;

    protected virtual void Awake() {
        Reset();
    }

    void Update() {
        
    }

    public virtual void GetHitBy(Transform attacker, float damage) {
        hp -= damage;
        if (hp <= 0) {
            Death();
        } else {
            DoMeshFlash();
        }
    }

    public virtual void Death() {
        if (deathEffects != null) {
            foreach (GameObject effect in deathEffects) {
                GameObject.Instantiate(effect, transform.position, transform.rotation);
            }
        }
    }

    public virtual void Reset() {
        hp = maxHp;
    }

    public void DoMeshFlash() {
        if (flashRenders == null) {
            return;
        }
        for (int i = 0; i < flashRenders.Length; i++) {
            MeshFlasher.GetInstance().DoFlash(flashRenders[i], 0.2f);
        }
        // foreach (Renderer render in flashRenders) {
        //     MeshFlasher.GetInstance().DoFlash(render, 0.2f);
        // }
    }

}
