using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamsanHNaviLabel : MonoBehaviour
{
    public Sprite[] NaviLabel_K;
    public Sprite[] NaviLabel_E;
    public Sprite[] NaviLabel_C;
    public Sprite[] NaviLabel_J;


    Sprite[] N;


    public void NamSanClick()
    {
        N = new Sprite[Resources.LoadAll<Sprite>("NamsanH/Sprite/NamSanH").Length];
        N = Resources.LoadAll<Sprite>("NamsanH/Sprite/NamSanH");

        NaviLabel_K = new Sprite[15];
        NaviLabel_E = new Sprite[15];
        NaviLabel_C = new Sprite[15];
        NaviLabel_J = new Sprite[15];

        NaviLabel_K[0] = N[12];
        NaviLabel_K[1] = N[16];
        NaviLabel_K[2] = N[19];
        NaviLabel_K[3] = N[22];
        NaviLabel_K[4] = N[24];
        NaviLabel_K[5] = N[13];
        NaviLabel_K[6] = N[17];
        NaviLabel_K[7] = N[20];
        NaviLabel_K[8] = N[23];
        NaviLabel_K[9] = N[25];
        NaviLabel_K[10] = N[26];
        NaviLabel_K[11] = N[29];
        NaviLabel_K[12] = N[32];
        NaviLabel_K[13] = N[35];
        NaviLabel_K[14] = N[38];

        NaviLabel_E[0] = N[59];
        NaviLabel_E[1] = N[60];
        NaviLabel_E[2] = N[61];
        NaviLabel_E[3] = N[62];
        NaviLabel_E[4] = N[63];
        NaviLabel_E[5] = N[43];
        NaviLabel_E[6] = N[18];
        NaviLabel_E[7] = N[21];
        NaviLabel_E[8] = N[64];
        NaviLabel_E[9] = N[65];
        NaviLabel_E[10] = N[66];
        NaviLabel_E[11] = N[73];
        NaviLabel_E[12] = N[80];
        NaviLabel_E[13] = N[81];
        NaviLabel_E[14] = N[82];

        NaviLabel_C[0] = N[59];
        NaviLabel_C[1] = N[60];
        NaviLabel_C[2] = N[61];
        NaviLabel_C[3] = N[62];
        NaviLabel_C[4] = N[63];
        NaviLabel_C[5] = N[103];
        NaviLabel_C[6] = N[105];
        NaviLabel_C[7] = N[107];
        NaviLabel_C[8] = N[109];
        NaviLabel_C[9] = N[113];
        NaviLabel_C[10] = N[117];
        NaviLabel_C[11] = N[121];
        NaviLabel_C[12] = N[124];
        NaviLabel_C[13] = N[126];
        NaviLabel_C[14] = N[129];

        NaviLabel_J[0] = N[59];
        NaviLabel_J[1] = N[60];
        NaviLabel_J[2] = N[61];
        NaviLabel_J[3] = N[62];
        NaviLabel_J[4] = N[63];
        NaviLabel_J[5] = N[104];
        NaviLabel_J[6] = N[106];
        NaviLabel_J[7] = N[108];
        NaviLabel_J[8] = N[110];
        NaviLabel_J[9] = N[114];
        NaviLabel_J[10] = N[118];
        NaviLabel_J[11] = N[122];
        NaviLabel_J[12] = N[125];
        NaviLabel_J[13] = N[127];
        NaviLabel_J[14] = N[130];
    }
}
