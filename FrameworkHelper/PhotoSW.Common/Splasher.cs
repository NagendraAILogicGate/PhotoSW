using System;
using System.Windows;

namespace PhotoSW.Common
{
	public static class Splasher
	{
		private static Window mSplash;

		public static Window Splash
		{
			get
			{
				return Splasher.mSplash;
			}
			set
			{
				Splasher.mSplash = value;
			}
		}

		public static void ShowSplash()
		{
			if (Splasher.mSplash != null)
			{
				Splasher.mSplash.Show();
			}
		}

		public static void CloseSplash()
		{
			if (Splasher.mSplash != null)
			{
				Splasher.mSplash.Close();
				if (Splasher.mSplash is System.IDisposable)
				{
					(Splasher.mSplash as System.IDisposable).Dispose();
				}
			}
		}
	}
}
