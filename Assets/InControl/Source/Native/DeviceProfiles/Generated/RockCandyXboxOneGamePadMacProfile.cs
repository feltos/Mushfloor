using System;


namespace InControl.NativeProfile
{
	// @cond nodoc
	public class RockCandyXboxOneGamePadMacProfile : XboxOneDriverMacProfile
	{
		public RockCandyXboxOneGamePadMacProfile()
		{
			Name = "Rock Candy Xbox One GamePad";
			Meta = "Rock Candy Xbox One GamePad on Mac";

			Matchers = new[] {
				new NativeInputDeviceMatcher {
					VendorID = 0x0e6f,
					ProductID = 0x0146,
				},
				new NativeInputDeviceMatcher {
					VendorID = 0x0e6f,
					ProductID = 0x0246,
				},
				new NativeInputDeviceMatcher {
					VendorID = 0x0e6f,
					ProductID = 0x0346,
				},
			};
		}
	}
	// @endcond
}


