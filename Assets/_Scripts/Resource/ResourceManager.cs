using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [SerializeField] private float m_Budget;
    [SerializeField] private float m_CurrentBudget;

    [SerializeField] private int m_WaterBill;
    [SerializeField] private int m_GasBill;

    private bool m_GameOver;

    [Header("Water")]
    [Tooltip("Maximum water capacity in Liters")]
    [SerializeField]private float m_MaxWaterCapacity;     
    [Tooltip("Current water capacity in Liters")]
    [SerializeField] private float m_CurrentWaterAmount;
    [Tooltip("Water consumption in Liters per second")]
    [SerializeField] private float m_WaterConsumption;    
    private bool m_WaterExhaustedEventTriggered;

    [Header("Gas")]
    [Tooltip("Maximum gas capacity in Liters")]
    [SerializeField] private float m_MaxGasCapacity;      
    [Tooltip("Current gas capacity in Liters")]
    [SerializeField] private float m_CurrentGasAmount;  
    [Tooltip("Gas consumption in Liters per second")]
    [SerializeField] private float m_GasConsumption;      
    private bool m_GasExhaustedEventTriggered;

    [Header("UI")]
    [Header("Texts")]
    [SerializeField] private TMPro.TextMeshProUGUI m_BudgetText;
    [SerializeField] private TMPro.TextMeshProUGUI m_WaterLeftText;
    [SerializeField] private TMPro.TextMeshProUGUI m_GasLeftText;
    //[SerializeField] private TMPro.TextMeshProUGUI m_PowerConsumptionText;

    [Header("Foregrounds")]
    [SerializeField] private Image m_BudgetForeground;
    [SerializeField] private Image m_WaterForeground;
    [SerializeField] private Image m_GasForeground;
    //[SerializeField] private Image m_PowerForeground;


    public static System.Action OnBudgetExhausted;
    public static System.Action OnWaterExhausted;
    public static System.Action OnGasExhausted;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        m_CurrentBudget = m_Budget;            
        m_CurrentWaterAmount = m_MaxWaterCapacity;
        m_CurrentGasAmount = m_MaxGasCapacity;

    }

    void Update()
    {
        if (m_GameOver)
            return;

        UpdateTexts();
        ValidateData();
        UpdateData();
        UpdateForegrounds();
    }

    private void UpdateTexts()
    {
        m_BudgetText.text = "$ " + m_CurrentBudget.ToString("F0");

        m_WaterLeftText.text = (m_CurrentWaterAmount / m_MaxWaterCapacity * 100).ToString("F0") + " %";
        m_GasLeftText.text = (m_CurrentGasAmount / m_MaxGasCapacity * 100).ToString("F0") + " %";

        //m_PowerConsumptionText.text = "0";
    }

    private void ValidateData()
    {
        if (m_CurrentBudget < 0 )
        {
            m_CurrentBudget = 0;

            OnBudgetExhausted?.Invoke();

            m_GameOver = true;
        }

        if (m_CurrentWaterAmount < 0 && !m_WaterExhaustedEventTriggered)
        {
            m_CurrentWaterAmount = 0;

            OnWaterExhausted?.Invoke();
            m_WaterExhaustedEventTriggered = true;

            m_GameOver = true;
        }

        if (m_CurrentGasAmount < 0 && !m_GasExhaustedEventTriggered)
        {
            m_CurrentGasAmount = 0;

            OnGasExhausted?.Invoke();
            m_GasExhaustedEventTriggered = true;

            m_GameOver = true;
        }
    }      
    
    private void UpdateData()
    {
        m_CurrentWaterAmount -= m_WaterConsumption * Time.deltaTime;
        m_CurrentGasAmount -= m_GasConsumption * Time.deltaTime;
    }

    private void UpdateForegrounds()
    {
        m_BudgetForeground.fillAmount = (float)m_CurrentBudget / m_Budget;
        //m_PowerForeground.fillAmount = 0;

        m_WaterForeground.fillAmount = m_CurrentWaterAmount / m_MaxWaterCapacity;
        m_GasForeground.fillAmount = m_CurrentGasAmount / m_MaxGasCapacity;


    }

    public void DecreaseBudget(float amount)
    {
        m_CurrentBudget -= amount;
    }
}
