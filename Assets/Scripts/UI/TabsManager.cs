using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsManager : MonoBehaviour
{
    [SerializeField] GameObject InfosPanel;
    [SerializeField] GameObject TaxesPanel;
    [SerializeField] GameObject ProjectsPanel;

    public void ClickInfos()
    {
        InfosPanel.SetActive(true);
        TaxesPanel.SetActive(false);
        ProjectsPanel.SetActive(false);
    }
    public void ClickTaxes()
    {
        InfosPanel.SetActive(false);
        TaxesPanel.SetActive(true);
        ProjectsPanel.SetActive(false);
    }
    public void ClickProjects()
    {
        InfosPanel.SetActive(false);
        TaxesPanel.SetActive(false);
        ProjectsPanel.SetActive(true);
    }

    void Start()
    {
        ClickInfos();        
    }
}
