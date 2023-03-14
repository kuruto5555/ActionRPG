using System.Collections.Generic;
using UnityEngine;

namespace BTLGeek.Common
{
    /// <summary>
    /// オブザーバーパターンの登録者インターフェース
    /// </summary>
    public interface ISubscriber
    {
        void Reception(int eventType, Object @object);
    }

    /// <summary>
    /// オブザーバーパターンの観察者
    /// </summary>
    public class Observer
    {
        /*---- メンバ変数 ----*/
        /// <summary> 通知を受ける者たち </summary>
        private List<ISubscriber> subscriberList_ = null;

        /*---- メソッド ----*/
        /// <summary>
        /// 契約
        /// </summary>
        /// <param name="subscriber">契約者</param>
        public void Subscribe(ISubscriber subscriber)
        {
            // 登録者がnullでないなら登録する
            if (subscriber != null) {
                subscriberList_.Add(subscriber);
            }
        }

        /// <summary>
        /// 解約
        /// </summary>
        /// <param name="canceler">解約者</param>
        public void Release(ISubscriber canceler)
        {
            subscriberList_.Remove(canceler);
        }

        /// <summary>
        /// 登録者に通知
        /// </summary>
        /// <param name="eventType">通知する種別</param>
        /// <param name="object"></param>
        protected void NotifySubscribers(int eventType, Object @object = null)
        {
            foreach (ISubscriber subscriber in subscriberList_) {
                // 登録者がnullでないか判定
                if (subscriber == null) {
                    // nullの場合はリストから削除しておく
                    subscriberList_.Remove(subscriber);
                }
                else {
                    // nullでない場合は通知する
                    subscriber.Reception(eventType, @object);
                }
            }
        }
    }
}
