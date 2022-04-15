using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{  
    SUD_GetKey sUD_GetKey;
    public AudioSource audioSource;
    public GameManager GetManager;
    GameObject player;
    GameObject pivot;
    public GameObject key;
    public GameObject scanObject;
    public GIM_Bomb gIM_Bomb;
    Rigidbody rb;
    Animator ani;
    Animation attack;
    public Weapon[] WPSlot;
    public Weapon WP;
    RaycastHit RaycastHit;
    public ImgsFillDynamic imgsFillDynamic;
    public bool isMove = false;
    public bool isJumping = true;
    public bool isSwap = false;
    public bool fdown = false;
    public bool isLanding;
    float Horizontal;
    float Vertical;
    public float jumpPower = 5f;
    public float Speed = 0f;
    public float fireDelay = 0f;
    public float jumpRange;
    public int weaponNum = 0;
    public int equipNum = 0;
    public float rotationSpeed = 15.0f;
    public float hp = 100;
    public bool isUnBeatTime;
    public bool isDie;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        pivot = GameObject.FindWithTag("Pivot");
        rb = player.GetComponent<Rigidbody>();
        ani = player.GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start() {
        if (imgsFillDynamic)
            imgsFillDynamic.SetValue(1f, false, 0.3f);
        Invoke("ToLerfTalk", 0.5f);
    }

    void Update() {
        if (isUnBeatTime) {
            imgsFillDynamic.SetValue(hp / 100, false, 2F);
        }
        else if (hp <= 0) {
            imgsFillDynamic.SetValue(0, false, 2F);
        }
        CursorActivation();
        AnimationUpdate();
        JumpDistence();
        SpeedControll();
        ScanObject();
        PlayerJump();
        Died();
    }
    void FixedUpdate() {
        Move();
    }

    void Move()
    {
        Horizontal = GetManager.isChecking || isUnBeatTime || isDie ? 0 : Input.GetAxis("Horizontal");
        Vertical = GetManager.isChecking || isUnBeatTime || isDie ? 0 : Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(Horizontal, 0, Vertical);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (4.8f <= Speed && Speed < 8f)
                Speed += 0.2f;
            if (Speed < 5f)
                if (Horizontal != 0 || Vertical != 0)
                    Speed += 0.2f;
            if(Speed == 8f)
                Speed = 8f;
            if (Speed == 0)
                Speed = 0;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Speed < 5f)
                if (Horizontal != 0 || Vertical != 0)
                    Speed += 0.2f;
            if (Speed > 5f)     
                Speed -= 0.2f;
            if (Speed == 5f)
                Speed = 5f;
            if (Speed == 0)
                Speed = 0;
        }

        if (Horizontal != 0 || Vertical != 0)
        {
            isMove = true;
            if (!audioSource.isPlaying && !isJumping) {
                audioSource.Play();
            }
        }
        else if (Horizontal == 0 && Vertical == 0)
        {
            isMove = false;
        }

        if (isJumping || Horizontal == 0 && Vertical == 0)
            audioSource.Stop();

        Vector3 moveVertical = new Vector3(pivot.transform.forward.x,
                                           0,
                                           pivot.transform.forward.z).normalized;
        Vector3 moveHorizontal = new Vector3(pivot.transform.right.x,
                                             0, 
                                             pivot.transform.right.z).normalized;
        Vector3 move = (moveVertical * Vertical + moveHorizontal * Horizontal).normalized;

        if (isMove)
        {
            player.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * rotationSpeed);
            player.transform.position += move * Time.deltaTime * Speed;
            isMove = false;
        }
      
    }

    void PlayerJump()
    {
        if (isUnBeatTime || isDie) {
            jumpPower = 0f;
        }
        else {
            jumpPower = 5f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpPower >= 5f)
        {
            if (isJumping == false)
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                ani.SetTrigger("doJump");
                isJumping = true;
            }
        }
        
    }

    void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.layer == 6) {
            isJumping = false;
            isLanding = true;
            Invoke("offLand", 0.1f);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.parent.tag == "Gimmik") {
            scanObject = other.gameObject.transform.parent.gameObject;
        }
        else if (other.tag == "Gimmik") {
            scanObject = other.gameObject;
        }
        else if (other.tag == "Respawn") {
            scanObject = other.gameObject;
        }
        else if (other.tag == "TalkBox") {
            scanObject = other.gameObject;
            GetManager.Checking(scanObject);
        }
        else if (other.tag == "Rock") {
            scanObject = other.gameObject;
        }
        else if (other.tag == "Key") {
            sUD_GetKey.GetKeySound();
            scanObject = null;
        }
        else {
            scanObject = null;
        }
        if (other.tag == "Bomb") {
            gIM_Bomb = other.gameObject.GetComponent<GIM_Bomb>();
            gIM_Bomb.OldRock = this.gameObject;
            Debug.Log("접촉했나?");
            Invoke("bomb",5f);
        }
    }
    
    void OnTriggerExit(Collider other) {
        scanObject = null;
    }

    // ���콺 Ŀ�� �����
    void CursorActivation() {
        if (Cursor.visible == true) {
            if (Horizontal != 0 || Vertical != 0) {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    // �ִϸ��̼� ����
    void AnimationUpdate()
    {
        ani.SetBool("isAttacked", isUnBeatTime);
        ani.SetFloat("MoveSpeed", Speed);
        ani.SetFloat("jumpRange", jumpRange);
        ani.SetBool("isSwap", isSwap);
        ani.SetBool("isJumping", isJumping);
        ani.SetBool("isDie", isDie);
    }

    // �ٴڰ� �Ÿ� ���
    void JumpDistence()
    {
        Physics.Raycast(player.transform.position, new Vector3(0, -1, 0), out RaycastHit);
        jumpRange = RaycastHit.distance;
    }

    // ������ ���� ���ǵ� ����
    void SpeedControll()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if (Speed > 0)
                Speed -= 0.3f;
            if (Speed < 0)
                Speed = 0;
            if (Speed == 0)
                Speed = 0;
        }
    }

    public void ScanObject() {
        if (((Input.GetButtonDown("Interactive") && scanObject != null))) {
            GetManager.Checking(scanObject);
        }
    }

    public void ToLerfTalk() {
        GetManager.Checking(scanObject);
    }

    void Died() {
        if (hp <= 0) {
            isDie = true;
        }
    }

    void bomb() {
        gIM_Bomb.Bomb();
    }
    void offLand() {
        isLanding = false;
    }
}
