using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CheatManager : MonoBehaviour
{
    public TMP_InputField cheatInput;
    public TMP_Text feedbackText;
    public TMP_Text coinDisplay;
    public ShopControl shopControl; // Optional: if you want to update lock icons

    public void SubmitCheat()
    {
        string code = cheatInput.text.Trim().ToLower();

        if (code == "getrich")
        {
            MasterInfo.coinCount += 9999;
            feedbackText.text = "💰 Cheat activated: +9999 Coins!";
            coinDisplay.text = "Coins: " + MasterInfo.coinCount;
        }
        else if (code == "unlockall")
        {
            LevelSelector.UnlockLevel("City");
            LevelSelector.UnlockLevel("Mountains");

            feedbackText.text = "🔓 Cheat activated: All levels unlocked!";
            coinDisplay.text = "Coins: " + MasterInfo.coinCount;

            // Optional: refresh lock icons
            if (shopControl != null)
            {
                shopControl.RefreshLockIcons();
            }
        }
        else
        {
            feedbackText.text = "❌ Invalid cheat code.";
        }

        cheatInput.text = ""; // Clear input
    }
}
