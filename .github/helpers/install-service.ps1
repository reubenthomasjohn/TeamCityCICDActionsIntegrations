$serviceName = "ServiceName"
$displayName = "Service Display Name"
$description = "Description of service"
$exePath = "C:\Path\To\ConsoleApp.exe"

# Stop and delete existing service if it exists
if (Get-Service $serviceName -ErrorAction SilentlyContinue) {
    Stop-Service $serviceName -Force
    sc.exe delete $serviceName
}

# Create new service
sc.exe create $serviceName binPath= "\"$exePath\"" DisplayName= "\"$displayName\"" start= auto
sc.exe description $serviceName $description

# Start the service
Start-Service $serviceName
