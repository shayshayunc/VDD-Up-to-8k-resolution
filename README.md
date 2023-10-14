# Indirect Display Driver Sample

This is a sample driver that shows how to create a Windows Indirect Display Driver using the IddCx class extension driver.

## Installation

### Scoop (recommended)
If you have [Scoop](https://scoop.sh/), you can easily install this driver in one go. In an elevated prompt, run:
```powershell
scoop bucket add extras
scoop bucket add nonportable
scoop install iddsampledriver-ge9-np -g
```
The driver should be automatically installed and should be working out of the box.

### Manually

1. Download the latest version from the releases page, and extract the contents to a folder.
2. Copy `option.txt` to `C:\IddSampleDriver\option.txt` before installing the driver **(important!)**.
3. See the [guide](https://github.com/roshkins/IddSampleDriver/releases) in [roshkins repo](https://github.com/roshkins/IddSampleDriver) for the rest of the installation steps.
You can use the following resolutions and refresh rates:

### Resolutions:

    640 x 480
    800 x 600
    1024 x 768
    1152 x 864
    1280 x 600
    1280 x 720
    1280 x 768
    1280 x 800
    1280 x 960
    1280 x 1024
    1360 x 768
    1366 x 768
    1400 x 1050
    1440 x 900
    1600 x 900
    1680 x 1050
    1600 x 1024
    1920 x 1080
    1920 x 1200
    1920 x 1440
    2560 x 1440
    2560 x 1600
    2880 x 1620
    2880 x 1800
    3008 x 1692
    3200 x 1800
    3200 x 2400
    3840 x 2160
    3840 x 2400
    4096 x 2304
    4096 x 2560
    5120 x 2880
    6016 x 3384
    7680 x 4320

### Refresh Rates:

    60Hz
    75Hz
    120Hz
    144Hz
    240Hz

## Background reading ##

Start at the [Indirect Display Driver Model Overview](https://msdn.microsoft.com/en-us/library/windows/hardware/mt761968(v=vs.85).aspx) on MSDN.

## Customizing the sample ##

The sample driver code is very simplistic and does nothing more than enumerate a single monitor when its device enters the D0/started power state. Throughout the code, there are `TODO` blocks with important information on implementing functionality in a production driver.

### Code structure ###

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

License MIT and CC0 or Public Domain (for changes I made, check with Microsoft for their license), whichever is least restrictive -- Use it

AS IS - NO IMPLICIT OR EXPLICIT warranty This may break your computer, it didn't break mine. It runs in User Mode which means it's less likely to cause system instability like the Blue Screen of Death.

## Acknowledgements

See the original repo:
https://github.com/roshkins/IddSampleDriver

Microsoft Indirect Display Driver/Sample: 
https://github.com/microsoft/Windows-driver-samples/tree/master/video/IndirectDisplay

Thanks to https://github.com/akatrevorjay/edid-generator for the hi-res EDID.
