using System.Collections.Generic;
using UnityEngine;

public class Description
{    
    private Description(string title, string description) { this.title = title; this.description = description; }
 
    public string title { get; private set; }
    public string description { get; private set; }

    public static Description HEALTH { get { return new Description("Health Potion", "You are healed!"); } }
    public static Description PARALYLIS { get { return new Description("Potion of Paralysis", "You are paralyzed!"); } }
    public static Description SPEED { get { return new Description("Potion of Speed", "You are faster than ever!"); } }
    public static Description FIRE { get { return new Description("Potion of Fire", "You catch fire!"); } }
    public static Description BARKSKIN { get { return new Description("Potion of Barkskin", "You skin is thicker and more resistant!"); } }

    public static Description GetPotionDescription(int index)
    {
        return new List<Description>()
        {
            HEALTH, PARALYLIS, SPEED, FIRE, BARKSKIN
        }[index];  
    }    
}
