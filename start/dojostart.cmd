msiexec.exe /L*V "c:\installation.log" /i c:\msi\WixTutorialPackage.msi ACCOUNTKEY=123456 DEVICETYPE=Type1 SERVICEURL=https://myservice.com
start appwiz.cpl
start ms-settings:appsfeatures
start services.msc
start "" "C:\msi"
start "" "C:\Program Files"
start regedit
