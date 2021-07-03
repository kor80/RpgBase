using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set; }

    [SerializeField] Slider expBar; 
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] ParticleSystem levelUpParticles;

    private void Awake() 
    {   
        if(MainManager.Instance == null)
            return; 
        Instance = this;
    }

    private void Start() 
    {
        expBar.value = MainManager.Instance.experience;    
        levelText.text = MainManager.Instance.level.ToString();
    }

    public void IncreaseExperience(int amount)
    {
        expBar.value += (1/100)*amount;
        if(expBar.value >= expBar.maxValue)
        {
            expBar.value = 0;
            IncreaseLevel(1);
        }
    }

    public void IncreaseLevel(int amount)
    {   
        levelText.text = (MainManager.Instance.level + 1).ToString();
        levelUpParticles.Play();
    }
}
