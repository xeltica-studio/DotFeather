#region License
//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2009 the Open Toolkit library.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

using OpenToolkit.Audio.OpenAL;
using OpenToolkit.Core;

namespace OpenToolkit.Audio
{
	internal static class AudioDeviceEnumerator
	{
		#region All device strings

		private static readonly List<string> available_playback_devices = new List<string>();
		private static readonly List<string> available_recording_devices = new List<string>();

		internal static IList<string> AvailablePlaybackDevices
		{
			get
			{
				return available_playback_devices.AsReadOnly();
			}
		}
		internal static IList<string> AvailableRecordingDevices
		{
			get
			{
				return available_recording_devices.AsReadOnly();
			}
		}

		#endregion All device strings

		#region Default device strings

		internal static string? DefaultPlaybackDevice { get; private set; }

		internal static string? DefaultRecordingDevice { get; private set; }

		#endregion Default device strings

		#region Is OpenAL supported?

		internal static bool IsOpenALSupported { get; private set; } = true;

		#endregion Is OpenAL supported?

		#region Alc Version number

		internal enum AlcVersion
		{
			Alc1_0,
			Alc1_1
		}

		internal static AlcVersion Version { get; private set; }

		#endregion Alc Version number

		#region Constructors

		// Loads all available audio devices into the available_*_devices lists.
		static AudioDeviceEnumerator()
		{
			ALDevice dummy_device = ALDevice.Null;
			ALContext dummy_context = ALContext.Null;

			try
			{
				Debug.WriteLine("Enumerating audio devices.");
				Debug.Indent();

				// need a dummy context for correct results
				dummy_device = ALC.OpenDevice(null);
				dummy_context = ALC.CreateContext(dummy_device, (int[])null!);
				bool dummy_success = ALC.MakeContextCurrent(dummy_context);
				AlcError dummy_error = ALC.GetError(dummy_device);
				if (!dummy_success || dummy_error != AlcError.NoError)
				{
					throw new Exception("Failed to create dummy Context. Device (" + dummy_device.ToString() +
													") Context (" + dummy_context.Handle.ToString() +
													") MakeContextCurrent " + (dummy_success ? "succeeded" : "failed") +
													", Alc Error (" + dummy_error.ToString() + ") " + ALC.GetString(ALDevice.Null, (AlcGetString)dummy_error));
				}

				// Get a list of all known playback devices, using best extension available
				if (ALC.IsExtensionPresent(ALDevice.Null, "ALC_ENUMERATION_EXT"))
				{
					Version = AlcVersion.Alc1_1;
					if (ALC.IsExtensionPresent(ALDevice.Null, "ALC_ENUMERATE_ALL_EXT"))
					{
						available_playback_devices.AddRange(ALC.GetString(ALDevice.Null, AlcGetStringList.AllDevicesSpecifier));
						DefaultPlaybackDevice = ALC.GetString(ALDevice.Null, AlcGetString.DefaultAllDevicesSpecifier);
					}
					else
					{
						available_playback_devices.AddRange(ALC.GetString(ALDevice.Null, AlcGetStringList.DeviceSpecifier));
						DefaultPlaybackDevice = ALC.GetString(ALDevice.Null, AlcGetString.DefaultDeviceSpecifier);
					}
				}
				else
				{
					Version = AlcVersion.Alc1_0;
					Debug.Print("Device enumeration extension not available. Failed to enumerate playback devices.");
				}
				AlcError playback_err = ALC.GetError(dummy_device);
				if (playback_err != AlcError.NoError)
					throw new Exception("Alc Error occured when querying available playback devices. " + playback_err.ToString());

				// Get a list of all known recording devices, at least ALC_ENUMERATION_EXT is needed too
				if (Version == AlcVersion.Alc1_1 && ALC.IsExtensionPresent(ALDevice.Null, "ALC_EXT_CAPTURE"))
				{
					available_recording_devices.AddRange(ALC.GetString(ALDevice.Null, AlcGetStringList.CaptureDeviceSpecifier));
					DefaultRecordingDevice = ALC.GetString(ALDevice.Null, AlcGetString.CaptureDefaultDeviceSpecifier);
				}
				else
				{
					Debug.Print("Capture extension not available. Failed to enumerate recording devices.");
				}
				AlcError record_err = ALC.GetError(dummy_device);
				if (record_err != AlcError.NoError)
					throw new Exception("Alc Error occured when querying available recording devices. " + record_err.ToString());

#if DEBUG
				Debug.WriteLine("Found playback devices:");
				foreach (string s in available_playback_devices)
					Debug.WriteLine(s);

				Debug.WriteLine("Default playback device: " + DefaultPlaybackDevice);

				Debug.WriteLine("Found recording devices:");
				foreach (string s in available_recording_devices)
					Debug.WriteLine(s);

				Debug.WriteLine("Default recording device: " + DefaultRecordingDevice);
#endif
			}
			catch (DllNotFoundException e)
			{
				Trace.WriteLine(e.ToString());
				IsOpenALSupported = false;
			}
			catch (Exception ace)
			{
				Trace.WriteLine(ace.ToString());
				IsOpenALSupported = false;
			}
			finally
			{
				Debug.Unindent();

				// clean up the dummy context
				ALC.MakeContextCurrent(ALContext.Null);
				if (dummy_context != ALContext.Null && dummy_context.Handle != ALDevice.Null)
					ALC.DestroyContext(dummy_context);
				if (dummy_device != ALDevice.Null)
					ALC.CloseDevice(dummy_device);
			}
		}

		#endregion
	}
}
