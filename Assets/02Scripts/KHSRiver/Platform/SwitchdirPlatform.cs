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
    //������ε�
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
            // Scene�� platforms �׷��� instance ����  Movingplatform �� dir�� -1 �� ���ϰ�ʹ�.
            // �׸��� Productline �� �������� x�� ���� -1�� ���Ѵ�

            // platforms �׷��� �˰�ʹ� 

            // �� �׷� �ڽĵ��� Movingplatform ������Ʈ �����´�
            mp = platformGroup.GetComponentsInChildren<MovingPlatform>();
            // �ڽĵ��� dir �� -1 ��  ���Ѵ�
            for (int i = 0; i < mp.Length; i++)
            {
                mp[i].dir = mp[i].dir * -1;
            }

            isChanged = true;

            //pf = GetComponent<PlatFactory>();
            ////Platformpool ����Ʈ�� ��ϵǾ��ִ� ������Ʈ�� ������ �ٲٰ�ʹ�.
            //for (int i = 0; i < pf.platformPool.Count; i++)
            //{
            //    GameObject platform = pf.platformPool[i];
            //    platform.GetComponent<MovingPlatform>().dir = platform.GetComponent<MovingPlatform>().dir * -1;

            //}


            // ���丮  �������� �ڽ� PlatFactory ���� �迭�� �����´�
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
            // Ȧ���� ���� ¦���� �������̴�
            // �ٵ� ������� �׳� ������ x �� -1���ض�(������� ���������ġ ����)

        }
        if (!IsonPlat)
        {
            isChanged = false;
        }
    }
}
