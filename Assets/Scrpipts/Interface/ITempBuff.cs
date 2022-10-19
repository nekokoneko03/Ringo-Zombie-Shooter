using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITempBuff
{
    // バフを適応するメソッド
    void Adapt();

    // 適応したバフを削除するメソッド
    void OffAdapt();
}
