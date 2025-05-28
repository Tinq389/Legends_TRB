using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthGlobe, manaGlobe;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private PlayerHealth health;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private GameObject levelCompleteText;
    void Start()
    {
        LevelManager.instance.levelGained.AddListener(OnLevelGained);
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthGlobe.fillAmount = Mathf.Lerp(
            healthGlobe.fillAmount, health.GetHealthRatio(), 2 * Time.deltaTime);
    }

    public void UpdateXpSlider(float xpRatio)
    {
        xpSlider.value = xpRatio;
    }
    
    public void ShowLevelComplete()
    {
        levelCompleteText.SetActive(true);
        StartCoroutine(HideLevelCompleteAfterDelay());
    }
    
    private IEnumerator HideLevelCompleteAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        levelCompleteText.SetActive(false);
    }
    
    private void OnLevelGained(int newLevel)
    {
        ShowLevelComplete();
        UpdateLevelText(newLevel);
    }
}
