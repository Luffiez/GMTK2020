using UnityEngine;

public class Distraction : MonoBehaviour
{
    [SerializeField]
    protected LayerMask gooseMask;
    [SerializeField]
    protected float radius;
    [SerializeField]
    protected float forceStartPercent;
    [SerializeField]
    protected float maxForce;
    [SerializeField]
    protected AudioClip audioClip;
    [SerializeField]
    protected float audioClipVolume;
    [SerializeField]
    float maxRandomAudioTime;
    [SerializeField]
    float minRandomAudioTime;
    protected float audioTimer;
    
    protected Rigidbody2D goose;

    protected GameManager gm;

    protected LineCircle lineCircle;

    protected virtual void Start()
    {
        goose = GameObject.FindGameObjectWithTag("Gesse").GetComponent<Rigidbody2D>();
        audioTimer = Random.Range(minRandomAudioTime, maxRandomAudioTime);

        if (!goose)
        {
            Debug.LogError("Can't find ze goose!!");
        }
        gm = GameManager.instance;

        lineCircle = GetComponentInChildren<LineCircle>();
        lineCircle.DoRenderer(radius);
    }

    protected bool TriggerDistraction(Vector2 pos1, Vector2 pos2)
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, gooseMask);
        if (hit != null)
        {
            if (audioTimer <= 0 && audioClip != null)
            {
                MusicManager.Instance.PlayOneShot(audioClip, audioClipVolume);
                audioTimer = Random.Range(minRandomAudioTime, maxRandomAudioTime);
            }
            Debug.Log("Hit goose!");
            Vector2 direction = (pos1 - pos2).normalized;
            float force = maxForce * 1 - forceStartPercent * (transform.position - hit.transform.position).sqrMagnitude / (radius * radius);
            goose.AddForce(direction * force);

            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
