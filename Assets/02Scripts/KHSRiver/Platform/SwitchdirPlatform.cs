using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchdirPlatform : PlatForms
{
    public TextMeshProUGUI text;

    public GameObject player;
    public bool IsonPlat;
    public MovingPlatform[] mp;
    //생산라인들
    PlatFactory[] pfArray;
    PlatFactory pf;
    public GameObject platformGroup;
    public GameObject factoryMaster;
    public int changeAblecount = 1;
    bool isChanged;


    public GameObject icon;
    // Start is called before the first frame update
    void Start()
    {

        //text.text = "<->";
        icon.SetActive(true);
        player = GameObject.Find("Player");
        factoryMaster = GameObject.Find("FactoryMaster");
        platformGroup = GameObject.Find("Platformgroup");

    }
    private void Update()
    {
        SwitchingDir();
    }


    private void SwitchingDir()
    {

        if (IsonPlat && !isChanged && changeAblecount > 0)
        {
            
            changeAblecount--;
            // Scene의 platforms 그룹의 instance 들의  Movingplatform 의 dir에 -1 을 곱하고싶다.
            // 그리고 Productline 의 포지션의 x에 값에 -1을 곱한다

            // platforms 그룹을 알고싶다 

            // 그 그룹 자식들의 Movingplatform 컴포넌트 가져온다
            mp = platformGroup.GetComponentsInChildren<MovingPlatform>();
            // 자식들의 dir 에 -1 을  곱한다
            for (int i = 0; i < mp.Length; i++)
            {
                mp[i].dir = mp[i].dir * -1;
            }

            isChanged = true;

            //pf = GetComponent<PlatFactory>();
            ////Platformpool 리스트에 등록되어있는 오브젝트의 방향을 바꾸고싶다.
            //for (int i = 0; i < pf.platformPool.Count; i++)
            //{
            //    GameObject platform = pf.platformPool[i];
            //    platform.GetComponent<MovingPlatform>().dir = platform.GetComponent<MovingPlatform>().dir * -1;

            //}


            // 팩토리  마스터의 자식 PlatFactory 들의 배열을 가져온다
            pfArray = factoryMaster.GetComponentsInChildren<PlatFactory>();
            for (int i = 0; i < pfArray.Length; i++)
            {
                pfArray[i].transform.localPosition = new Vector3(-1f * pfArray[i].transform.localPosition.x, pfArray[i].transform.localPosition.y, pfArray[i].transform.localPosition.z);
                pf = pfArray[i]. GetComponent<PlatFactory>();
                for (int j = 0; j < pfArray[i].platformPool.Count; j++)
                {
                    
                    GameObject platform = pf.platformPool[j];
                    platform.GetComponent<MovingPlatform>().dir = platform.GetComponent<MovingPlatform>().dir * -1;
                }
            }
            // 홀수는 왼쪽 짝수는 오른쪽이다
            // 근데 상관없네 그냥 포지션 x 에 -1곱해라(만들어진 생산라인위치 반전)

        }
        if (!IsonPlat)
        {
            isChanged = false;
        }
    }
}
