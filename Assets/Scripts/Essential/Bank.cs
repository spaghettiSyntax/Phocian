using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private TextMeshProUGUI displayBalance;

    // Properties
    [SerializeField] private int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        if (amount < 0) { Debug.Log("Amount for deposit was less than zero, Mathf.Abs still used."); };
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        if (amount > 0) { Debug.Log("Amount for withdraw was greater than zero, Mathf.Abs still used."); };
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            // Lost the game
            ReloadScene();
        }
    }

    private void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
