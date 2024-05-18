using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Objective
{
    public string objectiveName;
    public bool isCompleted;
    public ObjectiveType objectiveType; 
    public Sprite emptyCircleImage;
    public Sprite filledCircleImage; 

    public Objective(string objectiveName, ObjectiveType objectiveType, Sprite emptyCircleImage, Sprite filledCircleImage)
    {
        this.objectiveName = objectiveName;
        this.objectiveType = objectiveType;
        this.emptyCircleImage = emptyCircleImage;
        this.filledCircleImage = filledCircleImage;
    }

}

public enum ObjectiveType
{
    TurnOffLights,
    TurnOffACs,
}


