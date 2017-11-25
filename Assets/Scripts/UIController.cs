using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using VRStandardAssets.Common;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public UIFader introUI;
    public UIFader outroUI;
    public UIFader playerUI;
    public Text totalscore;
    public Text highscore;

    public IEnumerator ShowIntroUI()
    {
        yield return StartCoroutine(introUI.InteruptAndFadeIn());
    }
    public IEnumerator HideIntroUI()
    {
        yield return StartCoroutine(introUI.InteruptAndFadeOut());
    }

    public IEnumerator ShowOutroUI()
    {
        totalscore.text = SessionData.Score.ToString();
        highscore.text = SessionData.HighScore.ToString();
        yield return StartCoroutine(outroUI.InteruptAndFadeIn());
    }
    public IEnumerator HideOutroUI()
    {
        yield return StartCoroutine(outroUI.InteruptAndFadeOut());
    }
    public IEnumerator ShowPlayerUI()
    {
        yield return StartCoroutine(playerUI.InteruptAndFadeIn());
    }
    public IEnumerator HidePlayerUI()
    {
        yield return StartCoroutine(playerUI.InteruptAndFadeOut());
    }
    
}