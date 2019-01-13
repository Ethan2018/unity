using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class ClipManager  {

    //从配置文件中加载clip名字
    //string[] clipName = { "ClipButton", "RiverScence", "UIMusic" };
    string[] clipName; //内存优化

    public ClipManager()
    {
        ReadConfig();
        LoadClips();
    }


    SingleClip[] allSingleClip; //内存中的
    /// <summary>
    /// 加载到内存
    /// </summary>
    public void LoadClips()
    {
        allSingleClip = new SingleClip[clipName.Length];
        for (int i = 0; i < clipName.Length; i++)
        {
            AudioClip tmpClip = Resources.Load<AudioClip>(clipName[i]);
            SingleClip tmpSingle = new SingleClip(tmpClip); //加载到类中
            allSingleClip[i] = tmpSingle; //用数组存起来
        }
            
    }

    /// <summary>
    /// 根据名字找到SingleClip
    /// </summary>
    /// <returns></returns>
    public SingleClip FindClipByName(string tmpName)
    {
        int tmpIndex = -1;
        for(int i = 0; i < clipName.Length; i++) {
            if(clipName[i].Equals(tmpName))   //不用==
            {
                tmpIndex = i;
            }
        }
        if(tmpIndex != -1)
        {
            return allSingleClip[tmpIndex];
        }
        return null;
    }
    public void ReadConfig()
    {
        var filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "AudioConfig.txt");
        FileInfo fInfo = new FileInfo(filePath);
        if(fInfo.Exists)
        {
            StreamReader r = new StreamReader(filePath);
            //byte[] data = new byte[1024];
            //data = Encoding.UTF8.GetBytes(r.ReadToEnd());
            //s = Encoding.UTF8.GetString(data, 0, data.Length);
            string tmpLine = r.ReadLine();
            int lineCount = 0;
            if(int.TryParse(tmpLine, out lineCount))
            {
                clipName = new string[lineCount];
                for (int i =0; i < lineCount; i++)
                {
                    tmpLine = r.ReadLine();
                    string[] splits = tmpLine.Split(" ".ToCharArray());
                    clipName[i] = splits[0];
                }
                r.Close();
            }
        }
    }
}
