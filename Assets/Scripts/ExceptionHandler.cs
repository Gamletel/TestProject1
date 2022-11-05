using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(Text))]
public class ExceptionHandler : MonoBehaviour
{
    public static UnityAction HaveException;

    private static Text _exceptionTextUI;
    private static Animator _animator;

    private void Awake()
    {
        _exceptionTextUI = GetComponent<Text>();
        _animator = GetComponent<Animator>();
    }

    public static void OnHaveFormatException()
    {
        _exceptionTextUI.text = "Неверный формат данных!";
        _animator.SetTrigger("haveException");
    }

    public static void OnHaveZeroValue()
    {
        _exceptionTextUI.text = "Значение не может равняться нулю / быть меньше нуля!";
        _animator.SetTrigger("haveException");
        HaveException?.Invoke();
    }
}
