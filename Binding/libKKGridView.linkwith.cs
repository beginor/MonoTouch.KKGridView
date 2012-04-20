using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libKKGridView.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV6, ForceLoad = true)]
