﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Configs
    [SerializeField] private int goldReward = 25;
    [SerializeField] private int goldPenalty = 25;

    private Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank == null) { return; }
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(goldPenalty);
    }
}
