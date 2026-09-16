using System;
using UnityEngine;

[Serializable]
public class BaseStats
{
    [SerializeField] private int baseLive;
    [SerializeField] private float baseMoveSpeed;

    public BaseStats(int _baseLive,float _baseMoveSpeed)
    {
        baseLive = _baseLive;
        baseMoveSpeed = _baseMoveSpeed;

    }

    public int BaseLive => baseLive;
    public float BaseMoveSpeed => baseMoveSpeed;
}
