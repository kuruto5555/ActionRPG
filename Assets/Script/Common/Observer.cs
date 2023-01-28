using System.Collections.Generic;
using UnityEngine;

namespace BTLGeek.Common
{
    /// <summary>
    /// 観察者
    /// 
    /// </summary>
    public abstract class IObserver
    {
        /*---- 通知を受け取る者たち ----*/
        /// <summary>
        /// 
        /// </summary>
        List<Object> objects_ = null;

        /*---- メソッド ----*/
        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// 契約
        /// </summary>
        /// <typeparam name="T">契約者のクラス</typeparam>
        /// <param name="">契約者</param>
        public void Subscribe<T>(T subscriber) where T : Object
		{
            // 登録者の判定
            if (subscriber != null) {
                // 登録者がnullだった場合
                Debug.LogError("登録者がnullです。");
            }

            // 登録
            Debug.Log(subscriber.name + "を、" + this.ToString() + "に登録します。");
            objects_.Add(subscriber);
        }
    }
}
