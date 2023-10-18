# Virtual Display Driver
based on Microsoft Indirect Display Driver Sample. This creates a virtual display in Windows that acts and functions just like a real one. It's useful for streaming, virtual reality applications, recording, headless servers, etc. The benefit over a physical display is the ability to adjust resolutions and refresh rates beyond the physical displays capabilities. For example, this would enable the ability to stream a game from your home PC using game streaming software at 240hz at 8K while owning a 60hz 1080p monitor (unrealistic, but explains the abilities well). For servers without displays, this enabled remote desktop and screen streaming to other systems as if there were a display installed. 

Supports emulating resolutions from **640 x 480** to **7680 x 4320 (8K)**, and refresh rates including **60hz, 75hz, 90hz, 120hz, 144hz,** and **240hz.**

This project uses the official Windows Indirect Display Driver combined with the IddCx class extension driver.

## Installation

1. Download the latest version from the releases page, and extract the contents to a folder.
2. Copy `option.txt` to `C:\IddSampleDriver\option.txt` before installing the driver **(important!)**.
3. Right click and run the *.bat file **as an Administrator** to add the driver certificate as a trusted root certificate.
4. Don't install the inf. Open device manager, click on any device, then click on the "Action" menu and click "Add Legacy Hardware".
5. Select "Add hardware from a list (Advanced)" and then select Display adapters
6. Click "Have Disk..." and click the "Browse..." button. Navigate to the extracted files and select the inf file.
7. You are done! Go to display settings to customize the resolution of the additional displays. These displays show up in Sunshine, your Oculus or VR settings, and should be able to be streamed from.
8. You can enable/disable the display adapter to toggle the monitors.


### Resolutions:

    640 x 480
    800 x 600
    1024 x 768
    1152 x 864
    1280 x 720
    1280 x 768
    1280 x 800
    1280 x 960
    1280 x 1024
    1360 x 768
    1366 x 768
    1440 x 900
    1400 x 1050
    1440 x 1440
    1600 x 900
    1600 x 1024
    1680 x 1050
    1920 x 1080
    1920 x 1200
    2560 x 1440
    2560 x 1600
    2880 x 1620
    2880 x 1800
    3008 x 1692
    3840 x 2160
    3840 x 2400
    4096 x 2304
    5120 x 2880
    6016 x 3384
    7680 x 4320

### Refresh Rates:

    60Hz
    75Hz
    90Hz (Great for VR!)
    120Hz
    144Hz
    240Hz

### Video

[![How to install a virtual display]([[http://img.youtube.com/vi/YOUTUBE_VIDEO_ID_HERE/0.jpg](https://i3.ytimg.com/vi/byfBWDnToYk/maxresdefault.jpg)](https://i3.ytimg.com/vi/byfBWDnToYk/maxresdefault.jpg))](https://youtu.be/byfBWDnToYk "How to install a virtual display")

### Screenshots:

![image](https://github.com/itsmikethetech/Virtual-Display-Driver/assets/25166211/0f1dfed6-c9ac-4cb6-92cf-7d9ab2ac0c66)

![image](https://github.com/itsmikethetech/Virtual-Display-Driver/assets/25166211/5cb8ce08-890f-4bc1-a1a6-34f22e103699)

![image](https://github.com/itsmikethetech/Virtual-Display-Driver/assets/25166211/02af86f2-b896-4265-9174-b17c9a1aeab7)


## Background reading ##

Start at the [Indirect Display Driver Model Overview](https://msdn.microsoft.com/en-us/library/windows/hardware/mt761968(v=vs.85).aspx) on MSDN.

### Code structure ###

The sample driver code is very simplistic and does nothing more than enumerate a single monitor when its device enters the D0/started power state. The IDD runs in Session 0 without any components running in the user session, so any driver instability will not affect the stability of the system as a whole. The IDD is a user-mode only model with no support for kernel-mode components. As such, the driver is able to use any DirectX APIs in order to process the desktop image. In fact, the IddCx provides the desktop image to encode in a DirectX surface.

* `Direct3DDevice` class
    * Contains logic for enumerating the correct render GPU from DXGI and creating a D3D device.
    * Manages the lifetime of a DXGI factory and a D3D device created for the render GPU the system is using to render frames for your indirect display device's swap-chain.
* `SwapChainProcessor` class
    * Processes frames for a swap-chain assigned to the monitor object on a dedicated thread.
    * The sample code does nothing with the frames, but demonstrates a correct processing loop with error handling and notifying the OS of frame completion.
* `IndirectDeviceContext` class
    * Processes device callbacks from IddCx.
    * Manages the creation and arrival of the sample monitor.
    * Handles swap-chain arrival and departure by creating a `Direct3DDevice` and handing it off to a `SwapChainProcessor`.

## License

MIT and CC0 or Public Domain (for changes I made, please consult Microsoft for their license), choose the least restrictive option.

## Disclaimer:

This software is provided "AS IS" with NO IMPLICIT OR EXPLICIT warranty. It's worth noting that while this software functioned without issues on my system, there is no guarantee that it will not impact your computer. It operates in User Mode, which reduces the likelihood of causing system instability, such as the Blue Screen of Death. However, exercise caution when using this software.

## Acknowledgements

Shoutout to Roshkins for the original repo:
https://github.com/roshkins/IddSampleDriver

Microsoft Indirect Display Driver/Sample (Driver code): 
https://github.com/microsoft/Windows-driver-samples/tree/master/video/IndirectDisplay

Thanks to https://github.com/akatrevorjay/edid-generator for the hi-res EDID.

## Star History

[![Star History Chart](https://api.star-history.com/svg?repos=itsmikethetech/Virtual-Display-Driver&type=Date)](https://star-history.com/#itsmikethetech/Virtual-Display-Driver&Date)
