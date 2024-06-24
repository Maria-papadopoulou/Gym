using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    private int currentVideoIndex = 0;

    void Start()
    {
        videoPlayer.clip = videoClips[currentVideoIndex];
        videoPlayer.loopPointReached += OnVideoEnded;
        videoPlayer.Play();
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        currentVideoIndex = (currentVideoIndex + 1) % videoClips.Length;
        vp.clip = videoClips[currentVideoIndex];
        vp.Play();
    }

    public void PlayNextVideo()
    {
        OnVideoEnded(videoPlayer);
    }
}
