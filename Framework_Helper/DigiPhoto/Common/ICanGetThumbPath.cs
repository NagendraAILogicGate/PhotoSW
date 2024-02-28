namespace DigiPhoto.Common
{
    using System;

    public interface ICanGetThumbPath
    {
        string GetMiniSourcePath(string thumbPath, bool checkExist);
        string GetMiniThumbPath(string path, bool checkExist);
        string GetSourcePath(string thumbPath, bool checkExist);
        string GetThumbPath(string path, bool checkExist);
    }
}

