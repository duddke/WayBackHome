using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFactory : MonoBehaviour
{
    
    //[System.NonSerialized]
    public GameObject platFormFactory;
     float creatTime;
    [Header ("Platform CreatTime, Size")]
    //플랫폼 생성 시간 
    // 최소 생성시간 최대 생성시간
    public float minCreatTime;
    public float maxCreatTime;
    // 최대 최소 크기 X
    public float minXscale;
    public float maxXscale;
    // 최대 최소 크기 Z
    public float minZscale;
    public float maxZscale;
    [Header("Platform Type Value")]

    //플랫폼 나올 확률
    public float esclatorPosible;
    public float gravityPosible;
    public float slipperyPosible;
    public float swtichDirPossible;

     GameObject platFormGroup;

    public List<GameObject> platformPool = new List<GameObject>();
    public int platCount = 20;
    
    int platRanvalue;

    //플랫폼 타입
    //전역으로 한번만 만듦 배열 세칸
    PlatForms[] platTypes = new PlatForms[4];
    //MonoBehaviour[] t = new MonoBehaviour[3];

    //생산라인을 판단하기위한 ID 생성
    public int id;



    float curTime;

    // FactoryManager에서 제어 스피드를 MovingPlat에 넣어주는 역할만함
    [System.NonSerialized]
    public float PlatformSpeed;

    void Start()
    {
        // 생성된 플랫폼그룹
        platFormGroup = GameObject.Find("Platformgroup");
        creatTime = Random.Range(minCreatTime, maxCreatTime);
        
        // 시작에서 플랫폼 뽑아놓는다
        for (int i = 0; i < platCount; i++)
        {
            // 카운트만큼 만들어놓고
            GameObject platform = Instantiate(platFormFactory, platFormGroup.transform);
           //다끈다
            platform.SetActive(false);
            // 리스트에 더하고
            platformPool.Add(platform);

            //플랫폼 팩토리에서 나올때 각 레일별로 speed를 변경하고싶다
            //플랫폼 스피드 각 생산라인에서 제어
            platform.gameObject.GetComponent<MovingPlatform>().speed = PlatformSpeed;
            // 찍어내는 platform마다 생산라인 ID 각인
            platform.gameObject.GetComponent<MovingPlatform>().id = id;
            // 인스턴스한 오브제에 생산라인이 해당객체 변수 할당
            platform.gameObject.GetComponent<MovingPlatform>().platFactory = this;


            //스케일 지정해줍니다
            platform.transform.localScale = new Vector3(Random.Range(minXscale, maxXscale), 1, Random.Range(minZscale, maxZscale));
            // 생산라인 위치로
            platform.transform.position = this.transform.position;

            platTypes[0] = platform.gameObject.GetComponent<EsclatorPlatform>();
            platTypes[1] = platform.gameObject.GetComponent<GravityPlatform>();
            platTypes[2] = platform.gameObject.GetComponent<SlipperyFlatform>();
            platTypes[3] = platform.gameObject.GetComponent<SwitchdirPlatform>();




            platRanvalue = Random.Range(0, 10);
            //ex 타입[0]은 0 1 타입1은 ep 타입2는 gp 
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


            //만약 포지션 x 가 음수라면 방향은 Vector3.right
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

            //// 생성시간 다시랜덤
            //creatTime =  Random.Range(minCreatTime, maxCreatTime);
            ////플랫폼타임 다시랜덤
            //platRanvalue = Random.Range(0, 10);

            curTime = 0;
        }
    }
}
