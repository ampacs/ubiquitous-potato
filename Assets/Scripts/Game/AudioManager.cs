using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance { get; private set; }
    public Sound[] sounds;

    private int _numberOfSounds;
    private AudioSource _audioSource;

    [System.Serializable]
    public struct Sound {
        [HideInInspector]
        public AudioSource source;
        public string name;
        public GameObject gameObject;
        [Space]
        public AudioClip clip;
        public AudioMixerGroup output;
        [Space]
        public bool mute;
        public bool bypassEffects;
        public bool bypassListenerEffects;
        public bool bypassReverbZones;
        public bool playOnAwake;
        public bool loop;
        [Space]
        [Range(0, 256)]
        public int priority;
        [Range(0f, 1f)]
        public float volume;
        [Range(-3f, 3f)]
        public float pitch;
        [Range(-1f, 1f)]
        public float stereoPan;
        [Range(0f, 1f)]
        public float spatialBlend;
        [Range(0f, 1.1f)]
        public float reverbZoneMix;
        [Space]
        [Range(0f, 5f)]
        public float dopplerLevel;
        [Range(0f, 360f)]
        public float spread;
        public AudioRolloffMode volumeRolloff;
        public float minDistance;
        public float maxDistance;

        public void GenerateAudioSource () {
            source = gameObject.AddComponent<AudioSource>();
            source.clip                  = clip;
            source.outputAudioMixerGroup = output;

            source.mute                  = mute;
            source.bypassEffects         = bypassEffects;
            source.bypassListenerEffects = bypassListenerEffects;
            source.bypassReverbZones     = bypassReverbZones;
            source.playOnAwake           = playOnAwake;
            source.loop                  = loop;

            source.priority      = priority;
            source.volume        = volume;
            source.pitch         = pitch;
            source.panStereo     = stereoPan;
            source.spatialBlend  = spatialBlend;
            source.reverbZoneMix = reverbZoneMix;

            source.dopplerLevel = dopplerLevel;
            source.spread       = spread;
            source.rolloffMode  = volumeRolloff;
            source.minDistance  = minDistance;
            source.maxDistance  = maxDistance;
        }

        public void Reset () {
            mute                  = false;
            bypassEffects         = false;
            bypassListenerEffects = false;
            bypassReverbZones     = false;
            playOnAwake           = true;
            loop                  = false;

            priority      = 128;
            volume        = 1f;
            pitch         = 1f;
            stereoPan     = 0f;
            spatialBlend  = 0f;
            reverbZoneMix = 1f;

            dopplerLevel   = 1f;
            spread        = 0f;
            volumeRolloff = AudioRolloffMode.Logarithmic;
            minDistance   = 1;
            maxDistance   = 500;
        }

        public void OnValidate () {
            priority      = Mathf.Clamp(priority, 0, 256);
            volume        = Mathf.Clamp01(volume);
            pitch         = Mathf.Clamp(pitch, -3f, 3f);
            stereoPan     = Mathf.Clamp(stereoPan, -1f, 1f);
            spatialBlend  = Mathf.Clamp01(spatialBlend);
            reverbZoneMix = Mathf.Clamp(reverbZoneMix, 0f, 1.1f);

            dopplerLevel = Mathf.Clamp(dopplerLevel, 0f, 5f);
            spread       = Mathf.Clamp(spread, 0f, 360f);
            minDistance  = Mathf.Clamp(minDistance, 0f, maxDistance - 0.01f*maxDistance);
            maxDistance  = Mathf.Clamp(maxDistance, minDistance + 0.01f*minDistance, 1000000f);
        }
    }

    public bool IsPlaying (string audioClipName) {
        for (int i = 0; i < sounds.Length; i++)
            if (sounds[i].name == audioClipName)
                return sounds[i].source.isPlaying;
        return false;
    }

    public bool Pause (string audioClipName) {
        for (int i = 0; i < sounds.Length; i++)
            if (sounds[i].name == audioClipName) {
                sounds[i].source.Pause();
                return true;
            }
        return false;
    }

    public bool Play (string audioClipName) {
        for (int i = 0; i < sounds.Length; i++)
            if (sounds[i].name == audioClipName) {
                sounds[i].source.Play();
                return true;
            }
        return false;
    }

    public bool PlayDelayed (string audioClipName, float delay) {
        for (int i = 0; i < sounds.Length; i++)
            if (sounds[i].name == audioClipName) {
                sounds[i].source.PlayDelayed(delay);
                return true;
            }
        return false;
    }

    public bool PlayScheduled (string audioClipName, double time) {
        for (int i = 0; i < sounds.Length; i++)
            if (sounds[i].name == audioClipName) {
                sounds[i].source.PlayScheduled(time);
                return true;
            }
        return false;
    }

    public bool Stop (string audioClipName) {
        for (int i = 0; i < sounds.Length; i++)
            if (sounds[i].name == audioClipName) {
                sounds[i].source.Stop();
                return true;
            }
        return false;
    }

    public bool UnPause (string audioClipName) {
        for (int i = 0; i < sounds.Length; i++)
            if (sounds[i].name == audioClipName) {
                sounds[i].source.UnPause();
                return true;
            }
        return false;
    }

    void Awake () {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < sounds.Length; i++) {
            if (sounds[i].gameObject == null)
                sounds[i].gameObject = gameObject;
            sounds[i].GenerateAudioSource();
        }
    }

    void OnValidate() {
        if (sounds.Length != _numberOfSounds) {
            for (int i = 0; i < sounds.Length; i++)
                if (sounds[i].name == "" && sounds[i].clip == null)
                    sounds[i].Reset();
            _numberOfSounds = sounds.Length;
        } else {
            for (int i = 0; i < sounds.Length; i++)
                sounds[i].OnValidate();
        }
    }
}
