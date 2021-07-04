using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set; }

    [SerializeField] Slider expBar; 
    [SerializeField] public Text nameText;
    [SerializeField] public GameObject insertNamePanel;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] ParticleSystem levelUpParticles;
    public float destinationValue = 0f;

    private void Awake() 
    {   
        if(MainManager.Instance == null)
            return; 
        Instance = this;
    }

    private void Start() 
    {
        if(!MainManager.Instance.name.Equals(""))
            SetName(MainManager.Instance.name);
        else
            insertNamePanel.SetActive(true);

        expBar.value = MainManager.Instance.experience;    
        levelText.text = MainManager.Instance.level.ToString();
    }

    private void Update() 
    {
        IncreaseExpBar();
    }

    public void IncreaseExperience(int amount)
    {
        destinationValue += (1/(float)100)*amount;
    }

    public void IncreaseLevel(int amount)
    {   
        levelText.text = (MainManager.Instance.level + 1).ToString();
        levelUpParticles.Play();
        MainManager.Instance.level++;
    }

    private void IncreaseExpBar()
    {
        if(expBar.value < destinationValue)
        {
            expBar.value += Time.deltaTime;
            if(expBar.value >= expBar.maxValue)
            {
                destinationValue -= expBar.maxValue; 
                expBar.value = 0;
                IncreaseLevel(1);
            }
        } 
    } 

    public void SetName(string name)
    {   nameText.text = name;
    }
}
