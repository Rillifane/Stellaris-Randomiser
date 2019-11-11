using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ethos : Government {

    public enum EthosType
    {
        Fanatic_Militarist,
        Fanatic_Xenophobe,
        Fanatic_Egalitarian,
        Fanatic_Materialist,
        Fanatic_Pacifist,
        Fanatic_Xenophile,
        Fanatic_Authoritarian,
        Fanatic_Spiritualist,
        Hive_Mind,
        Machine_Intelligence
    }

    public EthosType ethosType;

    public List<int> traitIDs;
    public List<int> civicIDs;
	
}
