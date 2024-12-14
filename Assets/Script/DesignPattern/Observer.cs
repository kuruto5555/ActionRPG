//======================================================================================================================
//
// オブザーバーパターン[Observer.cs]
//
//---- 詳細 ------------------------------------------------------------------------------------------------------------
// オブザーバーパターンクラスとサブスクライバーインターフェースを定義する。
// 
//----------------------------------------------------------------------------------------------------------------------
// 更新日     更新者        バージョン 更新内容
// ---------- ------------- ---------- ---------------------------------------------------------------------------------
// yyyy/MM/dd anonymous     xx.xx.xx   -
// 2023/03/15 大行佑也      00.00.01   新規作成
//======================================================================================================================
using System.Collections.Generic;

namespace BTLGeek.DesignPattern
{
    /// <summary>
    /// オブザーバーパターンの登録者インターフェース
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// 登録者インターフェイズ
        /// </summary>
        /// <param name="viEventType">通知する種別</param>
        /// <param name="roData">任意のデータ</param>
        void GFnReception(int viEventType, ref object roData);
    }

    /// <summary>y
    /// オブザーバーパターンの観察者
    /// </summary>
    public class Observer
    {
        /// <summary> 通知を受ける者たち </summary>
        private List<ISubscriber> m_lstSubscriberList = new();

        /// <summary>
        /// 契約
        /// </summary>
        /// <param name="subscriber">契約者</param>
        public void GFnSubscribe(ISubscriber rSubscriber)
        {
            // 渡されたのがnullなら終わり
            if (rSubscriber == null) return;
            
            // 登録者がnullでないなら登録する
            m_lstSubscriberList.Add(rSubscriber);
        }

        /// <summary>
        /// 解約
        /// </summary>
        /// <param name="canceler">解約者</param>
        public void GFnRelease(ISubscriber rCanceler)
        {
            m_lstSubscriberList.Remove(rCanceler);
        }

        /// <summary>
        /// 登録者に通知
        /// </summary>
        /// <param name="viEventType">通知する種別</param>
        /// <param name="roData">任意のデータ</param>
        protected void LFnNotifySubscribers(int viEventType = 0, object roData = null)
        {
            // 通知
            foreach (ISubscriber subscriber in m_lstSubscriberList) {
                // nullでない場合は通知する
                subscriber?.GFnReception(viEventType, ref roData);
            }

        }
    }
}
