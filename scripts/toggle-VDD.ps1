$deviceId = 'ROOT\DISPLAY\0000' 
$device   = Get-PnpDevice -InstanceId $deviceId -ErrorAction SilentlyContinue
if ($device) {
    switch ($device.Status) {
        'OK'    { Write-Host "Disabling device"; Disable-PnpDevice -InstanceId $deviceId -Confirm:$false; break }
        default { Write-Host "Enabling device";  Enable-PnpDevice -InstanceId $deviceId -Confirm:$false }
    }
}
else {
    Write-Warning "Device with ID '$deviceId' not found"
}