using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject skillStar; //³²Àº º°°¹¼ö UI

    public void OnPointerEnter(PointerEventData eventData)
    {
            skillStar.gameObject.SetActive(true);
            skillStar.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
            skillStar.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

}
