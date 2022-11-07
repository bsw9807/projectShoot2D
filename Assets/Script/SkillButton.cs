using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Skill_Type
{
    ST_Gold001,
    ST_Gold002,
    ST_Gold003,
    ST_Gold004,
    ST_Gold005,
    ST_Gold006,
}

public enum EnchantState
{
    ES_Learn, // ½Àµæ
    ES_Enable, // ½Àµæ °¡´É
    ES_Disable, // ½Àµæ ºÒ°¡
}

public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private Image blockImg;
    [SerializeField]
    private Image subBlockImg;

    [SerializeField]
    private SkillButton prevButton;
    [SerializeField]
    private SkillButton nextButton;

    private EnchantState cState;

    public EnchantState STATE
    {
        get { return cState; }
        set { cState = value; }
    }

    [SerializeField]
    private Skill_Type cType;

    public Skill_Type TYPE
    {
        get { return cType; }
    }

    [SerializeField]
    private int upgradeGroupLevel;

    public void InitButton(bool isLearn, int playerLevel)
    {
        subBlockImg.gameObject.SetActive(true);
        blockImg.gameObject.SetActive(true);
        STATE = EnchantState.ES_Disable;

        if (isLearn)
        {
            STATE = EnchantState.ES_Learn;
        }
        else
        {
            if(prevButton != null)
            {
                if(playerLevel >= upgradeGroupLevel && prevButton.STATE == EnchantState.ES_Learn)
                {
                    subBlockImg.gameObject.SetActive(false);
                    STATE = EnchantState.ES_Enable;
                }
                else if(playerLevel >= upgradeGroupLevel)
                {
                    subBlockImg.gameObject.SetActive(false);
                    STATE = EnchantState.ES_Enable;
                }
            }
        }
    }
}
