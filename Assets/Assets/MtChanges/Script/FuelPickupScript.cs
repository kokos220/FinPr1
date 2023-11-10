using UnityEngine;
using UnityEngine.UI;

public class FuelPickupScript : MonoBehaviour
{
    // Об'єкт палива
    public GameObject Fuel;

    // Початкова кількість палива
    public float BeginingFuelValue;

    // Кількість секунд перед початком споживання палива
    public float StartFuelConsumingDelay;

    // Кількість секунд між вживанням палива
    public float FuelConsumingDelay;

    // Кількість палива яке буде зніматися клжен інтервал часу(FuelConsumingDelay)
    public float FuelChangeValue;

    // Кількість зібраного палива
    public static float FuelCollected;
    public Text FuelCounter;

    void Start()
    {
        // Присвоюєм початкове значення палива
        FuelCollected = BeginingFuelValue;

        // Оновлюємо кількість зібраного палива на екрані
        string str = FuelCollected.ToString();
        FuelCounter.text = str + " л";

        // Кожні 2 секунди викликаємо функцію споживання палива
        InvokeRepeating("FuelConsume", StartFuelConsumingDelay, FuelConsumingDelay);
    }

    public void FuelConsume()
    {
        // Якщо кількість палива дорівнює 0 то гра завершується
        if(FuelCollected <= 0)
        {
            // Завершуємо гру
            Application.Quit();
            Debug.Log("Game Over");
        }
        // Зменшуєм кількість палива якщо його більше 0
        else if(FuelCollected > 0)
        {
            // Віднімаємо паливо
            FuelCollected -= FuelChangeValue;

            // Оновлюємо кількість зібраного палива на екрані
            string str = FuelCollected.ToString();
            FuelCounter.text = str + " л";
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
         // Якщо об'єктом зіткнення є паливо
        if (collision.gameObject.CompareTag("Fuel"))
        {
            // Підбираємо паливо
            Destroy(collision.gameObject);

            // Збільшуємо кількість зібраного палива
            FuelCollected++;

            // Відображаємо кількість зібраного палива на екрані
            string str = FuelCollected.ToString();
            FuelCounter.text = str + " л";
        }
    }
}
