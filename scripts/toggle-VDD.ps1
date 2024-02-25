$device   = get-pnpdevice -class Display -FriendlyName 'IddSampleDriver Device HDR' -ErrorAction SilentlyContinue
if ($device) {
    switch ($device.Status) {
        'OK'    { 
            Write-Host "Disabling device"; get-pnpdevice -class Display -FriendlyName 'IddSampleDriver Device HDR' | disable-pnpdevice -Confirm:$false ; break 
        }
        default { 
            Write-Host "Enabling device";  get-pnpdevice -class Display -FriendlyName 'IddSampleDriver Device HDR' | enable-pnpdevice -Confirm:$false 
        }
    }
}
else {
    Write-Warning "Device not found"
}