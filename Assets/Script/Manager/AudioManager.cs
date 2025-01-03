//======================================================================================================================
//
// サウンドマネージャークラス[SoundManager.cs]
//
//---- 詳細 ------------------------------------------------------------------------------------------------------------
// サウンドの再生やストップ、
// 音量などの設定関数を作成する。
// 
//----------------------------------------------------------------------------------------------------------------------
// 更新日     更新者        バージョン 更新内容
// ---------- ------------- ---------- ---------------------------------------------------------------------------------
// yyyy/MM/dd anonymous     xx.xx.xx   -
// 2025/01/02 大行佑也      00.01.00   新規作成
//======================================================================================================================
// .Net
using System;
using System.Collections.Generic;
// Unity
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BTLGeek
{
    public class SoundManager : DesignPattern.Singleton<SoundManager>
    {
        //---- 定数 --------------------------------------------------------------------------------------------------
        public const float GC_VOLUME_MAIN_MAX           = 1f;                                           // メイン音量最大値
        public const float GC_VOLUME_MAIN_MIN           = 0f;                                           // メイン音量最小値
        public const float GC_VOLUME_BGM_MAX            = 1f;                                           // BGM   音量最大値
        public const float GC_VOLUME_BGM_MIN            = 0f;                                           // BGM   音量最小値
        public const float GC_VOLUME_SE_MAX             = 1f;                                           // SE    音量最大値
        public const float GC_VOLUME_SE_MIN             = 0f;                                           // SE    音量最小値
        public const float GC_VOLUME_VOICE_MAX          = 1f;                                           // ボイス音量最大値
        public const float GC_VOLUME_VOICE_MIN          = 0f;                                           // ボイス音量最小値

        //---- メンバ --------------------------------------------------------------------------------------------------
        // オーディオソース
        private AudioSource                             m_asBGM                 = null;                 // BGM再生方法
        private AudioSource                             m_asSE                  = null;                 // SE再生方法
        private AudioSource                             m_asVoice               = null;                 // ボイス再生方法
        // オーディオクリップ
        private AudioClip                               m_acBGM                 = null;                 // BGMオーディオクリップ(サウンドファイル)
        private Dictionary<string ,AudioClip>           m_acSE                  = new();                // SEオーディオクリップ(サウンドファイル)
        private Dictionary<string ,AudioClip>           m_acVoice               = new();                // ボイスオーディオクリップ(サウンドファイル)
        // Addressableの読み込みデータ
        private AsyncOperationHandle<IList<AudioClip>>  m_HandleBGM;                                    // BGMの読み込み方法
        private AsyncOperationHandle<IList<AudioClip>>  m_HandleSE;                                     // SEの読み込み方法
        private AsyncOperationHandle<IList<AudioClip>>  m_HandleVoice;                                  // ボイスの読み込み方法
        // パラメーター
        private float                                   m_fVolumeMain           = GC_VOLUME_MAIN_MAX;   // メイン音量
        private float                                   m_fVolumeBGM            = GC_VOLUME_BGM_MAX;    // BGM音量
        private float                                   m_fVolumeSE             = GC_VOLUME_SE_MAX;     // SE音量
        private float                                   m_fVolumeVoice          = GC_VOLUME_VOICE_MAX;  // ボイス音量

        //---- プロパティ ----------------------------------------------------------------------------------------------
        /// <summary>
        /// メイン音量
        /// </summary>
        /// <remarks>
        /// 最小値 = 0.0f / 最大値 = 1.0f
        /// </remarks>
        public float VolumeMain 
        {   
            get { return m_fVolumeMain; }
            set { m_fVolumeMain = Mathf.Clamp(value, GC_VOLUME_MAIN_MIN, GC_VOLUME_MAIN_MAX); }
        }
        /// <summary>
        /// BGM音量
        /// </summary>
        /// <remarks>
        /// メイン音量の影響を受けます。
        /// 最小値 = 0.0f / 最大値 = 1.0f
        /// </remarks>
        public float VolumeBGM
        {
            get { return m_fVolumeBGM; }
            set { m_fVolumeBGM = Mathf.Clamp(value, GC_VOLUME_BGM_MIN, GC_VOLUME_BGM_MAX); }
        }
        /// <summary>
        /// SE音量
        /// </summary>
        /// <remarks>
        /// メイン音量の影響を受けます。
        /// 最小値 = 0.0f / 最大値 = 1.0f
        /// </remarks>
        public float VolumeSE
        {
            get { return m_fVolumeSE; }
            set { m_fVolumeSE = Mathf.Clamp(value, GC_VOLUME_SE_MIN, GC_VOLUME_SE_MAX); }
        }
        /// <summary>
        /// ボイス音量
        /// </summary>
        /// <remarks>
        /// メイン音量の影響を受けます。
        /// 最小値 = 0.0f / 最大値 = 1.0f
        /// </remarks>
        public float VolumeVoice
        {
            get { return m_fVolumeVoice; }
            set { m_fVolumeVoice = Mathf.Clamp(value, GC_VOLUME_VOICE_MIN, GC_VOLUME_VOICE_MAX); }
        }


        //---- メソッド ------------------------------------------------------------------------------------------------
        public void Init()
        {
            try {
                // BGM用オーディオソースの作成
                m_asBGM = new();
                m_asBGM.loop = true;//BGMはループ再生にする。
                m_asBGM.volume = (m_fVolumeMain * m_fVolumeBGM) / (GC_VOLUME_MAIN_MAX * GC_VOLUME_BGM_MAX);

                // SE用オーディオソースの作成
                m_asSE = new();
                m_asSE.loop = false;
                m_asSE.volume = (m_fVolumeMain * m_fVolumeSE) / (GC_VOLUME_MAIN_MAX * GC_VOLUME_SE_MAX);

                // ボイス用オーディオソースの作成
                m_asVoice = new();
                m_asVoice.loop = false;
                m_asVoice.volume = (m_fVolumeMain * m_fVolumeVoice) / (GC_VOLUME_MAIN_MAX * GC_VOLUME_VOICE_MAX);
            }
            catch (Exception e) {
                
            }
            finally {

            }
        }

        /// <summary>
        /// BGMの再生
        /// </summary>
        public void GFnPlayBGM()
        {

        }

        /// <summary>
        /// SEの再生
        /// </summary>
        /// <param name="rsAddressableName"></param>
        /// <param name="rObject"></param>
        public void GFnPlaySE(string rsAddressableName, GameObject rObject)
        {
            // 対象のオブジェクトにオーディオソースを追加
            var l_as = rObject.AddComponent<AudioSource>();
            l_as.loop = m_asSE.loop;
            l_as.volume = m_asSE.volume;
            // 対象のオブジェクトにSE再生状態管理用のスクリプトを追加
            // 再生終了後、自動でオーディオソースごと破棄。
//            var l_SePlay  rObject.AddComponent<>();
//            l_SePlay.AudioSouce = l_as;
//            l_SePlay.AudioClip = m_acSE[rsAddressableName];
//            l_SePlay.GFnPlay();
        }

        /// <summary>
        /// アセット読み込み
        /// </summary>
        /// <param name="rsGroupName">読み込むAddresableのグループ名</param>
        public async void GFnLoad(string rsGroupName)
        {
            AsyncOperationHandle<IList<AudioClip>> handle = Addressables.LoadAssetsAsync<AudioClip>(rsGroupName);
            var lstAudioClip = await handle.Task;

            for (int i = 0; i< lstAudioClip.Count; i++) {
                //m_acSE.Add(, lstAudioClip[i]);
            }

            AssetReference assetReference = new();

            m_asSE.clip = m_acSE["Assets/Audio/BGM/natsuyasuminotanken.mp3"];
            m_asSE.Play();
        }


        public async void GFnUnLoad()
        {


            Addressables.Release(m_HandleBGM);
            Addressables.Release(m_HandleSE);
        }
    }
}
