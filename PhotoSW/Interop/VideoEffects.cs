using PhotoSW.IMIX.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace PhotoSW.Interop
{
	public class VideoEffects
	{
		public string GetVideoEffectsXML(ProcessedVideoInfo obj, List<PanProperty> PanPropertyLst, List<TransitionProperty> TransitionPropertyLst, List<SlotProperty> borderslotlist, List<SlotProperty> logoSlotList)
		{
			string text = string.Empty;
			text += "<effects>";
			text += "<lightness>";
			text += obj.lightness;
			text += "</lightness>";
			text += "<saturation>";
			text += obj.saturation;
			text += "</saturation>";
			text += "<contrast>";
			text += obj.contrast;
			text += "</contrast>";
			text += "<darkness>";
			text += obj.darkness;
			text += "</darkness>";
			text += "<greyScale>";
			text += obj.greyScale.ToString();
			text += "</greyScale>";
			text += "<invert>";
			text += obj.invert.ToString();
			text += "</invert>";
			string text2 = text;
			string[] array = new string[12];
			array[0] = text2;
			array[1] = "<textLogo textLogoPosition=\"";
			array[2] = obj.textLogoPosition;
			array[3] = "\" textfontName=\"";
			array[4] = obj.textfontName;
			array[5] = "\" textfontColor=\"";
			array[6] = obj.textfontColor;
			array[7] = "\" textfontSize=\"";
			array[8] = obj.textfontSize;
			array[9] = "\" textfontStyle=\"";
			array[10] = obj.textfontStyle;
			do
			{
				array[11] = "\">";
				text = string.Concat(array);
				text += obj.textLogo;
				text += "</textLogo>";
				text += "<zoom>";
				text += obj.zoom;
				text += "</zoom>";
				text += "<fadeInOut>";
			}
			while (false);
			text += obj.fadeInOut;
			text += "</fadeInOut>";
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"<chroma chromaKeyColor=\"",
				obj.chromaKeyColor,
				"\" chromaKeyBG=\"",
				obj.chromaKeyBG,
				"\" >"
			});
			text += obj.chroma.ToString();
			text += "</chroma>";
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"<audio amplify=\"",
				obj.amplify,
				"\" equal1=\"",
				obj.equal1,
				"\" equal2=\"",
				obj.equal2,
				"\" equal3=\"",
				obj.equal3,
				"\" equal4=\"",
				obj.equal4,
				"\" equal5=\"",
				obj.equal5,
				"\" equal6=\"",
				obj.equal6,
				"\">"
			});
			text += obj.audio;
			text += "</audio>";
			if (PanPropertyLst != null && PanPropertyLst.Count > 0)
			{
				text += "<Pans>";
				foreach (PanProperty current in PanPropertyLst)
				{
					text += "<Pan>";
					object obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanID>",
						current.PanID,
						"</PanID>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanStartTime>",
						current.PanStartTime,
						"</PanStartTime>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanStopTime>",
						current.PanStopTime,
						"</PanStopTime>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanSourceLeft>",
						current.PanSourceLeft,
						"</PanSourceLeft>"
					});
					obj2 = text;
					object[] array2 = new object[4];
					array2[0] = obj2;
					if (!false)
					{
						array2[1] = "<PanSourceTop>";
					}
					array2[2] = current.PanSourceTop;
					array2[3] = "</PanSourceTop>";
					text = string.Concat(array2);
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanSourceWidth>",
						current.PanSourceWidth,
						"</PanSourceWidth>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanSourceHeight>",
						current.PanSourceHeight,
						"</PanSourceHeight>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanDestLeft>",
						current.PanDestLeft,
						"</PanDestLeft>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanDestTop>",
						current.PanDestTop,
						"</PanDestTop>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanDestWidth>",
						current.PanDestWidth,
						"</PanDestWidth>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PanDestHeight>",
						current.PanDestHeight,
						"</PanDestHeight>"
					});
					text += "</Pan>";
				}
				text += "</Pans>";
			}
			else
			{
				text += "<Pans>";
				text += "</Pans>";
			}
			if (TransitionPropertyLst != null && TransitionPropertyLst.Count > 0)
			{
				text += "<Transitions>";
				foreach (TransitionProperty current2 in TransitionPropertyLst)
				{
					text += "<Transition>";
					object obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<ID>",
						current2.ID,
						"</ID>"
					});
					obj2 = text;
					do
					{
						text = string.Concat(new object[]
						{
							obj2,
							"<TransitionID>",
							current2.TransitionID,
							"</TransitionID>"
						});
						obj2 = text;
						text = string.Concat(new object[]
						{
							obj2,
							"<TransitionStartTime>",
							current2.TransitionStartTime,
							"</TransitionStartTime>"
						});
						obj2 = text;
					}
					while (7 == 0);
					text = string.Concat(new object[]
					{
						obj2,
						"<TransitionStopTime>",
						current2.TransitionStopTime,
						"</TransitionStopTime>"
					});
					text = text + "<TransitionName>" + current2.TransitionName + "</TransitionName>";
					text += "</Transition>";
				}
				text += "</Transitions>";
			}
			else
			{
				text += "<Transitions>";
				text += "</Transitions>";
			}
			if (borderslotlist != null && borderslotlist.Count > 0)
			{
				text += "<Borders>";
				using (List<SlotProperty>.Enumerator enumerator3 = borderslotlist.GetEnumerator())
				{
					while (true)
					{
						IL_936:
						bool flag = enumerator3.MoveNext();
						while (flag)
						{
							SlotProperty current3 = enumerator3.Current;
							if (-1 != 0)
							{
								text += "<Border>";
								object obj2 = text;
								text = string.Concat(new object[]
								{
									obj2,
									"<ItemID>",
									current3.ItemID,
									"</ItemID>"
								});
								text = text + "<Name>" + Path.GetFileName(current3.FilePath) + "</Name>";
								obj2 = text;
								text = string.Concat(new object[]
								{
									obj2,
									"<StartTime>",
									current3.StartTime,
									"</StartTime>"
								});
								obj2 = text;
								object[] array2 = new object[4];
								array2[0] = obj2;
								array2[1] = "<StopTime>";
								array2[2] = current3.StopTime;
								do
								{
									array2[3] = "</StopTime>";
									text = string.Concat(array2);
								}
								while (false);
								text += "</Border>";
								goto IL_936;
							}
						}
						break;
					}
				}
				text += "</Borders>";
			}
			else
			{
				text += "<Borders>";
				text += "</Borders>";
			}
			if (logoSlotList != null && logoSlotList.Count > 0)
			{
				text += "<graphics>";
				foreach (SlotProperty current4 in logoSlotList)
				{
					text += "<graphic>";
					object obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<ItemID>",
						current4.ItemID,
						"</ItemID>"
					});
					text = text + "<Name>" + Path.GetFileName(current4.FilePath) + "</Name>";
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<StartTime>",
						current4.StartTime,
						"</StartTime>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<StopTime>",
						current4.StopTime,
						"</StopTime>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PositionTop>",
						current4.Top,
						"</PositionTop>"
					});
					obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						"<PositionLeft>",
						current4.Left,
						"</PositionLeft>"
					});
					text += "</graphic>";
				}
				text += "</graphics>";
			}
			else
			{
				text += "<graphics>";
				text += "</graphics>";
			}
			text += "</effects>";
			return text;
		}
	}
}
