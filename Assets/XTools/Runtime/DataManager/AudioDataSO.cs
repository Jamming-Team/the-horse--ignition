using System;
using System.Collections.Generic;
using Alchemy.Serialization;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace XTools {
    [CreateAssetMenu(fileName = "AudioDataSO", menuName = "XTools/AudioDataSO", order = 0)]
    public class AudioDataSO : ScriptableObject {
        [Range(0.01f, 1f)]
        public float musicVolume;
        [Range(0.01f, 1f)]
        public float sfxVolume;
        [Range(0.01f, 1f)]
        public float uiVolume;
        public MusicData music;
    }
    
    [Serializable]
    public class MusicData {
        // public List<AudioClip> audioClips;
        // [AlchemySerializeField, NonSerialized]
        [SerializedDictionary("Type", "Bundle")]
        public SerializedDictionary<MusicBundleType, MusicBundle> bundles = new();

        public float crossFadeTime = 2.0f;
    }

    [Serializable]
    public class MusicBundle {
        public List<AudioClip> audioClips;
        public bool shouldLoopFirstClip;
    }

    public enum MusicBundleType {
        MainMenu,
        Gameplay
    }
}