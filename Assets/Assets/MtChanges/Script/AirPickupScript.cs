using UnityEngine;
using UnityEngine.UI;

public class AirPickupScript : MonoBehaviour
{
    // Об'єкт повітря
    public GameObject Air;

    // Початкова кількість повітря
    public float BeginingAirValue;

    // Кількість секунд перед початком споживання повітря
    public float StartAirConsumingDelay;

    // Кількість секунд між вживанням повітря
    public float AirConsumingDelay;

    // Кількість повітря яке буде зніматися клжен інтервал часу(AirConsumingDelay)
    public float AirChangeValue;

    // Кількість зібраного повітря
    public static float AirCollected;
    public Text AirCounter;

    void Start()
    {
        // Присвоюєм початкове значення повітря
        AirCollected = BeginingAirValue;

        // Оновлюємо кількість зібраного повітря на екрані
        string str = AirCollected.ToString();
        AirCounter.text = str + " м³";

        // Кожні 2 секунди викликаємо функцію споживання повітря
        InvokeRepeating("AirConsume", StartAirConsumingDelay, AirConsumingDelay);
    }

    public void AirConsume()
    {
        // Якщо кількість повітря дорівнює 0 то гра завершується
        if(AirCollected <= 0)
        {
            // Завершуємо гру
            Application.Quit();
            Debug.Log("Game Over");
        }
        // Зменшуєм кількість повітря якщо його більше 0
        else if(AirCollected > 0)
        {
            // Віднімаємо паливо
            AirCollected -= AirChangeValue;

            // Оновлюємо кількість зібраного повітря на екрані
            string str = AirCollected.ToString();
            AirCounter.text = str + " м³";
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
         // Якщо об'єктом зіткнення є повітря
        if (collision.gameObject.CompareTag("Air"))
        {
            // Підбираємо повітря
            Destroy(collision.gameObject);

            // Збільшуємо кількість зібраного повітря
            AirCollected++;

            // Відображаємо кількість зібраного повітря на екрані
            string str = AirCollected.ToString();
            AirCounter.text = str + " м³";
        }
    }
}
