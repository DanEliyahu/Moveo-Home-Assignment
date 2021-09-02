using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpinWheel : MonoBehaviour
{
    [SerializeField] private List<string> prize;
    [SerializeField] private List<AnimationCurve> animationCurves;
    [SerializeField] [Range(1, 10)] private int spinSpeed = 2;
    [SerializeField] private GameObject backButton;
    [SerializeField] private Animator winScreenAnimator;
    [SerializeField] private Text winningText;

    private bool _spinning;
    private float _anglePerItem;
    private int _randomTime;
    private int _itemNumber;
    private static readonly int FadeIn = Animator.StringToHash("FadeIn");

    private void Start()
    {
        _spinning = false;
        _anglePerItem = 360 / prize.Count;
    }

    public void Spin()
    {
        if (!_spinning)
        {
            _randomTime = Random.Range(1, 4);
            _itemNumber = Random.Range(0, prize.Count);
            float maxAngle = 360 * spinSpeed * _randomTime + (_itemNumber * _anglePerItem);

            StartCoroutine(SpinTheWheel(3 * _randomTime, maxAngle));
        }
    }

    IEnumerator SpinTheWheel(float time, float maxAngle)
    {
        _spinning = true;
        backButton.SetActive(false);

        float timer = 0.0f;
        float startAngle = transform.eulerAngles.z;
        maxAngle = maxAngle - startAngle;

        int animationCurveNumber = Random.Range(0, animationCurves.Count);

        while (timer < time)
        {
            //to calculate rotation
            float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }

        transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);

        // Make winScreen show
        yield return new WaitForSeconds(0.5f);
        winScreenAnimator.SetTrigger(FadeIn);
        winningText.text = prize[_itemNumber];
        yield return new WaitForSeconds(0.5f);

        _spinning = false;
        backButton.SetActive(true);
    }
}