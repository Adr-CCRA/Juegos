using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public List<VideoPlayer> videoPlayers;
    private int currentVideoIndex = 0;

    private void Start()
    {
        // Ocultar todos los videos al inicio excepto el primero
        for (int i = 0; i < videoPlayers.Count; i++)
        {
            videoPlayers[i].gameObject.SetActive(i == currentVideoIndex);
        }
    }

    public void OcultarVideo()
    {
        if (videoPlayers[currentVideoIndex].isPlaying)
        {
            videoPlayers[currentVideoIndex].Stop();
        }
        videoPlayers[currentVideoIndex].gameObject.SetActive(false);
    }

    public void MostrarVideo()
    {
        videoPlayers[currentVideoIndex].gameObject.SetActive(true);
        videoPlayers[currentVideoIndex].Play();
    }

    public void CambiarVideo(int newIndex)
    {
        if (newIndex < 0 || newIndex >= videoPlayers.Count) return;

        OcultarVideo();
        currentVideoIndex = newIndex;
        MostrarVideo();
    }

    public void ReproducirVideo(GameObject videoPrefab)
    {
        // Destruir instancias anteriores
        if (videoPlayers[currentVideoIndex] != null)
        {
            Destroy(videoPlayers[currentVideoIndex].gameObject);
        }

        // Instanciar y reproducir el nuevo video
        GameObject videoInstance = Instantiate(videoPrefab);
        VideoPlayer newVideoPlayer = videoInstance.GetComponent<VideoPlayer>();
        newVideoPlayer.Play();

        // Destruir el objeto de video cuando termina
        newVideoPlayer.loopPointReached += (VideoPlayer vp) =>
        {
            Destroy(videoInstance);
        };
    }
}
