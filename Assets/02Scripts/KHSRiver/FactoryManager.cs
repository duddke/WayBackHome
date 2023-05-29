using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager instance;
    private void Awake()
    {
        instance = this;
    }
    //������� ����
    public int platCount = 10;

    //���� �յڰ���
    public float platSpacing;

    public GameObject[] platArray;



    public GameObject productLine;
    public GameObject endFloorFactory;
    public GameObject destroyZoneFactory;
    public GameObject underWaterPlaneFactory;
    public GameObject WaterfallFactory;
    public GameObject FoamParticleFactory;
    public GameObject StreamParticleFactory;
    public GameObject waterplaneSoundFactory;




    public GameObject wallFactory;
    public Transform startFloor;


    // ��������κ� ���ǵ�
    public float Minplatformspeed;
    public float Maxplatformspeed;

    //�߽����κ��� ������ΰ���
    public float productLineSpacing;
    //�߽����κ��� ��������
    public float wallSpacing;

    // ���� �ѱ���
    float wallweidth;

    //�߽����κ��� ��Ʈ������ ����
    public float destroySpacing;

    void Start()
    {
        platArray = new GameObject[platCount];

        //��ġ�� ��ġ�Ұǵ� ����ġ�� ���念���̰� ���������� �ҰŴ�

        for (int i = 0; i < platArray.Length; i++)
        {



            //�ϴ� ��������� ����� ���ڽĵ��
            productLine = Instantiate(productLine, gameObject.transform);
            platArray[i] = productLine.gameObject;


            //������� �ӵ� �������� �ٸ����ҰԿ�
            productLine.GetComponent<PlatFactory>().PlatformSpeed = Random.Range(Minplatformspeed, Maxplatformspeed);
            // ������ο��� ID �ο��ϰڽ��ϴٿ�
            productLine.GetComponent<PlatFactory>().id = i;


            //���� ������ �ӵ��� ��Ʈ��

            //Ȧ���� ��������� �����̰�   (�����̸� dir �������̴� MovingPlatform ���� ����)
            if ((i + 1) % 2 == 1)
            {
                productLine.transform.position = new Vector3(transform.position.x - productLineSpacing, transform.position.y, transform.position.z + platSpacing * (i + 1));
            }
            //¦���� ��������� �������̴� (�������̸� dir �����̴� MovingPlatform ���� ����)
            else if ((i + 1) % 2 == 0)
            {
                productLine.transform.position = new Vector3(transform.position.x + productLineSpacing, transform.position.y, transform.position.z + platSpacing * (i + 1));
            }
            // Ending Point�� ���丮 ��ġ���� z dir���� (�÷����ǰ���+1) *5 (����) ���� ���鲨�� ,endFloor ũ��� startFloor ũ��
            if ((platArray.Length - 1) == i)
            {
                GameObject endFloor = Instantiate(endFloorFactory);

                endFloor.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platSpacing * (i + 2));
                //endFloor.transform.localScale = new Vector3(startFloor.localScale.x, startFloor.localScale.y, startFloor.localScale.z);

            }

            



            //�ΰ��� �����
            if (i + 1 <= 2)
            {
                // ��Ʈ������
                GameObject destroyZone = Instantiate(destroyZoneFactory);
                GameObject waterfall = Instantiate(WaterfallFactory);

                //����
                GameObject wall = Instantiate(wallFactory);
                //Ȧ��
                if ((i + 1) % 2 == 1)
                {
                    //Waterfall ����
                    waterfall.gameObject.transform.position = new Vector3(transform.position.x - (wallSpacing + 10f), transform.position.y + 20f, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    waterfall.transform.localScale = new Vector3(3f, 5f, (float)(platCount + 1) / 2 * (i + 2) * (platSpacing) / 4.5f);
                    waterfall.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);

                    //���ʰ��� ��ġ ������
                    wall.gameObject.transform.position = new Vector3(transform.position.x - wallSpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    wallweidth = (float)(platCount + 1) / 2 * (i + 2) * (platSpacing);
                    wall.transform.localScale = new Vector3(1, 30f, wallweidth);
                    // ���� ��Ʈ������ ��ġ ������
                    destroyZone.gameObject.transform.position = new Vector3(transform.position.x - destroySpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    destroyZone.transform.localScale = new Vector3(1, 30f, (float)(platCount + 1) / 2 * (i + 2) * (platSpacing));

                    destroyZone.gameObject.GetComponent<AudioSource>().enabled = true;

                }
                //¦��
                if ((i + 1) % 2 == 0)
                {
                    //Waterfall ����

                    waterfall.gameObject.transform.position = new Vector3(transform.position.x + (wallSpacing + 10f), transform.position.y + 20f, transform.position.z + (float)(platCount + 1) / 2 * (i) * (platSpacing));
                    waterfall.transform.localScale = new Vector3(3f, 5f, (float)(platCount + 1) / 2 * (i + 1) * (platSpacing) / 4.5f);



                    //������ ���� ��ġ ������
                    wall.gameObject.transform.position = new Vector3(transform.position.x + wallSpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i) * (platSpacing));
                    wall.transform.localScale = new Vector3(1, 20, (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    // ������ ��Ʈ������ ��ġ ������
                    destroyZone.gameObject.transform.position = new Vector3(transform.position.x + destroySpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i) * (platSpacing));
                    destroyZone.transform.localScale = new Vector3(1, 50f, (float)(platCount + 1) / (float)2 * (i + 1) * (platSpacing));

                   AudioSource waterfallSound= destroyZone.gameObject.GetComponent<AudioSource>();
                    waterfallSound.enabled = true;
                    waterfallSound.PlayDelayed(3);


                }
            }
            //�ؿ��� ��Ʈ������
            if (i == 0)
            {
                GameObject destroyZone = Instantiate(destroyZoneFactory);
                GameObject underWater = Instantiate(underWaterPlaneFactory);


                //��ġ
                destroyZone.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                destroyZone.transform.localScale = new Vector3(destroySpacing * 2, 2, (float)(platCount + 1) / 2 * (i + 3) * (platSpacing));

                // 
                underWater.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z - 10f);
                underWater.transform.localScale = new Vector3((float)(platCount + 1) / 2 * (i + 2) / 1f * (platSpacing), 2, destroySpacing * 2 / 2f);

                // WaterfallSound �̴´�
                GameObject waterfallSound = Instantiate(waterplaneSoundFactory);
                waterfallSound.transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));

            }
        }
        float foamParticleCount = wallweidth / 4;
        for (int i = 0; i < foamParticleCount; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject foamParticle = Instantiate(FoamParticleFactory);
                //Ȧ���� ��ƼŬ�� �����̰�   
                if (j == 0)
                {
                    foamParticle.transform.position = new Vector3(transform.position.x - productLineSpacing, transform.position.y-22f, transform.position.z + 4 * (i + 1));
                }
                //¦���� ��ƼŬ��  �������̴� 
                else if (j == 1)
                {
                    foamParticle.transform.position = new Vector3(transform.position.x + productLineSpacing, transform.position.y-22f, transform.position.z + 4 * (i + 1));
                    // -90���� ������
                    foamParticle.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y -90f, transform.rotation.z);
                }
            }
            for (int j = 0; j < 2; j++)
            {
                GameObject streamParticle = Instantiate(StreamParticleFactory);
                //Ȧ���� ��ƼŬ�� �����̰�   
                if (j == 0)
                {
                    streamParticle.transform.position = new Vector3(transform.position.x - productLineSpacing, transform.position.y, transform.position.z + 4 * (i + 1));
                }
                //¦���� ��ƼŬ��  �������̴� 
                else if (j == 1)
                {
                    streamParticle.transform.position = new Vector3(transform.position.x + productLineSpacing, transform.position.y, transform.position.z + 4 * (i + 1));
                    // -90���� ������
                    streamParticle.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90f, transform.rotation.z);
                }
            }


        }
    }
}
