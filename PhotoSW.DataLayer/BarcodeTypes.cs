using System;

namespace PhotoSW.DataLayer
{
	public enum BarcodeTypes
	{
		AztecCode = -2147483648,
		Code128 = 1,
		Code39,
		Interl25 = 4,
		EAN13 = 8,
		EAN8 = 16,
		Codabar = 32,
		Code11 = 64,
		UPCA = 128,
		UPCE = 256,
		Industr25 = 512,
		Code93 = 1024,
		DataBarOmni = 2048,
		DataBarLim = 4096,
		DataBarStacked = 8192,
		DataBarExp = 16384,
		DataBarExpStacked = 32768,
		AztecUnrecognized = 1048576,
		LinearUnrecognized = 16777216,
		PDF417Unrecognized = 33554432,
		DataMatrixUnrecognized = 67108864,
		QRCodeUnrecognized = 134217728,
		DataMatrix = 268435456,
		PDF417 = 536870912,
		QRCode = 1073741824
	}
}
