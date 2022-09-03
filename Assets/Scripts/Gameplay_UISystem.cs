using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gameplay_UISystem : MonoBehaviour
{
    [SerializeField] private RectTransform shopMenu;
    void Start()
    {
        GameManager.Instance.OnWaveEnd += OnWaveEnd;
        GameManager.Instance.OnWaveStart += OnWaveStart;
    }

    void OnDisable()
    {
        GameManager.Instance.OnWaveEnd -= OnWaveEnd;
        GameManager.Instance.OnWaveStart -= OnWaveStart;
    }

    private void OnWaveEnd()
    {
        shopMenu.DOLocalMoveX(0, 0.3f);
    }

    private void OnWaveStart()
    {
        shopMenu.DOLocalMoveX(480,0.3f);
    }

}
