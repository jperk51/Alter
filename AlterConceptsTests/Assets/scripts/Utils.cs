using UnityEngine;
using System.Collections;

public static class Utils
{
	public static int FramesPerPush = 20;						//Number of frames between each time snapshot push
	public static int FramesPerPop = 30;						//Number of frames between each time snapshot pop during time reversal
	public static int MaxStackCount = 1000;						//Max number of time snapshots
	public static int DelayCounterTigger = 10;					//Delay for real death after tutorial on time reversal
	public static int AmountToFadeTotal = 50;					//Minimum opacity percent for goal		

	public static float GravityScale = 4f;						//Scale for gravity (used mostly to control jump height)
	public static float NegativeOneFloat = -1f;					//Float negative one
	public static float OneHundredFloat = 100f;					//Float 100
	public static float AmountToFadePerFrame = 0.65f;			//Amount for goal to fade per frame

	public static Vector2 ZeroVelocity = new Vector2 (0f, 0f);	//Zero Velocity

	public static Color Red = new Color32 (150, 34, 34, 1);		//RGB for Red Background
	public static Color Blue = new Color32 (39, 64, 139, 1);	//RGB for Blue Background
	public static Color Green = new Color32 (58, 130, 58, 1);	//RGB for Green Background
	public static Color Violet = new Color32 (118, 82, 140, 1);	//RGB for Violet Background
}
