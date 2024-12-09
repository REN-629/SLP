using UnityEngine;

public class spacemoe : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundEffect;

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // スペースキーが押されたときにサウンドを再生
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}
