using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject MoveFactory;
    //��������Ʈ
    public GameObject JUMPFactory;
    public static PlayerMove instance;
    //���۹�UI
    public GameObject manual;
    //���� ���ǵ�
    public float SPEED = 5;
    //���� ����/�߷�/y�Ի� ����
    public float jumpPower = 3f;
    public float gravity = -10f;
    public float yVelocity;
    //��ų
    public bool isJumping = false;//��������
    public bool hide = false;//���� ����
    public int hideCo = 0;
    public Text HideCountText;
    public float hideCountMax = 10;
    bool dash = false;//�뽬����
    int jumpsco;//����Ƚ��
    //�̵� � ���̴� ����
    float speed;
    float h;
    float v;
    //����ī��Ʈ
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
       
        //ķ�� Ư����尡 �ƴ϶��
        if (!CamManager.Instaced.spCam)
        {
            //Mouse();

            //Ű�Է¿� ���� ������ �ٲٰ� ĳ���� �̵�
            // Ű�� ������ �÷��̾ �� ������ �ٶ󺻴�
            //Ű�� ������
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            dir = Vector3.right * h + Vector3.forward * v;
            if (Camera.main)
            {

            dir = Camera.main.transform.TransformDirection(dir);
            }
            
            //�÷��̾��� �ü��� �����δ�
            dir.Normalize();
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 1f/*Time.deltaTime * speed * 0.7f*/);

            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed * 2f/*Time.deltaTime * speed * 0.7f*/);
            }
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);




            //KeyNo();

        }
        //���� �ƴ϶��(���� Ư�������)
        else
        {
             //Mouse();

            //Ű�Է¿� ���� ������ �ٲٰ� ĳ���� �̵�
            // Ű�� ������ �÷��̾ �� ������ �ٶ󺻴�
            //Ű�� ������
            // Ű�� ������ ĳ���Ͱ� �̵��Ѵ�
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
        //������������
        //���� ������
        if (cc.isGrounded&&!OnJumpBlock)
        {
            //�������ھ 0�� �ȴ�
            jumpsco = 0;
            //������ Ʈ����
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0;
        }
        // star ���ھ� 5�� ���϶��
        if (!YA_PlayerStar.instance.dubbleJumpScore)
        {
            //����
            //������ ������ �������°� �ƴ϶��
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                PlayerSoundManager.Instance.JumpSoundOn();
                //���̺��ν�Ƽ�� �����Ŀ���
                yVelocity = jumpPower;
                /*yVelocity += gravity * Time.deltaTime;
                dir.y = yVelocity;*/
                //rigidBody.AddForce(transform.up * jumpPower);
                //�������°� �ȴ�
                isJumping = true;
                JumpEfa();
                //����Ƚ���� +1�� �ȴ�
                jumpsco += 1;
            }
        }
        //��Ÿ���ھ 5�̻� �̶��
        else
        {
            //������ ������ �������ھ 2 �Ʒ����
            if (Input.GetButtonDown("Jump") && jumpsco < 2)
            {
                PlayerSoundManager.Instance.JumpSoundOn();
                animator.SetBool("Walk", false);
                yVelocity = jumpPower;
                isJumping = true;
                JumpEfa();
                jumpsco += 1;
            }
            //������ ������ ������ 2���ʰ� �޴ٸ�
            else if (Input.GetButtonDown("Jump") && jumpsco > 2)
            {
                animator.SetBool("Walk", false);
                isJumping = false;
                yVelocity = 0;
            }
            //��Ÿ���ھ 15�̻��̶��
            if (YA_PlayerStar.instance.hideScore)
            {
                //������ ����������
                
                //���� ��ư�� ������ 
                if (Input.GetKeyDown(KeyCode.C))
                {
                    //���Ż��°� �ƴ϶��
                    if (!hide && hideCount < hideCountMax)
                    {//���¸� ���������� �ٲٰ�
                        hide = true;
                        //���Ż��¸� Ų��
                        slimCCon();
                        hideCount++;
                    }
                    else if (hide)
                    {
                        hide = false;
                        slimCCoff();
                    }
                    //5�� �� ����
                    /* Invoke("slimCCoff", ccTiime);
                     //15�� �� ���� ���¸� �����Ѵ�
                     Invoke("hideOff", ccCoolTime);*/

                }
                //���� �� ���̻� ��Ҵٸ�
                if (YA_PlayerStar.instance.dashScore)
                {
                    //����Ʈ�� �������� �뽬���°� �ƴ϶��
                    if(Input.GetButtonDown("Fire3") && !dash )
                    {
                        if (!cc.isGrounded)
                        {
                            //�뽬���·� �ٲٰ�
                            dash = true;
                            //���ǵ带 2��� Ű���
                            speed *= 4;
                    
                        //10�� �� 0.5��� �ٲ۴�
                        Invoke("speedDown", 0.3f);
                        //20�� �� �뽬 ���¸� �����Ѵ�
                        Invoke("dashState", 0.5f);
                        }
                    }
                    //���� ��ư�� �����µ� �뽬���̶��
                    if (Input.GetButtonDown("Fire3") && dash)
                    {
                        //�ȳ����� ������
                        //print("�� ���� ��");
                    }
                }
                




            }
        }
        // �̵� ��ũ��Ʈ
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
        yield return new WaitForSeconds(5f);  // yield return �� ���� �ð�����  
    }
    GameObject Jump;
    void JumpEfa()
    {
        Jump = Instantiate(JUMPFactory);
        Jump.transform.position = transform.position - new Vector3(0, 0.5f, 0);
    }

    //���������Ż��� Ű�� �Լ�
    void slimCCon()
    {
        
        slimeCC.SetActive(true);
        gameObject.layer = LayerMask.NameToLayer("PlayerCC"); ;
        speed = 0;
    }
    //���������Ż��� ���� �Լ�
    void slimCCoff()
    {
        slimeCC.SetActive(false);
        gameObject.layer = LayerMask.NameToLayer("Player");
        speed = SPEED;
    }
    //���Ż��º���
    //���ǵ�0.5��
    void speedDown()
    {
        speed *= 0.25f;
        /*playerSpin.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerSpin.transform.rotation = Quaternion.Euler(0, 0, 0);*/
    }
    //�뽬���º���
    void dashState()
    {
        dash = false;
    }
  
    //Ư������ġ�� ���� (Ʈ���� ���� ���)(ī�޶���ġ ����)
    //Enemy Ʈ����
    //���۹� Ʈ����
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



