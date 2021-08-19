using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;

public class HpManager : MonoBehaviour
{
    [SerializeField] public Image[] heaths;
    [SerializeField] int _startHp;
    int tmpnt = 0;

    private void Awake()
    {
        _startHp = heaths.Length * 2;
    }

    public void GetHp(int damage)
    {
        _startHp -= damage;
        Image tmp = heaths[tmpnt];
        StartCoroutine(AnimDed(heaths[tmpnt]));
        tmpnt += 1;

    }
    IEnumerator AnimDed(Image img)
    {
        float t = 0;
        while (img.fillAmount > 0)
        {
            img.fillAmount = Mathf.Lerp(1, 0, t);
            t += Time.deltaTime * 2;
            yield return null;
        }

    }
}
