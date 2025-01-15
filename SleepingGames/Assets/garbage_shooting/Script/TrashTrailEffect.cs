using UnityEngine;

public class TrashTrailEffect : MonoBehaviour
{
    public GameObject trailEffectPrefab; // エフェクトのプレハブ
    private GameObject trailEffectInstance; // エフェクトのインスタンス
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trailEffectInstance = Instantiate(trailEffectPrefab, transform.position, Quaternion.identity);
        trailEffectInstance.transform.parent = transform; // エフェクトをゴミに追従させる
        trailEffectInstance.SetActive(true); // 初期状態でエフェクトを表示にする
        var emission = trailEffectInstance.GetComponent<ParticleSystem>().emission;
        emission.enabled = false; // 初期状態でエフェクトを非表示にする
    }

    void Update()
    {
        if (rb.velocity.magnitude > 0.1f) // ゴミが飛んでいるとき
        {
            var emission = trailEffectInstance.GetComponent<ParticleSystem>().emission;
            emission.enabled = true; // エフェクトを表示する
        }
        else
        {
            var emission = trailEffectInstance.GetComponent<ParticleSystem>().emission;
            emission.enabled = false; // エフェクトを非表示にする
        }
    }
}
