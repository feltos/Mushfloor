using System;


namespace InControl.NativeProfile
{
	// @cond nodoc
	public class HoriPadEX2TurboControllerMacProfile : Xbox360DriverMacProfile
	{
		public HoriPadEX2TurboControllerMacProfile()
		{
			Name = "Hori Pad EX2 Turbo Controller";
			Meta = "Hori Pad EX2 Turbo Controller on Mac";

			Matchers = new[] {
				new NativeInputDeviceMatcher {
					VendorID = 0x1bad,
					ProductID = 0xf501,
				},
			};
		}
	}
	// @endcond
}


