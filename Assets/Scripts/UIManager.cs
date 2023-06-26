using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
   // UIManager  es un singleton
   public static UIManager sharedInstance;

   [SerializeField] private TextMeshProUGUI coinsCounterText;
   [SerializeField] private TextMeshProUGUI totalCoinsText;
   [SerializeField] private GameObject pressEKeyPanel;
   [SerializeField] private TextMeshProUGUI usernameText;

   // Configuramos que UIManager  sea un singleton
   private void Awake()
   {
      if (sharedInstance == null)
      {
         sharedInstance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }

   private void Start()
   {
      SetCoinsText(0);
      SetUserName();
   }

   public void SetCoinsText(int coins)
   {
      coinsCounterText.text = coins.ToString();
   }

   public void SetTotalCoinsText(int totalCoins)
   {
      totalCoinsText.text = "/ " + coins;
   }

   public void ShowPressEKeyPanel()
   {
      pressEKeyPanel.SetActive(true);
   }

   public void HidePressEKeyPanel()
   {
      pressEKeyPanel.SetActive(false);
   }
   
   private void SetUserName()
   {
      string username;
      if (PlayerPrefs.HasKey(UIManagerOptions.PLAYER_USERNAME))
      {
         username = PlayerPrefs.GetString(UIManagerOptions.PLAYER_USERNAME);
      }
      else
      {
         username = "Guest";
      }

      usernameText.text = username;
   }
      
}
