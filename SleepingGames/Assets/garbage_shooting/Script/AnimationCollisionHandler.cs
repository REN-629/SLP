using UnityEngine;

public class AnimationCollisionHandler : MonoBehaviour
{
    public Collider2D hitCollider; // 追加したいコリジョン
    public GameObject anime;
    // アニメーションイベントで呼び出されるメソッド
    //public void EnableCollider()
    //{
    //    if (hitCollider != null)
    //    {
    //        hitCollider.enabled = true;
    //    }
    //}

    //public void DisableCollider()
    //{
    //    if (hitCollider != null)
    //    {
    //        hitCollider.enabled = false;
    //    }
    //}

    public void Obj_active_false()
    {
        anime.SetActive(false);
    }
    public void Obj_active_true()
    {
        anime.SetActive(true);
    }

}
