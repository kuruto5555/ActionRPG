using System;
using UnityEngine;

namespace BTLGeek.Common
{
    /// <summary>
    /// シングルトンクラス
    /// </summary>
    /// <typeparam name="T">継承クラス</typeparam>
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        /*---- メンバ変数 ----*/
        /// <summary>
        /// インスタンス
        /// </summary>
        [field: NonSerialized]
        public static T Instance { get; private set; } = null;


        /*---- メソッド ----*/
        /// <summary>
        /// オブジェクト生成時に呼ばれる
        /// </summary>
        void Awake()
        {
            // すでに生成されているかの判定
            if (Instance != null) {
                // 既に生成済みの場合
                // エラーログ表示
                Debug.LogError(typeof(T) + "は既に他のオブジェクトにアタッチされているため破棄しました。\n"
                               + "既にアタッチされているオブジェクト：" + Instance.gameObject.name + "\n"
                               + "今回アタッチしたオブジェクト      ：" + gameObject.name);

                // 既存を残して、自分を破棄する
                Destroy(this);
            }
            else {
                // まだ生成されていない場合
                // 自分をInstanceに設定
                Instance = (T)this;
            }
        }

        /// <summary>
        /// オブジェクトが破棄されるときに呼ばれる
        /// </summary>
        private void OnDestroy()
        {
            // インスタンスと自分が同じかの判定
            if(Instance == this) {
                // 同じだった場合は、破棄する。
                Instance = null;
            }
            else {
                // 違っていた場合は、間違って生成したものなので何もしない。
            }
        }
    }
}