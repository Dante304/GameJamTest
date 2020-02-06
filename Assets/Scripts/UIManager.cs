using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ResourcesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateResources(List<ResourceInfo> resources)
    {
        var sb = new StringBuilder();

        foreach (var resource in resources)
        {
            if (resource.PlayerId > 0)
                continue;

            sb.AppendLine($"{resource.Name}: {resource.Amount:N0} [+{Math.Floor(resource.PerTick * 60)} / sec, buildings: {resource.BuildingsAmount}]");
        }

        ResourcesText.text = sb.ToString();
    }
}
