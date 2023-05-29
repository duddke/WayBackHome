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
    //생산라인 갯수
    public int platCount = 10;

    //라인 앞뒤간격
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


    // 각생산라인별 스피드
    public float Minplatformspeed;
    public float Maxplatformspeed;

    //중심으로부터 생산라인간격
    public float productLineSpacing;
    //중심으로부터 가벽간격
    public float wallSpacing;

    // 가벽 총길이
    float wallweidth;

    //중심으로부터 디스트로이존 간격
    public float destroySpacing;

    void Start()
    {
        platArray = new GameObject[platCount];

        //위치를 배치할건데 내위치는 월드영점이고 내기준으로 할거다

        for (int i = 0; i < platArray.Length; i++)
        {



            //일단 생산라인을 만들고 내자식들로
            productLine = Instantiate(productLine, gameObject.transform);
            platArray[i] = productLine.gameObject;


            //생산라인 속도 랜덤으로 다르게할게용
            productLine.GetComponent<PlatFactory>().PlatformSpeed = Random.Range(Minplatformspeed, Maxplatformspeed);
            // 생산라인에게 ID 부여하겠습니다요
            productLine.GetComponent<PlatFactory>().id = i;


            //생산 라인의 속도를 컨트롤

            //홀수면 생산라인이 왼쪽이고   (왼쪽이면 dir 오른쪽이다 MovingPlatform 에서 제어)
            if ((i + 1) % 2 == 1)
            {
                productLine.transform.position = new Vector3(transform.position.x - productLineSpacing, transform.position.y, transform.position.z + platSpacing * (i + 1));
            }
            //짝수면 생산라인이 오른쪽이다 (오른쪽이면 dir 왼쪽이다 MovingPlatform 에서 제어)
            else if ((i + 1) % 2 == 0)
            {
                productLine.transform.position = new Vector3(transform.position.x + productLineSpacing, transform.position.y, transform.position.z + platSpacing * (i + 1));
            }
            // Ending Point는 팩토리 위치에서 z dir으로 (플랫폼의개수+1) *5 (간격) 으로 만들꺼다 ,endFloor 크기는 startFloor 크기
            if ((platArray.Length - 1) == i)
            {
                GameObject endFloor = Instantiate(endFloorFactory);

                endFloor.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platSpacing * (i + 2));
                //endFloor.transform.localScale = new Vector3(startFloor.localScale.x, startFloor.localScale.y, startFloor.localScale.z);

            }

            



            //두개만 만든다
            if (i + 1 <= 2)
            {
                // 디스트로이존
                GameObject destroyZone = Instantiate(destroyZoneFactory);
                GameObject waterfall = Instantiate(WaterfallFactory);

                //가벽
                GameObject wall = Instantiate(wallFactory);
                //홀수
                if ((i + 1) % 2 == 1)
                {
                    //Waterfall 좌측
                    waterfall.gameObject.transform.position = new Vector3(transform.position.x - (wallSpacing + 10f), transform.position.y + 20f, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    waterfall.transform.localScale = new Vector3(3f, 5f, (float)(platCount + 1) / 2 * (i + 2) * (platSpacing) / 4.5f);
                    waterfall.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);

                    //왼쪽가벽 위치 스케일
                    wall.gameObject.transform.position = new Vector3(transform.position.x - wallSpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    wallweidth = (float)(platCount + 1) / 2 * (i + 2) * (platSpacing);
                    wall.transform.localScale = new Vector3(1, 30f, wallweidth);
                    // 왼쪽 디스트로이존 위치 스케일
                    destroyZone.gameObject.transform.position = new Vector3(transform.position.x - destroySpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    destroyZone.transform.localScale = new Vector3(1, 30f, (float)(platCount + 1) / 2 * (i + 2) * (platSpacing));

                    destroyZone.gameObject.GetComponent<AudioSource>().enabled = true;

                }
                //짝수
                if ((i + 1) % 2 == 0)
                {
                    //Waterfall 우측

                    waterfall.gameObject.transform.position = new Vector3(transform.position.x + (wallSpacing + 10f), transform.position.y + 20f, transform.position.z + (float)(platCount + 1) / 2 * (i) * (platSpacing));
                    waterfall.transform.localScale = new Vector3(3f, 5f, (float)(platCount + 1) / 2 * (i + 1) * (platSpacing) / 4.5f);



                    //오른쪽 가벽 위치 스케일
                    wall.gameObject.transform.position = new Vector3(transform.position.x + wallSpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i) * (platSpacing));
                    wall.transform.localScale = new Vector3(1, 20, (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                    // 오른쪽 디스트로이존 위치 스케일
                    destroyZone.gameObject.transform.position = new Vector3(transform.position.x + destroySpacing, transform.position.y, transform.position.z + (float)(platCount + 1) / 2 * (i) * (platSpacing));
                    destroyZone.transform.localScale = new Vector3(1, 50f, (float)(platCount + 1) / (float)2 * (i + 1) * (platSpacing));

                   AudioSource waterfallSound= destroyZone.gameObject.GetComponent<AudioSource>();
                    waterfallSound.enabled = true;
                    waterfallSound.PlayDelayed(3);


                }
            }
            //밑에쪽 디스트로이존
            if (i == 0)
            {
                GameObject destroyZone = Instantiate(destroyZoneFactory);
                GameObject underWater = Instantiate(underWaterPlaneFactory);


                //위치
                destroyZone.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z + (float)(platCount + 1) / 2 * (i + 1) * (platSpacing));
                destroyZone.transform.localScale = new Vector3(destroySpacing * 2, 2, (float)(platCount + 1) / 2 * (i + 3) * (platSpacing));

                // 
                underWater.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z - 10f);
                underWater.transform.localScale = new Vector3((float)(platCount + 1) / 2 * (i + 2) / 1f * (platSpacing), 2, destroySpacing * 2 / 2f);

                // WaterfallSound 뽑는다
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
                //홀수면 파티클이 왼쪽이고   
                if (j == 0)
                {
                    foamParticle.transform.position = new Vector3(transform.position.x - productLineSpacing, transform.position.y-22f, transform.position.z + 4 * (i + 1));
                }
                //짝수면 파티클이  오른쪽이다 
                else if (j == 1)
                {
                    foamParticle.transform.position = new Vector3(transform.position.x + productLineSpacing, transform.position.y-22f, transform.position.z + 4 * (i + 1));
                    // -90도ㅓ 돌려줌
                    foamParticle.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y -90f, transform.rotation.z);
                }
            }
            for (int j = 0; j < 2; j++)
            {
                GameObject streamParticle = Instantiate(StreamParticleFactory);
                //홀수면 파티클이 왼쪽이고   
                if (j == 0)
                {
                    streamParticle.transform.position = new Vector3(transform.position.x - productLineSpacing, transform.position.y, transform.position.z + 4 * (i + 1));
                }
                //짝수면 파티클이  오른쪽이다 
                else if (j == 1)
                {
                    streamParticle.transform.position = new Vector3(transform.position.x + productLineSpacing, transform.position.y, transform.position.z + 4 * (i + 1));
                    // -90도ㅓ 돌려줌
                    streamParticle.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90f, transform.rotation.z);
                }
            }


        }
    }
}
