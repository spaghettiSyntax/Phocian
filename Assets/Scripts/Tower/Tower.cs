﻿using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) { return false; }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
