using System.Collections;
using UnityEngine;

public class Player_SizeControl : MonoBehaviour
{
    [Range(1, 2)]
    [SerializeField] private float growMultiplier;
    [Range(.1f, 1)]
    [SerializeField] private float shrinkMultiplier;
    [Range(0, 25)]
    [SerializeField] private float lerpSpeed;

    private bool shouldResetScale = false;
    private bool cooldownActive = false;
    private bool shouldGrow = false;
    private bool shouldShrink = false;
    private float timeTarget = Mathf.Infinity;
    private Vector2 defaultScale = new();
    private Vector2 growScale = new();
    private Vector2 shrinkScale = new();
    private Vector2 targetScale = new();

    public bool CooldownActive => cooldownActive;
    public bool ShouldResetScale => shouldResetScale;
    public bool ShouldGrow => shouldGrow;
    public bool ShouldShrink => shouldShrink;

    public void SetCooldownActive(bool b) => cooldownActive = b;
    public void SetShouldGrow(bool b) => shouldGrow = b;
    public void SetShouldShrink(bool b) => shouldShrink = b;
    public void SetShouldResetScale(bool b) => shouldResetScale = b;
    public void SetResetTimer(float timer) => timeTarget = Time.time + timer;

    private void Start()
    {
        AssignValues();
    }

    private void Update()
    {
        RunSizeChange();
    }

    private void AssignValues()
    {
        defaultScale = transform.localScale;
        growScale = defaultScale * growMultiplier;
        shrinkScale = defaultScale * shrinkMultiplier;
        targetScale = defaultScale;
    }

    private void RunSizeChange()
    {
        if (Time.time >= timeTarget && cooldownActive)
            Game_Manager.instance.OnScaleReset();

        if (shouldGrow)
            targetScale = growScale;

        if (shouldShrink)
            targetScale = shrinkScale;

        if (shouldResetScale)
            targetScale = defaultScale;

        float distance = Vector2.Distance(transform.localScale, targetScale);

        if (distance >= .01f)
            transform.localScale = Vector2.Lerp(transform.localScale, targetScale, lerpSpeed * Time.deltaTime);

        else if (distance <= .01f)
        {
            SetShouldGrow(false);
            SetShouldShrink(false);
            if (shouldResetScale)
            {
                timeTarget = Mathf.Infinity;
                SetShouldResetScale(false);
            }
        }
    }
}
