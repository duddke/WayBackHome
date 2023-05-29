using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject MoveFactory;
    //점프이팩트
    public GameObject JUMPFactory;
    public static PlayerMove instance;
    //조작법UI
    public GameObject manual;
    //절댓값 스피드
    public float SPEED = 5;
    //점프 높이/중력/y게산 변수
    public float jumpPower = 3f;
    public float gravity = -10f;
    public float yVelocity;
    //스킬
    public bool isJumping = false;//점프상태
    public bool hide = false;//은신 상태
    public int hideCo = 0;
    public Text HideCountText;
    public float hideCountMax = 10;
    bool dash = false;//대쉬상태
    int jumpsco;//점프횟수
    //이동 등에 쓰이는 변수
    float speed;
    float h;
    float v;
    //은신카운트
    public int hideCount
    {
        get
        {
            return hideCo;
        }
        set
        {
            hideCo = value;
            HideCountText.text = (hideCountMax - hideCo).ToString();
        }
    }

    public GameObject slimeCC;
    GameObject playerSpin;
    Vector3 dir;

    public CharacterController cc;
    public Vector3 respawnPosition;
    public GameObject pumpkinSave;
    
    public bool OnJumpBlock = false;


    public Animator animator;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        slimCCoff();
        respawnPosition = transform.position;
        playerSpin = GameObject.Find("PlayerPretap");
        //animator = GetComponent<Animator>();
        //animatorIdle();
        HideCountText.text = hideCountMax.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        //캠이 특수모드가 아니라면
        if (!CamManager.Instaced.spCam)
        {
            //Mouse();

            //키입력에 따라 방향을 바꾸고 캐릭터 이동
            // 키를 누르면 플레이어가 그 방향을 바라본다
            //키를 누르면
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            dir = Vector3.right * h + Vector3.forward * v;
            if (Camera.main)
            {

            dir = Camera.main.transform.TransformDirection(dir);
            }
            
            //플레이어의 시선이 움직인다
            dir.Normalize();
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 1f/*Time.deltaTime * speed * 0.7f*/);

            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed * 2f/*Time.deltaTime * speed * 0.7f*/);
            }
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);




            //KeyNo();

        }
        //만약 아니라면(만약 특수모드라면)
        else
        {
             //Mouse();

            //키입력에 따라 방향을 바꾸고 캐릭터 이동
            // 키를 누르면 플레이어가 그 방향을 바라본다
            //키를 누르면
            // 키를 누르면 캐릭터가 이동한다
            v = Input.GetAxis("Horizontal");
            h = Input.GetAxis("Vertical");
            dir = Vector3.left * h + Vector3.forward * v;
            dir.Normalize();
            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed * 5f);
            }
            //KeyNo();
        }
        if (h != 0 || v != 0) 
        {
            animator.SetBool("Walk", true);
            if (cc.isGrounded)
            {
                GameObject move = Instantiate(MoveFactory);
                move.transform.position = transform.position - new Vector3(0, 1.1f, 0);
            }
        }
       else 
        {
            animator.SetBool("Walk", false);
        }
        //점프점프점프
        //땅에 닿으면
        if (cc.isGrounded&&!OnJumpBlock)
        {
            //점프스코어가 0이 된다
            jumpsco = 0;
            //점프가 트루라면
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0;
        }
        // star 스코어 5개 이하라면
        if (!YA_PlayerStar.instance.dubbleJumpScore)
        {
            //점프
            //점프를 누르고 점프상태가 아니라면
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                PlayerSoundManager.Instance.JumpSoundOn();
                //와이벨로시티는 점프파워고
                yVelocity = jumpPower;
                /*yVelocity += gravity * Time.deltaTime;
                dir.y = yVelocity;*/
                //rigidBody.AddForce(transform.up * jumpPower);
                //점프상태가 된다
                isJumping = true;
                JumpEfa();
                //점프횟수가 +1이 된다
                jumpsco += 1;
            }
        }
        //스타스코어가 5이상 이라면
        else
        {
            //점프를 누르고 점프스코어가 2 아래라면
            if (Input.GetButtonDown("Jump") && jumpsco < 2)
            {
                PlayerSoundManager.Instance.JumpSoundOn();
                animator.SetBool("Walk", false);
                yVelocity = jumpPower;
                isJumping = true;
                JumpEfa();
                jumpsco += 1;
            }
            //점프를 누르고 점프를 2번초과 햇다면
            else if (Input.GetButtonDown("Jump") && jumpsco > 2)
            {
                animator.SetBool("Walk", false);
                isJumping = false;
                yVelocity = 0;
            }
            //스타스코어가 15이상이라면
            if (YA_PlayerStar.instance.hideScore)
            {
                //은신이 가능해진다
                
                //만약 버튼을 누르고 
                if (Input.GetKeyDown(KeyCode.C))
                {
                    //은신상태가 아니라면
                    if (!hide && hideCount < hideCountMax)
                    {//상태를 은신중으로 바꾸고
                        hide = true;
                        //은신상태를 킨다
                        slimCCon();
                        hideCount++;
                    }
                    else if (hide)
                    {
                        hide = false;
                        slimCCoff();
                    }
                    //5초 뒤 끈다
                    /* Invoke("slimCCoff", ccTiime);
                     //15초 뒤 은신 상태를 해제한다
                     Invoke("hideOff", ccCoolTime);*/

                }
                //별을 세 개이상 모았다면
                if (YA_PlayerStar.instance.dashScore)
                {
                    //쉬프트를 눌럿을때 대쉬상태가 아니라면
                    if(Input.GetButtonDown("Fire3") && !dash )
                    {
                        if (!cc.isGrounded)
                        {
                            //대쉬상태로 바꾸고
                            dash = true;
                            //스피드를 2배로 키운다
                            speed *= 4;
                    
                        //10초 뒤 0.5배로 바꾼다
                        Invoke("speedDown", 0.3f);
                        //20초 뒤 대쉬 상태를 해제한다
                        Invoke("dashState", 0.5f);
                        }
                    }
                    //만약 버튼을 눌럿는데 대쉬중이라면
                    if (Input.GetButtonDown("Fire3") && dash)
                    {
                        //안내글이 나간다
                        //print("쿨 도는 중");
                    }
                }
                




            }
        }
        // 이동 스크립트
        //Vector3 jump = new Vector3(0, yVelocity, 0);
        //Vector3 jumpDown = new Vector3(0, yVelocity + gravity * Time.deltaTime);
        //jump = Vector3.Lerp(jump, jumpDown, Time.deltaTime * speed * 0.2f);
        //dir.y = jumpDown.y;
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        if (cc.enabled==true)
        {
            cc.Move(dir * speed * Time.deltaTime);
        }



    }



    IEnumerator Cam()
    {
        yield return new WaitForSeconds(5f);  // yield return 을 통해 시간지연  
    }
    GameObject Jump;
    void JumpEfa()
    {
        Jump = Instantiate(JUMPFactory);
        Jump.transform.position = transform.position - new Vector3(0, 0.5f, 0);
    }

    //슬라임은신상태 키는 함수
    void slimCCon()
    {
        
        slimeCC.SetActive(true);
        gameObject.layer = LayerMask.NameToLayer("PlayerCC"); ;
        speed = 0;
    }
    //슬라임은신상태 끄는 함수
    void slimCCoff()
    {
        slimeCC.SetActive(false);
        gameObject.layer = LayerMask.NameToLayer("Player");
        speed = SPEED;
    }
    //은신상태변경
    //스피드0.5배
    void speedDown()
    {
        speed *= 0.25f;
        /*playerSpin.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerSpin.transform.rotation = Quaternion.Euler(0, 0, 0);*/
    }
    //대쉬상태변경
    void dashState()
    {
        dash = false;
    }
  
    //특정위ㅌ치에 가면 (트리거 발판 사용)(카메라위치 변경)
    //Enemy 트리거
    //조작법 트리거
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CamStage") { CamManager.Instaced.spCamTranOn();}
        if (other.tag == "CamStageOff") { CamManager.Instaced.spCamTranOff(); }
        if (other.gameObject.name.Contains("Enemy"))
        {
            cc.enabled = false;
            transform.position = pumpkinSave.transform.position;
            cc.enabled = true;
            PlayerSoundManager.Instance.ReSpawnSoundOn();
            int hideReset = 0;
            hideCount = hideReset;
        }
        if (other.gameObject.name.Contains("ManualSensor"))
        {
            manual.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("ManualSensor"))
        {
            manual.SetActive(false);
        }
    }

    public void onMovingBlock(Vector3 dist)
    {
       
        cc.Move(dist);
    }
    public void onWindBlock(float h, float v, Vector3 originPosition)
    {
        StartCoroutine(Wind(h, v, originPosition));


    }
    IEnumerator Wind(float h, float v, Vector3 originPosition)
    {


        while (transform.position.y <= originPosition.y + h)
        {
            cc.enabled = false;
            yVelocity = 0;
            Vector3 windDir = this.h * Vector3.right + Vector3.up;
            windDir.Normalize();
            transform.position += windDir * v * Time.deltaTime;
            gravity = 0;
            yield return null;
            if (transform.position.y > originPosition.y + h)
            {
                //transform.position = new Vector3(transform.position.x, originPosition.y + h + 5f,0);
                cc.enabled = true;
                gravity = -9.81f;
                break;
            }
        }
    }
    internal void OnJumpingBlock(float jumpHeight)
    {
        yVelocity = jumpHeight;
    }
    public void WindOut()
    {
        StopAllCoroutines();
        cc.enabled = true;
        gravity = -9.81f;
    }
}



