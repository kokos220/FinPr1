using UnityEngine;
using UnityEngine.UI;

public class MetalPickupScript : MonoBehaviour
{
    // Об'єкт металу
    public GameObject Metal;

    // Початкова кількість металу
    public float BeginingMetalValue;

    // Кількість секунд перед початком споживання метала
    public float StartMetalConsumingDelay;

    // Кількість секунд між вживанням метала
    public float MetalConsumingDelay;

    // Кількість метала яке буде зніматися клжен інтервал часу(MetalConsumingDelay)
    public float MetalChangeValue;

    // Кількість зібраного металу
    public static float MetalCollected;
    public Text MetalCounter;

    // Тег обєкта який буде завдавати шкоди кораблю віднімаючи кількість метала
    public string ItemTagThatDamageShip;

    // Кількість металу яка буде знята при зіткненні з іншими обєктами
    public float DamageToShipByOtherItems;

    // Кількість часу між полученням ушкодження від обєктів, щоб при зіткненні з одним обєктом ушкодження не проходило кілька разів
    public float damageInterval;

    // Змінна для перевірки зіткнення корабля протягом інтервалу(damageInterval)
    private bool isCollided;

    void Start()
    {
        // Присвоюєм початкове значення металу
        MetalCollected = BeginingMetalValue;

        // Оновлюємо кількість зібраного металу на екрані
        string str = MetalCollected.ToString();
        MetalCounter.text = str + " м²";

        // Кожні 2 секунди викликаємо функцію споживання метала
        InvokeRepeating("MetalConsume", StartMetalConsumingDelay, MetalConsumingDelay);
    }

    public void MetalConsume()
    {
        // Якщо кількість метала дорівнює 0 то гра завершується
        if(MetalCollected <= 0)
        {
            // Завершуємо гру
            Application.Quit();
            Debug.Log("Game Over");
        }
        // Зменшуєм кількість метала якщо його більше 0
        else if(MetalCollected > 0)
        {
            // Віднімаємо метал
            MetalCollected -= MetalChangeValue;

            // Оновлюємо кількість зібраного метала на екрані
            string str = MetalCollected.ToString();
            MetalCounter.text = str + " м²";
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Якщо об'єктом зіткнення є метал
        if (collision.gameObject.CompareTag("Metal"))
        {
            // Підбираємо метал
            Destroy(collision.gameObject);

            // Збільшуємо кількість зібраного металу
            MetalCollected++;

            // Відображаємо кількість зібраного металу на екрані
            string str = MetalCollected.ToString();
            MetalCounter.text = str + " м²";
        }
        // Якщо об'єктом зіткнення є інший обєкт
        else if(collision.gameObject.CompareTag(ItemTagThatDamageShip))
        {
            if(isCollided)
            {
                return;
            } 
            // Наносимо ушкодження
            ApplyDamage();

            // Зазначаємо, що було зіткнення
            isCollided = true;    

            // Відкладаємо повторення виконання коду на кілька секунд.
            Invoke("ResetCollision", damageInterval);
        }
    }
    private void ResetCollision()
    {
        // Обнулюємо стан зіткнення.
        isCollided = false;
    }
    public void ApplyDamage()
    {
        // Віднімаємо метал при зіткненні з обєктами
        MetalCollected -= DamageToShipByOtherItems;

        // Оновлюємо кількість зібраного метала на екрані
        string str = MetalCollected.ToString();
        MetalCounter.text = str + " м²";
    }
}

