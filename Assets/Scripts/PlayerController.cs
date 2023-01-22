using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    //создаем переменную типа аниматор
   [SerializeField] private Animator _animator;
    
    //создаем поле со скоростью
    private static readonly int Uppercut = Animator.StringToHash("uppercut");
    private static readonly int Speed = Animator.StringToHash("speed");

    //создаем рандомайзер, чтобы удар игрок наносил случайный
    private Random randomNum = new Random();
    private static readonly int RundomNum = Animator.StringToHash("randomNum");
    private static readonly int SetWPressed = Animator.StringToHash("keyWPressed");
    private static readonly int SetSPressed = Animator.StringToHash("keySPressed");

    //передаем значение аниматора в переменную
    private void Awake()
    {
        _animator.GetComponent<Animator>();
    }
    
    
    void Update()
    {
        //при нажатии на W отправлять тру, иначе фолс
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool(SetWPressed,true);
        }
        else
        {
            _animator.SetBool(SetWPressed,false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool(SetSPressed,true);
        }
        else
        {
            _animator.SetBool(SetSPressed,false);
        }

        //при нажатии на ЛКМ передаем тригер и рандомный инт, от которого зависит вариант удара
        if (Input.GetMouseButtonDown(0))
        {
            int number = randomNum.Next(0, 2);
            _animator.SetTrigger(Uppercut);
            _animator.SetInteger(RundomNum,number);
        }
        
    }
}
