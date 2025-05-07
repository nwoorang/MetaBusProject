using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    float forwardSpeed;
    public bool isDead { get; private set; } = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    DifficultyManager dm; //DifficultyManager 캐싱
    public FlappyUI flappyUI;
    void Start()
    {
        dm = DifficultyManager.Instance;
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update() //키 입력 받거나 사망처리후 UI창 생성
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //내용 없음
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate() //물리작용부분
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = dm.CurrentPlayerSpeed;
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision) //사망후 지연시간
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetInteger("isDie", 1);
        isDead = true;
        deathCooldown = 1f;
        flappyUI.Endgame();
    }
}