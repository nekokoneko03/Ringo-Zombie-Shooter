using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/New Item")]
public class ItemProperties : ScriptableObject
{
    [SerializeField] private Image icon;
    [SerializeField] new private string name;
    [TextArea]
    [SerializeField] private string description;

    public Image Icon { get => icon; }
    public string Name { get => name; }
    public string Description { get => description; }
}
