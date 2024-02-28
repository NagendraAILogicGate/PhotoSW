using System;

namespace PhotoSW.Common
{
	public interface ICanGetThumbPath
	{
		string GetMiniThumbPath(string path, bool checkExist);

		string GetThumbPath(string path, bool checkExist);

		string GetMiniSourcePath(string thumbPath, bool checkExist);

		string GetSourcePath(string thumbPath, bool checkExist);
	}
}
