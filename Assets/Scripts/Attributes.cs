using UnityEngine;

[CreateAssetMenu(fileName = "Attributes", menuName = "RpgBase/Attribute", order = 0)]
public class Attributes : ScriptableObject
{
    public static Attributes Instance {get; private set; }

    public int level;
    public string name;
    public Vector3 playerPosition;
}
