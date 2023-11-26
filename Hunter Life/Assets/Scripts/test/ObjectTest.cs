using UnityEngine;

public class ObjectTest : ScriptableObject
{

    [CreateAssetMenu(fileName = "NewMyScriptableObject", menuName = "Custom/Create My ScriptableObject")]
    public class MyScriptableObject : ScriptableObject
    {
        public string itemName;

    }



}
