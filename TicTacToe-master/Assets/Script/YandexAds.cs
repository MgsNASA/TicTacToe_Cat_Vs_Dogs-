using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class YandexAds : MonoBehaviour
{
    [DllImport ( "__Internal" )]
    private static extern void ShowAdv( );

    private void Start( )
    {
        YandexGame.FullscreenShow ();
    }
}
