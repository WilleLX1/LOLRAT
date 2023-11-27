# Install Python
Invoke-WebRequest -Uri 'https://www.python.org/ftp/python/3.9.7/python-3.9.7-amd64.exe' -OutFile 'python-3.9.7-amd64.exe'
Start-Process -Wait -FilePath 'python-3.9.7-amd64.exe' -ArgumentList '/quiet InstallAllUsers=1 PrependPath=1'
Remove-Item -Path 'python-3.9.7-amd64.exe'

# Run pip commands in a hiddun new terminal
# install these packages
# ctypes, os, sys, time, requests, subprocess, socket
$pipCommand = 'pip install --upgrade pip && pip install ctypes os sys time requests subprocess socket'
Start-Process -WindowStyle Hidden -FilePath 'cmd.exe' -ArgumentList '/C', $pipCommand