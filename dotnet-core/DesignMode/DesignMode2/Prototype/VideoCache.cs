using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode2.Prototype
{
    public class VideoCache
    {
        private static Dictionary<string, Video> videoMap = new Dictionary<string, Video>();

        static VideoCache()
        {
            LoadVideo();
        }
        public static Video GetVideo(string videoId)
        {
            if (videoMap.ContainsKey(videoId))
            {
                Video cacheVideo = videoMap[videoId];
                return (Video)cacheVideo.Clone();
            }
            return null;
        }

        public static void LoadVideo()
        {
            Video video1 = new Video() { Id = "1", Content = "复联1" };
            Video video2 = new Video() { Id = "2", Content = "复联2" };

            videoMap.Add(video1.Id, video1);
            videoMap.Add(video2.Id, video2);
        }
    }
}
