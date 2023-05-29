using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFactory : MonoBehaviour
{
    
    //[System.NonSerialized]
    public GameObject platFormFactory;
     float creatTime;
    [Header ("Platform CreatTime, Size")]
    //�÷��� ���� �ð� 
    // �ּ� �����ð� �ִ� �����ð�
    public float minCreatTime;
    public float maxCreatTime;
    // �ִ� �ּ� ũ�� X
    public float minXscale;
    public float maxXscale;
    // �ִ� �ּ� ũ�� Z
    public float minZscale;
    public float maxZscale;
    [Header("Platform Type Value")]

    //�÷��� ���� Ȯ��
    public float esclatorPosible;
    public float gravityPosible;
    public float slipperyPosible;
    public float swtichDirPossible;

     GameObject platFormGroup;

    public List<GameObject> platformPool = new List<GameObject>();
    public int platCount = 20;
    
    int platRanvalue;

    //�÷��� Ÿ��
    //�������� �ѹ��� ���� �迭 ��ĭ
    PlatForms[] platTypes = new PlatForms[4];
    //MonoBehaviour[] t = new MonoBehaviour[3];

    //��������� �Ǵ��ϱ����� ID ����
    public int id;



    float curTime;

    // FactoryManager���� ���� ���ǵ带 MovingPlat�� �־��ִ� ���Ҹ���
    [System.NonSerialized]
    public float PlatformSpeed;

    void Start()
    {
        // ������ �÷����׷�
        platFormGroup = GameObject.Find("Platformgroup");
        creatTime = Random.Range(minCreatTime, maxCreatTime);
        
        // ���ۿ��� �÷��� �̾Ƴ��´�
        for (int i = 0; i < platCount; i++)
        {
            // ī��Ʈ��ŭ ��������
            GameObject platform = Instantiate(platFormFactory, platFormGroup.transform);
           //�ٲ���
            platform.SetActive(false);
            // ����Ʈ�� ���ϰ�
            platformPool.Add(platform);

            //�÷��� ���丮���� ���ö� �� ���Ϻ��� speed�� �����ϰ�ʹ�
            //�÷��� ���ǵ� �� ������ο��� ����
            platform.gameObject.GetComponent<MovingPlatform>().speed = PlatformSpeed;
            // ���� platform���� ������� ID ����
            platform.gameObject.GetComponent<MovingPlatform>().id = id;
            // �ν��Ͻ��� �������� ��������� �ش簴ü ���� �Ҵ�
            platform.gameObject.GetComponent<MovingPlatform>().platFactory = this;


            //������ �������ݴϴ�
            platform.transform.localScale = new Vector3(Random.Range(minXscale, maxXscale), 1, Random.Range(minZscale, maxZscale));
            // ������� ��ġ��
            platform.transform.position = this.transform.position;

            platTypes[0] = platform.gameObject.GetComponent<EsclatorPlatform>();
            platTypes[1] = platform.gameObject.GetComponent<GravityPlatform>();
            platTypes[2] = platform.gameObject.GetComponent<SlipperyFlatform>();
            platTypes[3] = platform.gameObject.GetComponent<SwitchdirPlatform>();




            platRanvalue = Random.Range(0, 10);
            //ex Ÿ��[0]�� 0 1 Ÿ��1�� ep Ÿ��2�� gp 
            //esclator
            if (platRanvalue < esclatorPosible)
            {
                platTypes[0].enabled = true;
                //platTypes[0].gameObject.transform.Find("Cloud").gameObject.GetComponentInChildren<Renderer>().material.color = Color.blue;

            }
            //Gravity

            else if (platRanvalue < esclatorPosible + gravityPosible)
            {
                platTypes[1].enabled = true;
                platTypes[1].gameObject.transform.Find("Cloud").gameObject.GetComponentInChildren<Renderer>().material.color = Color.black;


            }
            //Slippery

            else if (platRanvalue < esclatorPosible + gravityPosible + slipperyPosible)
            {
                platTypes[2].enabled = true;
                platform.transform.localScale = new Vector3(4, 1, 4);

                //platTypes[2].gameObject.transform.Find("Cloud").gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;

            }
            //Switch
            else if (platRanvalue < esclatorPosible + gravityPosible + slipperyPosible + swtichDirPossible)
            {
                platTypes[3].enabled = true;
                //platTypes[3].gameObject.transform.Find("Cloud").gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;

            }


            //���� ������ x �� ������� ������ Vector3.right
            if (transform.position.x < FactoryManager.instance.transform.position.x)
            {
                platform.gameObject.GetComponent<MovingPlatform>().dir = Vector3.right;
            }
            else
            {
                platform.gameObject.GetComponent<MovingPlatform>().dir = Vector3.left;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CreatePlatform();    
    }

    private void CreatePlatform()
    {
        curTime += Time.deltaTime;
        if (curTime > creatTime)
        {
            GameObject platform = platformPool[0];
            platform.SetActive(true);
            platform.transform.position = transform.position;
            platformPool.RemoveAt(0);

            //// �����ð� �ٽ÷���
            //creatTime =  Random.Range(minCreatTime, maxCreatTime);
            ////�÷���Ÿ�� �ٽ÷���
            //platRanvalue = Random.Range(0, 10);

            curTime = 0;
        }
    }
}
