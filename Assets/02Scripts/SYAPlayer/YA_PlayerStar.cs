using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YA_PlayerStar : MonoBehaviour
{
    public static YA_PlayerStar instance;
    public int starScore = 0;
    public int starScoreOne = 5;
    public int starScoreTwo = 15;
    public int starScoreThree = 30;
    public bool dubbleJumpScore = false;
    public bool hideScore = false;
    public bool dashScore = false;
    public GameObject ddJumpUI;
    public GameObject hideUI;
    public GameObject dashUI;
    public GameObject ddJumpUIOff;
    public GameObject hideUIOff;
    public GameObject dashUIOff;
    public GameObject ddSkillUI;
    public GameObject hiSkillUI;
    public GameObject daSkillUI;
    public Text CountText;
    public Text ddSkillCountText;
    public Text hiSkillCountText;
    public Text daSkillCountText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        ddJumpUI.SetActive(false);
        ddJumpUIOff.SetActive(true);

        hideUI.SetActive(false);
        hideUIOff.SetActive(true);

        dashUI.SetActive(false);
        dashUIOff.SetActive(true);

        ddSkillUI.SetActive(false);
        hiSkillUI.SetActive(false);
        daSkillUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = starScore.ToString();
        ddSkillCountText.text = starScore.ToString() + "/" + starScoreOne.ToString();
        hiSkillCountText.text = starScore.ToString() + "/" + starScoreTwo.ToString();
        daSkillCountText.text = starScore.ToString() + "/" + starScoreThree.ToString();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            starScore += 1;
            PlayerSoundManager.Instance.StarGetSoundOn();
            Destroy(other.gameObject);

            if (starScore >= starScoreOne)
            {
                dubbleJumpScore = true;
                ddJumpUI.SetActive(true);
                if (starScore == starScoreOne)
                {
                    PlayerSoundManager.Instance.StarGetSoundOff();

                    ddSkillUI.SetActive(true);
                    PlayerSoundManager.Instance.SkillGetSoundOn();
                    ddJumpUIOff.SetActive(false);
                    Invoke("DbJump", 6f);
                }
            }
            if (starScore >= starScoreTwo)
            {
                hideScore = true;
                hideUI.SetActive(true);
                if (starScore == starScoreTwo)
                {
                    PlayerSoundManager.Instance.StarGetSoundOff();
                    hiSkillUI.SetActive(true);
                    PlayerSoundManager.Instance.SkillGetSoundOn();
                    hideUIOff.SetActive(false);
                    Invoke("Hide", 6f);
                }
            }
            if (starScore >= starScoreThree)
            {
                dashScore = true;
                dashUI.SetActive(true);
                if (starScore == starScoreThree)
                {
                    PlayerSoundManager.Instance.StarGetSoundOff();
                    daSkillUI.SetActive(true);
                    PlayerSoundManager.Instance.SkillGetSoundOn();
                    dashUIOff.SetActive(false);
                    Invoke("Dash", 6f);
                }
            }

        }

    }

    //스타 1개 더하기
    void DbJump()
    {
        ddSkillUI.SetActive(false);
    }
    void Hide()
    {
        hiSkillUI.SetActive(false);
    }
    void Dash()
    {
        daSkillUI.SetActive(false);
    }


}