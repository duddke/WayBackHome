using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //GameObject platFactory;
    // Start is called before the first frame update
    void Start()
    {
        //platFactory= GameObject.Find
    }

    // Update is called once per frame
 
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌거에서 몇번 생산라인에서 나왔는지 체크
        //MovingPlatform mov = other.gameObject.GetComponent<MovingPlatform>();
        //print(mov);
        if (other.gameObject.layer==LayerMask.NameToLayer("Platform"))
        {
            MovingPlatform mov = other.gameObject.GetComponent<MovingPlatform>();
            if(mov != null)
            {
                other.gameObject.SetActive(false);
            
                FactoryManager.instance.platArray[mov.id].gameObject.GetComponent<PlatFactory>().platformPool.Add(other.gameObject);
                //mov.platFactory.platformPool.Add(other.gameObject);


                 // 디스트로이존에 들어갈때 플랫폼 초기화
                if (other.gameObject.GetComponent<SlipperyFlatform>().enabled == true)
                {
                    other.gameObject.GetComponent<SlipperyFlatform>().PlayerX = 0;
                    other.gameObject.GetComponent<SlipperyFlatform>().PlatRotX = 0;

                    other.gameObject.GetComponent<SlipperyFlatform>().PlayerZ = 0;
                    other.gameObject.GetComponent<SlipperyFlatform>().PlayerZ = 0;
                    //other.gameObject.transform.eulerAngles = Vector3.zero;


                }
                else if (other.gameObject.GetComponent<GravityPlatform>().enabled == true)
                {
                    other.gameObject.transform.Find("GravityRain").gameObject.SetActive(false);
                    other.gameObject.GetComponent<GravityPlatform>().tempGravity = 0;
                    mov.speed = other.gameObject.GetComponent<GravityPlatform>().mpTempSpeed;
                }
                else if (other.gameObject.GetComponent<SwitchdirPlatform>().enabled == true)
                {
                    other.gameObject.GetComponent<SwitchdirPlatform>().changeAblecount = 1;
                }



            }
        }
        else
        {
            if (other.gameObject.layer==LayerMask.NameToLayer("Player"))
            {
                other.gameObject.transform.position = GameObject.Find("WaterfallSceneQuick").transform.position;
                PlayerSoundManager.Instance.ReSpawnSoundOn();
            }
        }
    }
}
