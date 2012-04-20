using System;

namespace MonoTouch.KKGrid {

	public enum KKGridViewScrollPosition {
		None,
		Top,
		Middle,
		Bottom
	}
	
	public enum KKGridViewAnimation {
		Fade,
		Resize,
		SlideLeft,
		SlideTop,
		SlideRight,
		SlideBottom,
		Explode,
		Implode,
		None
	}
	
	public enum KKGridViewCellAccessoryPosition {
		PositionTopRight,    // 1
		PositionTopLeft,     // 2
		PositionBottomLeft,  // 3
		PositionBottomRight, // 4
		PositionCenter
	}
	
	public enum KKGridViewCellAccessoryType {
		AppleDefault,
		ChristianDalonzo
	}
	
}

