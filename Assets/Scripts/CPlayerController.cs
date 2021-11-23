using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerState
{
    ePlayerWinner,
    ePlayerLost
}
public class CPlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 100;
    private float hInput;
    private Rigidbody _rb;
    public Vector3 platformPosition = Vector3.zero;

    public EPlayerState mState;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal") * moveSpeed;

        if (hInput != 0)
        {
            Vector3 v3MovTow;
            Vector3 runPos = this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime;

            v3MovTow = Vector3.MoveTowards(runPos, platformPosition, 0.0f);

            Vector3 leftOutX = new Vector3(platformPosition.x - 4, this.transform.position.y, this.transform.position.z);
            Vector3 rightOutX = new Vector3(platformPosition.x + 4, this.transform.position.y, this.transform.position.z);

            if (v3MovTow.x <= leftOutX.x)
            {
                runPos.x = leftOutX.x;
            }
            if (v3MovTow.x >= rightOutX.x)
            {
                runPos.x = rightOutX.x;
            }
            
            _rb.transform.position = runPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "finishTrigger")
        {
            mState = EPlayerState.ePlayerWinner;
            CGameManager.Instance.GetNotificationManager().Invoke(EEventType.eRestartGameEvent);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("health" + health);

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        mState = EPlayerState.ePlayerLost;
        CGameManager.Instance.GetNotificationManager().Invoke(EEventType.eRestartGameEvent);
    }
}
